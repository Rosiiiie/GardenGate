using Microsoft.Win32;
using System.Diagnostics;

namespace Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadConfig();
            ApplyTheme(IsDarkMode());
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveConfig();
            base.OnFormClosing(e);
        }

        private void LoadModData(string gameExePath)
        {
            ModDataComboBox.Items.Clear();

            string gameDir = Path.GetDirectoryName(gameExePath)!;
            string modDataDir = Path.Combine(gameDir, "ModData");

            if (!Directory.Exists(modDataDir))
                return;

            foreach (string dir in Directory.GetDirectories(modDataDir))
            {
                ModDataComboBox.Items.Add(Path.GetFileName(dir));
            }

                ModDataComboBox.SelectedIndex = 0;
        }

        private bool IsDarkMode()
        {
            using var key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");

            object? value = key?.GetValue("AppsUseLightTheme");
            return value is int i && i == 0;
        }
        private void ApplyTheme(bool dark)
        {
            Color back = dark ? Color.FromArgb(32, 32, 32) : SystemColors.Control;
            Color fore = dark ? Color.White : SystemColors.ControlText;
            Color inputBack = dark ? Color.FromArgb(45, 45, 45) : Color.White;
            Color disabledBack = dark ? Color.FromArgb(60, 60, 60) : SystemColors.ControlLight;

            this.BackColor = back;

            foreach (Control c in Controls)
            {
                c.ForeColor = fore;
                switch (c)
                {
                    case TextBox or ComboBox:
                        c.BackColor = c.Enabled ? inputBack : disabledBack;
                        break;

                    case Button:
                        c.BackColor = dark ? Color.FromArgb(55, 55, 55) : SystemColors.Control;
                        break;

                    case Label:
                        c.BackColor = back;
                        break;
                }
            }
        }

        private void ModDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ModDataComboBox.Enabled = ModDataCheckBox.Checked;
        }
        private void ModDataComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Color fore = IsDarkMode() ? Color.White : Color.Black;
            e.Graphics.DrawString(ModDataComboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(fore), e.Bounds);
        }


        private void SaveConfig()
        {
            List<string> lines = new()
            {
                UsernameTextBox.Text,
                ServerIpTextBox.Text,
                GamePathTextBox.Text,
                ModDataCheckBox.Checked.ToString(),
                ModDataComboBox.SelectedItem?.ToString() ?? "",
                ArgsTextBox.Text
            };

            File.WriteAllLines("config.txt", lines);
        }

        private void LoadConfig()
        {
            if (!File.Exists("config.txt"))
                return;

            string[] lines = File.ReadAllLines("config.txt");

            if (lines.Length > 0) UsernameTextBox.Text = lines[0];
            if (lines.Length > 1) ServerIpTextBox.Text = lines[1];
            if (lines.Length > 2) GamePathTextBox.Text = lines[2];
            if (lines.Length > 3 && bool.TryParse(lines[3], out bool modEnabled))
                ModDataCheckBox.Checked = modEnabled;
            if (lines.Length > 4 && ModDataComboBox.Items.Contains(lines[4]))
                ModDataComboBox.SelectedItem = lines[4];
            if (lines.Length > 5)
                ArgsTextBox.Text = lines[5];

            if (File.Exists(GamePathTextBox.Text))
                LoadModData(GamePathTextBox.Text);

            
        }

        private void BrowseGameButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "PVZGW1|PVZ.Main_Win64_Retail.exe";

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                GamePathTextBox.Text = Dialog.FileName;
                LoadModData(Dialog.FileName);
            }
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(GamePathTextBox.Text))
            {
                MessageBox.Show("Invalid game path.");
                return;
            }

            List<string> argList = new();

            if (!string.IsNullOrWhiteSpace(ArgsTextBox.Text))
                argList.Add(ArgsTextBox.Text.Trim());

            if (!string.IsNullOrWhiteSpace(UsernameTextBox.Text))
                argList.Add($"-playerName {UsernameTextBox.Text}");

            if (!string.IsNullOrWhiteSpace(ServerIpTextBox.Text))
                argList.Add($"-Client.ServerIp {ServerIpTextBox.Text}");

            if (ModDataCheckBox.Checked && ModDataComboBox.SelectedItem != null)
                argList.Add($"-dataPath ModData/{ModDataComboBox.SelectedItem}");

            string Args = string.Join(" ", argList);
            SaveConfig();

            Process.Start(new ProcessStartInfo
            {
                FileName = GamePathTextBox.Text,
                Arguments = Args,
                WorkingDirectory = Path.GetDirectoryName(GamePathTextBox.Text)
            });
        }
    }
}
