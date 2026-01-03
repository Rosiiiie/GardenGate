namespace Launcher
{
    partial class Form1
    {
        private Label UsernameLabel;
        private TextBox UsernameTextBox;
        private Label ServerIpLabel;
        private TextBox ServerIpTextBox;
        private Label GamePathLabel;
        private TextBox GamePathTextBox;
        private Button BrowseGameButton;
        private Label ModDataLabel;
        private ComboBox ModDataComboBox;
        private CheckBox ModDataCheckBox;
        private Label ArgsLabel;
        private TextBox ArgsTextBox;
        private Button LaunchButton;

        private void InitializeComponent()
        {
            GamePathLabel = new Label();
            GamePathTextBox = new TextBox();
            BrowseGameButton = new Button();
            UsernameLabel = new Label();
            UsernameTextBox = new TextBox();
            ServerIpLabel = new Label();
            ServerIpTextBox = new TextBox();
            ModDataLabel = new Label();
            ModDataComboBox = new ComboBox();
            ModDataCheckBox = new CheckBox();
            ArgsLabel = new Label();
            ArgsTextBox = new TextBox();
            LaunchButton = new Button();
            SuspendLayout();

            UsernameLabel.Location = new Point(12, 20);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(100, 23);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "Username:";
            UsernameTextBox.Location = new Point(120, 17);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(260, 23);
            UsernameTextBox.TabIndex = 1;
            ServerIpLabel.Location = new Point(12, 55);
            ServerIpLabel.Name = "ServerIpLabel";
            ServerIpLabel.Size = new Size(100, 23);
            ServerIpLabel.TabIndex = 2;
            ServerIpLabel.Text = "Server IP:";
            ServerIpTextBox.Location = new Point(120, 52);
            ServerIpTextBox.Name = "ServerIpTextBox";
            ServerIpTextBox.Size = new Size(260, 23);
            ServerIpTextBox.TabIndex = 3;
            GamePathLabel.Location = new Point(12, 90);
            GamePathLabel.Name = "GamePathLabel";
            GamePathLabel.Size = new Size(100, 23);
            GamePathLabel.TabIndex = 0;
            GamePathLabel.Text = "Game Path:";
            GamePathTextBox.Location = new Point(120, 88);
            GamePathTextBox.Name = "GamePathTextBox";
            GamePathTextBox.Size = new Size(185, 23);
            GamePathTextBox.TabIndex = 0;
            BrowseGameButton.Location = new Point(310, 86);
            BrowseGameButton.Name = "BrowseGameButton";
            BrowseGameButton.Size = new Size(70, 23);
            BrowseGameButton.TabIndex = 0;
            BrowseGameButton.Text = "Browse";
            BrowseGameButton.Click += BrowseGameButton_Click;
            ModDataLabel.Location = new Point(12, 125);
            ModDataLabel.Size = new Size(100, 23);
            ModDataLabel.Text = "ModData:";
            ModDataComboBox.Location = new Point(120, 121);
            ModDataComboBox.Size = new Size(185, 23);
            ModDataComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ModDataComboBox.Enabled = false;
            ModDataCheckBox.Location = new Point(310, 123);
            ModDataCheckBox.Size = new Size(75, 23);
            ModDataCheckBox.Text = "Enabled";
            ModDataCheckBox.CheckedChanged += ModDataCheckBox_CheckedChanged;
            ArgsLabel.Location = new Point(12, 160);
            ArgsLabel.Name = "ArgsLabel";
            ArgsLabel.Size = new Size(100, 23);
            ArgsLabel.TabIndex = 7;
            ArgsLabel.Text = "Launch Args:";
            ArgsTextBox.Location = new Point(120, 158);
            ArgsTextBox.Name = "ArgsTextBox";
            ArgsTextBox.Size = new Size(260, 23);
            ArgsTextBox.TabIndex = 8;
            LaunchButton.Location = new Point(12, 201);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(396, 47);
            LaunchButton.TabIndex = 9;
            LaunchButton.Text = "Launch";
            LaunchButton.Click += LaunchButton_Click;

            if (IsDarkMode())
            {
                ModDataComboBox.DrawMode = DrawMode.OwnerDrawFixed;
                ModDataComboBox.DrawItem += ModDataComboBox_DrawItem;
                UsernameTextBox.BorderStyle = BorderStyle.None;
                ServerIpTextBox.BorderStyle = BorderStyle.None;
                ArgsTextBox.BorderStyle = BorderStyle.None;
                ModDataComboBox.FlatStyle = FlatStyle.Flat;
                LaunchButton.FlatStyle = FlatStyle.Flat;
                GamePathTextBox.BorderStyle = BorderStyle.None;
                BrowseGameButton.FlatStyle = FlatStyle.Flat;
                BrowseGameButton.FlatAppearance.BorderSize = 0;
                ModDataComboBox.FlatStyle = FlatStyle.Flat;
            }

            ClientSize = new Size(420, 260);
            Controls.Add(GamePathLabel);
            Controls.Add(GamePathTextBox);
            Controls.Add(BrowseGameButton);
            Controls.Add(UsernameLabel);
            Controls.Add(UsernameTextBox);
            Controls.Add(ServerIpLabel);
            Controls.Add(ServerIpTextBox);
            Controls.Add(ModDataLabel);
            Controls.Add(ModDataComboBox);
            Controls.Add(ModDataCheckBox);
            Controls.Add(ArgsLabel);
            Controls.Add(ArgsTextBox);
            Controls.Add(LaunchButton);
            Text = "Launcher";
            ResumeLayout(false);
            PerformLayout();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}
