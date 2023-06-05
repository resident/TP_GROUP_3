namespace Client
{
    partial class BanUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUser = new Label();
            tbSelectedUser = new TextBox();
            btnCancel = new Button();
            btnBan = new Button();
            gbTimeSpan = new GroupBox();
            btnOtherTimeSec = new Button();
            btnOtherTimeDays = new Button();
            rbOther = new RadioButton();
            tbOtherTimeSpan = new TextBox();
            labelOtherTime = new Label();
            rbForever = new RadioButton();
            rb6Month = new RadioButton();
            rb3Year = new RadioButton();
            rb1Year = new RadioButton();
            rb3Month = new RadioButton();
            rb1Month = new RadioButton();
            rb1Week = new RadioButton();
            rb1Day = new RadioButton();
            rb12H = new RadioButton();
            rb1H = new RadioButton();
            rb30Min = new RadioButton();
            rb15Min = new RadioButton();
            rb10Min = new RadioButton();
            rb5Min = new RadioButton();
            rb45Sec = new RadioButton();
            gbTimeSpan.SuspendLayout();
            SuspendLayout();
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(12, 9);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(77, 15);
            labelUser.TabIndex = 0;
            labelUser.Text = "Selected User";
            // 
            // tbSelectedUser
            // 
            tbSelectedUser.Location = new Point(12, 27);
            tbSelectedUser.Name = "tbSelectedUser";
            tbSelectedUser.ReadOnly = true;
            tbSelectedUser.Size = new Size(284, 23);
            tbSelectedUser.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 244);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnBan
            // 
            btnBan.Enabled = false;
            btnBan.Location = new Point(221, 244);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(75, 23);
            btnBan.TabIndex = 3;
            btnBan.Text = "Ban";
            btnBan.UseVisualStyleBackColor = true;
            btnBan.Click += btnBan_Click;
            // 
            // gbTimeSpan
            // 
            gbTimeSpan.Controls.Add(btnOtherTimeSec);
            gbTimeSpan.Controls.Add(btnOtherTimeDays);
            gbTimeSpan.Controls.Add(rbOther);
            gbTimeSpan.Controls.Add(tbOtherTimeSpan);
            gbTimeSpan.Controls.Add(labelOtherTime);
            gbTimeSpan.Controls.Add(rbForever);
            gbTimeSpan.Controls.Add(rb6Month);
            gbTimeSpan.Controls.Add(rb3Year);
            gbTimeSpan.Controls.Add(rb1Year);
            gbTimeSpan.Controls.Add(rb3Month);
            gbTimeSpan.Controls.Add(rb1Month);
            gbTimeSpan.Controls.Add(rb1Week);
            gbTimeSpan.Controls.Add(rb1Day);
            gbTimeSpan.Controls.Add(rb12H);
            gbTimeSpan.Controls.Add(rb1H);
            gbTimeSpan.Controls.Add(rb30Min);
            gbTimeSpan.Controls.Add(rb15Min);
            gbTimeSpan.Controls.Add(rb10Min);
            gbTimeSpan.Controls.Add(rb5Min);
            gbTimeSpan.Controls.Add(rb45Sec);
            gbTimeSpan.Location = new Point(12, 65);
            gbTimeSpan.Name = "gbTimeSpan";
            gbTimeSpan.Size = new Size(284, 173);
            gbTimeSpan.TabIndex = 4;
            gbTimeSpan.TabStop = false;
            gbTimeSpan.Text = "Time Span";
            // 
            // btnOtherTimeSec
            // 
            btnOtherTimeSec.Enabled = false;
            btnOtherTimeSec.Location = new Point(179, 136);
            btnOtherTimeSec.Name = "btnOtherTimeSec";
            btnOtherTimeSec.Size = new Size(34, 23);
            btnOtherTimeSec.TabIndex = 18;
            btnOtherTimeSec.Text = "sec";
            btnOtherTimeSec.UseVisualStyleBackColor = true;
            btnOtherTimeSec.Click += btnOtherTimeSec_Click;
            // 
            // btnOtherTimeDays
            // 
            btnOtherTimeDays.Enabled = false;
            btnOtherTimeDays.Location = new Point(143, 136);
            btnOtherTimeDays.Name = "btnOtherTimeDays";
            btnOtherTimeDays.Size = new Size(34, 23);
            btnOtherTimeDays.TabIndex = 17;
            btnOtherTimeDays.Text = "days";
            btnOtherTimeDays.UseVisualStyleBackColor = true;
            btnOtherTimeDays.Click += btnOtherTimeDays_Click;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(219, 97);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(53, 19);
            rbOther.TabIndex = 16;
            rbOther.TabStop = true;
            rbOther.Text = "other";
            rbOther.UseVisualStyleBackColor = true;
            rbOther.CheckedChanged += rbOther_CheckedChanged;
            // 
            // tbOtherTimeSpan
            // 
            tbOtherTimeSpan.Enabled = false;
            tbOtherTimeSpan.Location = new Point(6, 137);
            tbOtherTimeSpan.Name = "tbOtherTimeSpan";
            tbOtherTimeSpan.Size = new Size(128, 23);
            tbOtherTimeSpan.TabIndex = 15;
            tbOtherTimeSpan.Leave += tbOtherTimeSpan_Leave;
            // 
            // labelOtherTime
            // 
            labelOtherTime.AutoSize = true;
            labelOtherTime.Location = new Point(6, 119);
            labelOtherTime.Name = "labelOtherTime";
            labelOtherTime.Size = new Size(95, 15);
            labelOtherTime.TabIndex = 14;
            labelOtherTime.Text = "Other Time Span";
            // 
            // rbForever
            // 
            rbForever.AutoSize = true;
            rbForever.Location = new Point(219, 72);
            rbForever.Name = "rbForever";
            rbForever.Size = new Size(62, 19);
            rbForever.TabIndex = 13;
            rbForever.TabStop = true;
            rbForever.Text = "forever";
            rbForever.UseVisualStyleBackColor = true;
            rbForever.CheckedChanged += RadioButtonChanged;
            // 
            // rb6Month
            // 
            rb6Month.AutoSize = true;
            rb6Month.Location = new Point(143, 97);
            rb6Month.Name = "rb6Month";
            rb6Month.Size = new Size(70, 19);
            rb6Month.TabIndex = 12;
            rb6Month.TabStop = true;
            rb6Month.Text = "6 month";
            rb6Month.UseVisualStyleBackColor = true;
            rb6Month.CheckedChanged += RadioButtonChanged;
            // 
            // rb3Year
            // 
            rb3Year.AutoSize = true;
            rb3Year.Location = new Point(219, 47);
            rb3Year.Name = "rb3Year";
            rb3Year.Size = new Size(56, 19);
            rb3Year.TabIndex = 11;
            rb3Year.TabStop = true;
            rb3Year.Text = "3 year";
            rb3Year.UseVisualStyleBackColor = true;
            rb3Year.CheckedChanged += RadioButtonChanged;
            // 
            // rb1Year
            // 
            rb1Year.AutoSize = true;
            rb1Year.Location = new Point(219, 22);
            rb1Year.Name = "rb1Year";
            rb1Year.Size = new Size(56, 19);
            rb1Year.TabIndex = 6;
            rb1Year.TabStop = true;
            rb1Year.Text = "1 year";
            rb1Year.UseVisualStyleBackColor = true;
            rb1Year.CheckedChanged += RadioButtonChanged;
            // 
            // rb3Month
            // 
            rb3Month.AutoSize = true;
            rb3Month.Location = new Point(143, 72);
            rb3Month.Name = "rb3Month";
            rb3Month.Size = new Size(70, 19);
            rb3Month.TabIndex = 10;
            rb3Month.TabStop = true;
            rb3Month.Text = "3 month";
            rb3Month.UseVisualStyleBackColor = true;
            rb3Month.CheckedChanged += RadioButtonChanged;
            // 
            // rb1Month
            // 
            rb1Month.AutoSize = true;
            rb1Month.Location = new Point(143, 47);
            rb1Month.Name = "rb1Month";
            rb1Month.Size = new Size(70, 19);
            rb1Month.TabIndex = 9;
            rb1Month.TabStop = true;
            rb1Month.Text = "1 month";
            rb1Month.UseVisualStyleBackColor = true;
            rb1Month.CheckedChanged += RadioButtonChanged;
            // 
            // rb1Week
            // 
            rb1Week.AutoSize = true;
            rb1Week.Location = new Point(143, 22);
            rb1Week.Name = "rb1Week";
            rb1Week.Size = new Size(61, 19);
            rb1Week.TabIndex = 8;
            rb1Week.TabStop = true;
            rb1Week.Text = "1 week";
            rb1Week.UseVisualStyleBackColor = true;
            rb1Week.CheckedChanged += RadioButtonChanged;
            // 
            // rb1Day
            // 
            rb1Day.AutoSize = true;
            rb1Day.Location = new Point(73, 97);
            rb1Day.Name = "rb1Day";
            rb1Day.Size = new Size(53, 19);
            rb1Day.TabIndex = 7;
            rb1Day.TabStop = true;
            rb1Day.Text = "1 day";
            rb1Day.UseVisualStyleBackColor = true;
            rb1Day.CheckedChanged += RadioButtonChanged;
            // 
            // rb12H
            // 
            rb12H.AutoSize = true;
            rb12H.Location = new Point(73, 72);
            rb12H.Name = "rb12H";
            rb12H.Size = new Size(47, 19);
            rb12H.TabIndex = 6;
            rb12H.TabStop = true;
            rb12H.Text = "12 h";
            rb12H.UseVisualStyleBackColor = true;
            rb12H.CheckedChanged += RadioButtonChanged;
            // 
            // rb1H
            // 
            rb1H.AutoSize = true;
            rb1H.Location = new Point(73, 47);
            rb1H.Name = "rb1H";
            rb1H.Size = new Size(41, 19);
            rb1H.TabIndex = 5;
            rb1H.TabStop = true;
            rb1H.Text = "1 h";
            rb1H.UseVisualStyleBackColor = true;
            rb1H.CheckedChanged += RadioButtonChanged;
            // 
            // rb30Min
            // 
            rb30Min.AutoSize = true;
            rb30Min.Location = new Point(73, 22);
            rb30Min.Name = "rb30Min";
            rb30Min.Size = new Size(61, 19);
            rb30Min.TabIndex = 4;
            rb30Min.TabStop = true;
            rb30Min.Text = "30 min";
            rb30Min.UseVisualStyleBackColor = true;
            rb30Min.CheckedChanged += RadioButtonChanged;
            // 
            // rb15Min
            // 
            rb15Min.AutoSize = true;
            rb15Min.Location = new Point(6, 97);
            rb15Min.Name = "rb15Min";
            rb15Min.Size = new Size(61, 19);
            rb15Min.TabIndex = 3;
            rb15Min.TabStop = true;
            rb15Min.Text = "15 min";
            rb15Min.UseVisualStyleBackColor = true;
            rb15Min.CheckedChanged += RadioButtonChanged;
            // 
            // rb10Min
            // 
            rb10Min.AutoSize = true;
            rb10Min.Location = new Point(6, 72);
            rb10Min.Name = "rb10Min";
            rb10Min.Size = new Size(61, 19);
            rb10Min.TabIndex = 2;
            rb10Min.TabStop = true;
            rb10Min.Text = "10 min";
            rb10Min.UseVisualStyleBackColor = true;
            rb10Min.CheckedChanged += RadioButtonChanged;
            // 
            // rb5Min
            // 
            rb5Min.AutoSize = true;
            rb5Min.Location = new Point(6, 47);
            rb5Min.Name = "rb5Min";
            rb5Min.Size = new Size(55, 19);
            rb5Min.TabIndex = 1;
            rb5Min.TabStop = true;
            rb5Min.Text = "5 min";
            rb5Min.UseVisualStyleBackColor = true;
            rb5Min.CheckedChanged += RadioButtonChanged;
            // 
            // rb45Sec
            // 
            rb45Sec.AutoSize = true;
            rb45Sec.Location = new Point(6, 22);
            rb45Sec.Name = "rb45Sec";
            rb45Sec.Size = new Size(57, 19);
            rb45Sec.TabIndex = 0;
            rb45Sec.TabStop = true;
            rb45Sec.Text = "45 sec";
            rb45Sec.UseVisualStyleBackColor = true;
            rb45Sec.CheckedChanged += RadioButtonChanged;
            // 
            // BanUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 272);
            Controls.Add(gbTimeSpan);
            Controls.Add(btnBan);
            Controls.Add(btnCancel);
            Controls.Add(tbSelectedUser);
            Controls.Add(labelUser);
            Name = "BanUserForm";
            Text = "Ban User";
            gbTimeSpan.ResumeLayout(false);
            gbTimeSpan.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUser;
        private TextBox tbSelectedUser;
        private Button btnCancel;
        private Button btnBan;
        private GroupBox gbTimeSpan;
        private RadioButton rb1Month;
        private RadioButton rb1Week;
        private RadioButton rb1Day;
        private RadioButton rb12H;
        private RadioButton rb1H;
        private RadioButton rb30Min;
        private RadioButton rb15Min;
        private RadioButton rb10Min;
        private RadioButton rb5Min;
        private RadioButton rb45Sec;
        private RadioButton rbForever;
        private RadioButton rb6Month;
        private RadioButton rb3Year;
        private RadioButton rb1Year;
        private RadioButton rb3Month;
        private TextBox tbOtherTimeSpan;
        private Label labelOtherTime;
        private Button btnOtherTimeSec;
        private Button btnOtherTimeDays;
        private RadioButton rbOther;
    }
}