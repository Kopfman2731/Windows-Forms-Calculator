namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bt1 = new Button();
            bt2 = new Button();
            bt3 = new Button();
            btPlus = new Button();
            bt4 = new Button();
            bt5 = new Button();
            bt6 = new Button();
            btMinus = new Button();
            bt7 = new Button();
            bt8 = new Button();
            bt9 = new Button();
            btMultiply = new Button();
            btCE = new Button();
            bt0 = new Button();
            btPoint = new Button();
            btDivision = new Button();
            btParOpen = new Button();
            btParClose = new Button();
            btResult = new Button();
            lboxCurrent = new ListBox();
            lboxHistory = new ListBox();
            SuspendLayout();
            // 
            // bt1
            // 
            bt1.Cursor = Cursors.Hand;
            bt1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt1.Location = new Point(9, 231);
            bt1.Name = "bt1";
            bt1.Size = new Size(67, 64);
            bt1.TabIndex = 1;
            bt1.Text = "1";
            bt1.UseVisualStyleBackColor = true;
            bt1.Click += bt1_Click;
            // 
            // bt2
            // 
            bt2.Cursor = Cursors.Hand;
            bt2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt2.Location = new Point(82, 231);
            bt2.Name = "bt2";
            bt2.Size = new Size(67, 64);
            bt2.TabIndex = 2;
            bt2.Text = "2";
            bt2.UseVisualStyleBackColor = true;
            bt2.Click += bt2_Click;
            // 
            // bt3
            // 
            bt3.Cursor = Cursors.Hand;
            bt3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt3.Location = new Point(155, 231);
            bt3.Name = "bt3";
            bt3.Size = new Size(67, 64);
            bt3.TabIndex = 3;
            bt3.Text = "3";
            bt3.UseVisualStyleBackColor = true;
            bt3.Click += bt3_Click;
            // 
            // btPlus
            // 
            btPlus.Cursor = Cursors.Hand;
            btPlus.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btPlus.Location = new Point(228, 231);
            btPlus.Name = "btPlus";
            btPlus.Size = new Size(67, 64);
            btPlus.TabIndex = 4;
            btPlus.Text = "+";
            btPlus.UseVisualStyleBackColor = true;
            btPlus.Click += btPlus_Click;
            // 
            // bt4
            // 
            bt4.Cursor = Cursors.Hand;
            bt4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt4.Location = new Point(9, 301);
            bt4.Name = "bt4";
            bt4.Size = new Size(67, 64);
            bt4.TabIndex = 8;
            bt4.Text = "4";
            bt4.UseVisualStyleBackColor = true;
            bt4.Click += bt4_Click;
            // 
            // bt5
            // 
            bt5.Cursor = Cursors.Hand;
            bt5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt5.Location = new Point(82, 301);
            bt5.Name = "bt5";
            bt5.Size = new Size(67, 64);
            bt5.TabIndex = 7;
            bt5.Text = "5";
            bt5.UseVisualStyleBackColor = true;
            bt5.Click += bt5_Click;
            // 
            // bt6
            // 
            bt6.Cursor = Cursors.Hand;
            bt6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt6.Location = new Point(155, 301);
            bt6.Name = "bt6";
            bt6.Size = new Size(67, 64);
            bt6.TabIndex = 6;
            bt6.Text = "6";
            bt6.UseVisualStyleBackColor = true;
            bt6.Click += bt6_Click;
            // 
            // btMinus
            // 
            btMinus.Cursor = Cursors.Hand;
            btMinus.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btMinus.Location = new Point(228, 301);
            btMinus.Name = "btMinus";
            btMinus.Size = new Size(67, 64);
            btMinus.TabIndex = 5;
            btMinus.Text = "-";
            btMinus.UseVisualStyleBackColor = true;
            btMinus.Click += btMinus_Click;
            // 
            // bt7
            // 
            bt7.Cursor = Cursors.Hand;
            bt7.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt7.Location = new Point(9, 371);
            bt7.Name = "bt7";
            bt7.Size = new Size(67, 64);
            bt7.TabIndex = 16;
            bt7.Text = "7";
            bt7.UseVisualStyleBackColor = true;
            bt7.Click += bt7_Click;
            // 
            // bt8
            // 
            bt8.Cursor = Cursors.Hand;
            bt8.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt8.Location = new Point(82, 371);
            bt8.Name = "bt8";
            bt8.Size = new Size(67, 64);
            bt8.TabIndex = 15;
            bt8.Text = "8";
            bt8.UseVisualStyleBackColor = true;
            bt8.Click += bt8_Click;
            // 
            // bt9
            // 
            bt9.Cursor = Cursors.Hand;
            bt9.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt9.Location = new Point(155, 371);
            bt9.Name = "bt9";
            bt9.Size = new Size(67, 64);
            bt9.TabIndex = 14;
            bt9.Text = "9";
            bt9.UseVisualStyleBackColor = true;
            bt9.Click += bt9_Click;
            // 
            // btMultiply
            // 
            btMultiply.Cursor = Cursors.Hand;
            btMultiply.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btMultiply.Location = new Point(228, 371);
            btMultiply.Name = "btMultiply";
            btMultiply.Size = new Size(67, 64);
            btMultiply.TabIndex = 13;
            btMultiply.Text = "*";
            btMultiply.UseVisualStyleBackColor = true;
            btMultiply.Click += btMultiply_Click;
            // 
            // btCE
            // 
            btCE.Cursor = Cursors.Hand;
            btCE.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btCE.Location = new Point(9, 441);
            btCE.Name = "btCE";
            btCE.Size = new Size(67, 64);
            btCE.TabIndex = 12;
            btCE.Text = "CE";
            btCE.UseVisualStyleBackColor = true;
            btCE.Click += btCE_Click;
            // 
            // bt0
            // 
            bt0.Cursor = Cursors.Hand;
            bt0.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            bt0.Location = new Point(82, 441);
            bt0.Name = "bt0";
            bt0.Size = new Size(67, 64);
            bt0.TabIndex = 11;
            bt0.Text = "0";
            bt0.UseVisualStyleBackColor = true;
            bt0.Click += bt0_Click;
            // 
            // btPoint
            // 
            btPoint.Cursor = Cursors.Hand;
            btPoint.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btPoint.Location = new Point(155, 441);
            btPoint.Name = "btPoint";
            btPoint.Size = new Size(67, 64);
            btPoint.TabIndex = 10;
            btPoint.Text = ".";
            btPoint.UseVisualStyleBackColor = true;
            btPoint.Click += btPoint_Click;
            // 
            // btDivision
            // 
            btDivision.Cursor = Cursors.Hand;
            btDivision.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btDivision.Location = new Point(228, 441);
            btDivision.Name = "btDivision";
            btDivision.Size = new Size(67, 64);
            btDivision.TabIndex = 9;
            btDivision.Text = "/";
            btDivision.UseVisualStyleBackColor = true;
            btDivision.Click += btDivision_Click;
            // 
            // btParOpen
            // 
            btParOpen.Cursor = Cursors.Hand;
            btParOpen.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btParOpen.Location = new Point(9, 511);
            btParOpen.Name = "btParOpen";
            btParOpen.Size = new Size(67, 64);
            btParOpen.TabIndex = 20;
            btParOpen.Text = "(";
            btParOpen.UseVisualStyleBackColor = true;
            btParOpen.Click += btParaOpen_Click;
            // 
            // btParClose
            // 
            btParClose.BackColor = SystemColors.Control;
            btParClose.Cursor = Cursors.Hand;
            btParClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btParClose.Location = new Point(82, 511);
            btParClose.Name = "btParClose";
            btParClose.Size = new Size(67, 64);
            btParClose.TabIndex = 19;
            btParClose.Text = ")";
            btParClose.UseVisualStyleBackColor = false;
            btParClose.Click += btParaClose_Click;
            // 
            // btResult
            // 
            btResult.Cursor = Cursors.Hand;
            btResult.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btResult.Location = new Point(155, 511);
            btResult.Name = "btResult";
            btResult.Size = new Size(140, 64);
            btResult.TabIndex = 18;
            btResult.Text = "=";
            btResult.UseVisualStyleBackColor = true;
            btResult.Click += btResult_Click;
            // 
            // lboxCurrent
            // 
            lboxCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lboxCurrent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lboxCurrent.FormattingEnabled = true;
            lboxCurrent.Location = new Point(9, 193);
            lboxCurrent.Name = "lboxCurrent";
            lboxCurrent.RightToLeft = RightToLeft.No;
            lboxCurrent.Size = new Size(286, 25);
            lboxCurrent.TabIndex = 21;
            // 
            // lboxHistory
            // 
            lboxHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lboxHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lboxHistory.FormattingEnabled = true;
            lboxHistory.Location = new Point(9, 11);
            lboxHistory.Name = "lboxHistory";
            lboxHistory.RightToLeft = RightToLeft.No;
            lboxHistory.Size = new Size(286, 172);
            lboxHistory.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 584);
            Controls.Add(lboxHistory);
            Controls.Add(lboxCurrent);
            Controls.Add(btParOpen);
            Controls.Add(btParClose);
            Controls.Add(btResult);
            Controls.Add(bt7);
            Controls.Add(bt8);
            Controls.Add(bt9);
            Controls.Add(btMultiply);
            Controls.Add(btCE);
            Controls.Add(bt0);
            Controls.Add(btPoint);
            Controls.Add(btDivision);
            Controls.Add(bt4);
            Controls.Add(bt5);
            Controls.Add(bt6);
            Controls.Add(btMinus);
            Controls.Add(btPlus);
            Controls.Add(bt3);
            Controls.Add(bt2);
            Controls.Add(bt1);
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
        }

        #endregion
        private Button bt1;
        private Button bt2;
        private Button bt3;
        private Button btPlus;
        private Button bt4;
        private Button bt5;
        private Button bt6;
        private Button btMinus;
        private Button bt7;
        private Button bt8;
        private Button bt9;
        private Button btMultiply;
        private Button btCE;
        private Button bt0;
        private Button btPoint;
        private Button btDivision;
        private Button btParOpen;
        private Button btParClose;
        private Button btResult;
        private ListBox lboxCurrent;
        private ListBox lboxHistory;
    }
}
