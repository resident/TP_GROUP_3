namespace Client
{
    partial class EditBanForm
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
            lbUsers = new ListBox();
            gbSetNew = new GroupBox();
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
            btnApply = new Button();
            btnCancel = new Button();
            LabelUsers = new Label();
            gbAddToCurrent = new GroupBox();
            btnAddOtherTimeSec = new Button();
            btnAddOtherTimeDays = new Button();
            rbAddOrther = new RadioButton();
            tbAddOtherTimeSpan = new TextBox();
            label1 = new Label();
            rbAdd6Month = new RadioButton();
            rbAdd3Year = new RadioButton();
            rbAdd1Year = new RadioButton();
            rbAdd3Month = new RadioButton();
            rbAdd1Month = new RadioButton();
            rbAdd1Week = new RadioButton();
            rbAdd1Day = new RadioButton();
            rbAdd12H = new RadioButton();
            rbAdd1H = new RadioButton();
            rbAdd30Min = new RadioButton();
            rbAdd15Min = new RadioButton();
            rbAdd10Min = new RadioButton();
            rbAdd5Min = new RadioButton();
            rbAdd45Sec = new RadioButton();
            rbAddToCurrent = new RadioButton();
            rbSetNew = new RadioButton();
            gbSetNew.SuspendLayout();
            gbAddToCurrent.SuspendLayout();
            SuspendLayout();
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(8, 27);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(284, 154);
            lbUsers.TabIndex = 15;
            // 
            // gbSetNew
            // 
            gbSetNew.Controls.Add(btnOtherTimeSec);
            gbSetNew.Controls.Add(btnOtherTimeDays);
            gbSetNew.Controls.Add(rbOther);
            gbSetNew.Controls.Add(tbOtherTimeSpan);
            gbSetNew.Controls.Add(labelOtherTime);
            gbSetNew.Controls.Add(rbForever);
            gbSetNew.Controls.Add(rb6Month);
            gbSetNew.Controls.Add(rb3Year);
            gbSetNew.Controls.Add(rb1Year);
            gbSetNew.Controls.Add(rb3Month);
            gbSetNew.Controls.Add(rb1Month);
            gbSetNew.Controls.Add(rb1Week);
            gbSetNew.Controls.Add(rb1Day);
            gbSetNew.Controls.Add(rb12H);
            gbSetNew.Controls.Add(rb1H);
            gbSetNew.Controls.Add(rb30Min);
            gbSetNew.Controls.Add(rb15Min);
            gbSetNew.Controls.Add(rb10Min);
            gbSetNew.Controls.Add(rb5Min);
            gbSetNew.Controls.Add(rb45Sec);
            gbSetNew.Enabled = false;
            gbSetNew.Location = new Point(8, 399);
            gbSetNew.Name = "gbSetNew";
            gbSetNew.Size = new Size(284, 173);
            gbSetNew.TabIndex = 14;
            gbSetNew.TabStop = false;
            gbSetNew.Text = "Set New Ban Time Span";
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
            tbOtherTimeSpan.TextChanged += tbOtherTimeSpan_TextChanged;
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
            // 
            // btnApply
            // 
            btnApply.Enabled = false;
            btnApply.Location = new Point(217, 578);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 13;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(8, 578);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // LabelUsers
            // 
            LabelUsers.AutoSize = true;
            LabelUsers.Location = new Point(8, 9);
            LabelUsers.Name = "LabelUsers";
            LabelUsers.Size = new Size(82, 15);
            LabelUsers.TabIndex = 11;
            LabelUsers.Text = "Selected Users";
            // 
            // gbAddToCurrent
            // 
            gbAddToCurrent.Controls.Add(btnAddOtherTimeSec);
            gbAddToCurrent.Controls.Add(btnAddOtherTimeDays);
            gbAddToCurrent.Controls.Add(rbAddOrther);
            gbAddToCurrent.Controls.Add(tbAddOtherTimeSpan);
            gbAddToCurrent.Controls.Add(label1);
            gbAddToCurrent.Controls.Add(rbAdd6Month);
            gbAddToCurrent.Controls.Add(rbAdd3Year);
            gbAddToCurrent.Controls.Add(rbAdd1Year);
            gbAddToCurrent.Controls.Add(rbAdd3Month);
            gbAddToCurrent.Controls.Add(rbAdd1Month);
            gbAddToCurrent.Controls.Add(rbAdd1Week);
            gbAddToCurrent.Controls.Add(rbAdd1Day);
            gbAddToCurrent.Controls.Add(rbAdd12H);
            gbAddToCurrent.Controls.Add(rbAdd1H);
            gbAddToCurrent.Controls.Add(rbAdd30Min);
            gbAddToCurrent.Controls.Add(rbAdd15Min);
            gbAddToCurrent.Controls.Add(rbAdd10Min);
            gbAddToCurrent.Controls.Add(rbAdd5Min);
            gbAddToCurrent.Controls.Add(rbAdd45Sec);
            gbAddToCurrent.Location = new Point(8, 187);
            gbAddToCurrent.Name = "gbAddToCurrent";
            gbAddToCurrent.Size = new Size(284, 206);
            gbAddToCurrent.TabIndex = 17;
            gbAddToCurrent.TabStop = false;
            gbAddToCurrent.Text = "Add To Current Time Span";
            // 
            // btnAddOtherTimeSec
            // 
            btnAddOtherTimeSec.Enabled = false;
            btnAddOtherTimeSec.Location = new Point(179, 173);
            btnAddOtherTimeSec.Name = "btnAddOtherTimeSec";
            btnAddOtherTimeSec.Size = new Size(34, 23);
            btnAddOtherTimeSec.TabIndex = 38;
            btnAddOtherTimeSec.Text = "sec";
            btnAddOtherTimeSec.UseVisualStyleBackColor = true;
            btnAddOtherTimeSec.Click += btnAddOtherTimeSec_Click;
            // 
            // btnAddOtherTimeDays
            // 
            btnAddOtherTimeDays.Enabled = false;
            btnAddOtherTimeDays.Location = new Point(143, 173);
            btnAddOtherTimeDays.Name = "btnAddOtherTimeDays";
            btnAddOtherTimeDays.Size = new Size(34, 23);
            btnAddOtherTimeDays.TabIndex = 37;
            btnAddOtherTimeDays.Text = "days";
            btnAddOtherTimeDays.UseVisualStyleBackColor = true;
            btnAddOtherTimeDays.Click += btnAddOtherTimeDays_Click;
            // 
            // rbAddOrther
            // 
            rbAddOrther.AutoSize = true;
            rbAddOrther.Location = new Point(194, 122);
            rbAddOrther.Name = "rbAddOrther";
            rbAddOrther.Size = new Size(53, 19);
            rbAddOrther.TabIndex = 36;
            rbAddOrther.TabStop = true;
            rbAddOrther.Text = "other";
            rbAddOrther.UseVisualStyleBackColor = true;
            rbAddOrther.CheckedChanged += rbAddOrther_CheckedChanged;
            // 
            // tbAddOtherTimeSpan
            // 
            tbAddOtherTimeSpan.Enabled = false;
            tbAddOtherTimeSpan.Location = new Point(6, 174);
            tbAddOtherTimeSpan.Name = "tbAddOtherTimeSpan";
            tbAddOtherTimeSpan.Size = new Size(128, 23);
            tbAddOtherTimeSpan.TabIndex = 35;
            tbAddOtherTimeSpan.TextChanged += tbAddOtherTimeSpan_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 156);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 34;
            label1.Text = "Other Time Span";
            // 
            // rbAdd6Month
            // 
            rbAdd6Month.AutoSize = true;
            rbAdd6Month.Location = new Point(194, 47);
            rbAdd6Month.Name = "rbAdd6Month";
            rbAdd6Month.Size = new Size(78, 19);
            rbAdd6Month.TabIndex = 32;
            rbAdd6Month.TabStop = true;
            rbAdd6Month.Text = "+6 month";
            rbAdd6Month.UseVisualStyleBackColor = true;
            // 
            // rbAdd3Year
            // 
            rbAdd3Year.AutoSize = true;
            rbAdd3Year.Location = new Point(194, 97);
            rbAdd3Year.Name = "rbAdd3Year";
            rbAdd3Year.Size = new Size(64, 19);
            rbAdd3Year.TabIndex = 31;
            rbAdd3Year.TabStop = true;
            rbAdd3Year.Text = "+3 year";
            rbAdd3Year.UseVisualStyleBackColor = true;
            // 
            // rbAdd1Year
            // 
            rbAdd1Year.AutoSize = true;
            rbAdd1Year.Location = new Point(194, 72);
            rbAdd1Year.Name = "rbAdd1Year";
            rbAdd1Year.Size = new Size(64, 19);
            rbAdd1Year.TabIndex = 26;
            rbAdd1Year.TabStop = true;
            rbAdd1Year.Text = "+1 year";
            rbAdd1Year.UseVisualStyleBackColor = true;
            // 
            // rbAdd3Month
            // 
            rbAdd3Month.AutoSize = true;
            rbAdd3Month.Location = new Point(194, 22);
            rbAdd3Month.Name = "rbAdd3Month";
            rbAdd3Month.Size = new Size(78, 19);
            rbAdd3Month.TabIndex = 30;
            rbAdd3Month.TabStop = true;
            rbAdd3Month.Text = "+3 month";
            rbAdd3Month.UseVisualStyleBackColor = true;
            // 
            // rbAdd1Month
            // 
            rbAdd1Month.AutoSize = true;
            rbAdd1Month.Location = new Point(102, 122);
            rbAdd1Month.Name = "rbAdd1Month";
            rbAdd1Month.Size = new Size(78, 19);
            rbAdd1Month.TabIndex = 29;
            rbAdd1Month.TabStop = true;
            rbAdd1Month.Text = "+1 month";
            rbAdd1Month.UseVisualStyleBackColor = true;
            // 
            // rbAdd1Week
            // 
            rbAdd1Week.AutoSize = true;
            rbAdd1Week.Location = new Point(102, 97);
            rbAdd1Week.Name = "rbAdd1Week";
            rbAdd1Week.Size = new Size(69, 19);
            rbAdd1Week.TabIndex = 28;
            rbAdd1Week.TabStop = true;
            rbAdd1Week.Text = "+1 week";
            rbAdd1Week.UseVisualStyleBackColor = true;
            // 
            // rbAdd1Day
            // 
            rbAdd1Day.AutoSize = true;
            rbAdd1Day.Location = new Point(102, 72);
            rbAdd1Day.Name = "rbAdd1Day";
            rbAdd1Day.Size = new Size(61, 19);
            rbAdd1Day.TabIndex = 27;
            rbAdd1Day.TabStop = true;
            rbAdd1Day.Text = "+1 day";
            rbAdd1Day.UseVisualStyleBackColor = true;
            // 
            // rbAdd12H
            // 
            rbAdd12H.AutoSize = true;
            rbAdd12H.Location = new Point(102, 47);
            rbAdd12H.Name = "rbAdd12H";
            rbAdd12H.Size = new Size(55, 19);
            rbAdd12H.TabIndex = 25;
            rbAdd12H.TabStop = true;
            rbAdd12H.Text = "+12 h";
            rbAdd12H.UseVisualStyleBackColor = true;
            // 
            // rbAdd1H
            // 
            rbAdd1H.AutoSize = true;
            rbAdd1H.Location = new Point(102, 22);
            rbAdd1H.Name = "rbAdd1H";
            rbAdd1H.Size = new Size(49, 19);
            rbAdd1H.TabIndex = 24;
            rbAdd1H.TabStop = true;
            rbAdd1H.Text = "+1 h";
            rbAdd1H.UseVisualStyleBackColor = true;
            // 
            // rbAdd30Min
            // 
            rbAdd30Min.AutoSize = true;
            rbAdd30Min.Location = new Point(6, 122);
            rbAdd30Min.Name = "rbAdd30Min";
            rbAdd30Min.Size = new Size(69, 19);
            rbAdd30Min.TabIndex = 23;
            rbAdd30Min.TabStop = true;
            rbAdd30Min.Text = "+30 min";
            rbAdd30Min.UseVisualStyleBackColor = true;
            // 
            // rbAdd15Min
            // 
            rbAdd15Min.AutoSize = true;
            rbAdd15Min.Location = new Point(6, 97);
            rbAdd15Min.Name = "rbAdd15Min";
            rbAdd15Min.Size = new Size(69, 19);
            rbAdd15Min.TabIndex = 22;
            rbAdd15Min.TabStop = true;
            rbAdd15Min.Text = "+15 min";
            rbAdd15Min.UseVisualStyleBackColor = true;
            // 
            // rbAdd10Min
            // 
            rbAdd10Min.AutoSize = true;
            rbAdd10Min.Location = new Point(6, 72);
            rbAdd10Min.Name = "rbAdd10Min";
            rbAdd10Min.Size = new Size(69, 19);
            rbAdd10Min.TabIndex = 21;
            rbAdd10Min.TabStop = true;
            rbAdd10Min.Text = "+10 min";
            rbAdd10Min.UseVisualStyleBackColor = true;
            // 
            // rbAdd5Min
            // 
            rbAdd5Min.AutoSize = true;
            rbAdd5Min.Location = new Point(6, 47);
            rbAdd5Min.Name = "rbAdd5Min";
            rbAdd5Min.Size = new Size(63, 19);
            rbAdd5Min.TabIndex = 20;
            rbAdd5Min.TabStop = true;
            rbAdd5Min.Text = "+5 min";
            rbAdd5Min.UseVisualStyleBackColor = true;
            // 
            // rbAdd45Sec
            // 
            rbAdd45Sec.AutoSize = true;
            rbAdd45Sec.Location = new Point(6, 22);
            rbAdd45Sec.Name = "rbAdd45Sec";
            rbAdd45Sec.Size = new Size(65, 19);
            rbAdd45Sec.TabIndex = 19;
            rbAdd45Sec.TabStop = true;
            rbAdd45Sec.Text = "+45 sec";
            rbAdd45Sec.UseVisualStyleBackColor = true;
            // 
            // rbAddToCurrent
            // 
            rbAddToCurrent.AutoSize = true;
            rbAddToCurrent.Checked = true;
            rbAddToCurrent.Location = new Point(164, 188);
            rbAddToCurrent.Name = "rbAddToCurrent";
            rbAddToCurrent.Size = new Size(14, 13);
            rbAddToCurrent.TabIndex = 18;
            rbAddToCurrent.TabStop = true;
            rbAddToCurrent.UseVisualStyleBackColor = true;
            rbAddToCurrent.CheckedChanged += rbAddToCurrent_CheckedChanged;
            // 
            // rbSetNew
            // 
            rbSetNew.AutoSize = true;
            rbSetNew.Location = new Point(145, 401);
            rbSetNew.Name = "rbSetNew";
            rbSetNew.Size = new Size(14, 13);
            rbSetNew.TabIndex = 19;
            rbSetNew.UseVisualStyleBackColor = true;
            rbSetNew.CheckedChanged += rbSetNew_CheckedChanged;
            // 
            // EditBanForm
            // 
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 606);
            Controls.Add(rbAddToCurrent);
            Controls.Add(rbSetNew);
            Controls.Add(gbAddToCurrent);
            Controls.Add(lbUsers);
            Controls.Add(gbSetNew);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(LabelUsers);
            Name = "EditBanForm";
            Text = "Edit ban";
            gbSetNew.ResumeLayout(false);
            gbSetNew.PerformLayout();
            gbAddToCurrent.ResumeLayout(false);
            gbAddToCurrent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbUsers;
        private GroupBox gbSetNew;
        private Button btnOtherTimeSec;
        private Button btnOtherTimeDays;
        private RadioButton rbOther;
        private TextBox tbOtherTimeSpan;
        private Label labelOtherTime;
        private RadioButton rbForever;
        private RadioButton rb6Month;
        private RadioButton rb3Year;
        private RadioButton rb1Year;
        private RadioButton rb3Month;
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
        private Button btnApply;
        private Button btnCancel;
        private Label LabelUsers;
        private GroupBox gbAddToCurrent;
        private RadioButton rbAddToCurrent;
        private RadioButton rbSetNew;
        private Button btnAddOtherTimeSec;
        private Button btnAddOtherTimeDays;
        private RadioButton rbAddOrther;
        private TextBox tbAddOtherTimeSpan;
        private Label label1;
        private RadioButton rbAdd6Month;
        private RadioButton rbAdd3Year;
        private RadioButton rbAdd1Year;
        private RadioButton rbAdd3Month;
        private RadioButton rbAdd1Month;
        private RadioButton rbAdd1Week;
        private RadioButton rbAdd1Day;
        private RadioButton rbAdd12H;
        private RadioButton rbAdd1H;
        private RadioButton rbAdd30Min;
        private RadioButton rbAdd10Min;
        private RadioButton rbAdd5Min;
        private RadioButton rbAdd45Sec;
        private RadioButton rbAdd15Min;
    }
}