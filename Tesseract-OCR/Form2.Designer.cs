namespace Tesseract_OCR
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.tiSoY = new System.Windows.Forms.Label();
            this.tiSoX = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbtn2 = new System.Windows.Forms.RadioButton();
            this.rdbtn1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxMaintenance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxScanTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBoxReceived = new System.Windows.Forms.Label();
            this.txtBoxMailPass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxMailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblScanTotal = new System.Windows.Forms.Label();
            this.lblScanResult = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbHistory = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelC = new System.Windows.Forms.Label();
            this.cb_trip10 = new System.Windows.Forms.CheckBox();
            this.cb_trip11 = new System.Windows.Forms.CheckBox();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.cbConditionB = new System.Windows.Forms.CheckBox();
            this.cbConditionC = new System.Windows.Forms.CheckBox();
            this.cbConditionD = new System.Windows.Forms.CheckBox();
            this.cbConditionA = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tiSoY
            // 
            this.tiSoY.AutoSize = true;
            this.tiSoY.Location = new System.Drawing.Point(22, 100);
            this.tiSoY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tiSoY.Name = "tiSoY";
            this.tiSoY.Size = new System.Drawing.Size(31, 25);
            this.tiSoY.TabIndex = 1;
            this.tiSoY.Text = "Y:";
            // 
            // tiSoX
            // 
            this.tiSoX.AutoSize = true;
            this.tiSoX.Location = new System.Drawing.Point(22, 55);
            this.tiSoX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tiSoX.Name = "tiSoX";
            this.tiSoX.Size = new System.Drawing.Size(32, 25);
            this.tiSoX.TabIndex = 2;
            this.tiSoX.Text = "X:";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(159, 226);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(103, 35);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdbtn2);
            this.groupBox1.Controls.Add(this.rdbtn1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBoxMaintenance);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxScanTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(125, 364);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(554, 214);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mail count:";
            // 
            // rdbtn2
            // 
            this.rdbtn2.AutoSize = true;
            this.rdbtn2.Location = new System.Drawing.Point(354, 150);
            this.rdbtn2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rdbtn2.Name = "rdbtn2";
            this.rdbtn2.Size = new System.Drawing.Size(48, 29);
            this.rdbtn2.TabIndex = 7;
            this.rdbtn2.TabStop = true;
            this.rdbtn2.Text = "2";
            this.rdbtn2.UseVisualStyleBackColor = true;
            // 
            // rdbtn1
            // 
            this.rdbtn1.AutoSize = true;
            this.rdbtn1.Location = new System.Drawing.Point(238, 150);
            this.rdbtn1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rdbtn1.Name = "rdbtn1";
            this.rdbtn1.Size = new System.Drawing.Size(48, 29);
            this.rdbtn1.TabIndex = 6;
            this.rdbtn1.TabStop = true;
            this.rdbtn1.Text = "1";
            this.rdbtn1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(477, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "m";
            // 
            // txtBoxMaintenance
            // 
            this.txtBoxMaintenance.Enabled = false;
            this.txtBoxMaintenance.Location = new System.Drawing.Point(238, 100);
            this.txtBoxMaintenance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxMaintenance.Name = "txtBoxMaintenance";
            this.txtBoxMaintenance.Size = new System.Drawing.Size(231, 29);
            this.txtBoxMaintenance.TabIndex = 4;
            this.txtBoxMaintenance.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Time to maintenance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(482, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "s";
            // 
            // txtBoxScanTime
            // 
            this.txtBoxScanTime.Enabled = false;
            this.txtBoxScanTime.Location = new System.Drawing.Point(240, 46);
            this.txtBoxScanTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxScanTime.Name = "txtBoxScanTime";
            this.txtBoxScanTime.Size = new System.Drawing.Size(231, 29);
            this.txtBoxScanTime.TabIndex = 1;
            this.txtBoxScanTime.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Time to scan:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.txtBoxReceived);
            this.groupBox2.Controls.Add(this.txtBoxMailPass);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtBoxMailAddress);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(125, 586);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(554, 214);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mail Settings:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(127, 109);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 29);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "huyquoc.vn2@gmail.com";
            // 
            // txtBoxReceived
            // 
            this.txtBoxReceived.AutoSize = true;
            this.txtBoxReceived.Location = new System.Drawing.Point(29, 116);
            this.txtBoxReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtBoxReceived.Name = "txtBoxReceived";
            this.txtBoxReceived.Size = new System.Drawing.Size(99, 25);
            this.txtBoxReceived.TabIndex = 8;
            this.txtBoxReceived.Text = "Received:";
            // 
            // txtBoxMailPass
            // 
            this.txtBoxMailPass.Enabled = false;
            this.txtBoxMailPass.Location = new System.Drawing.Point(127, 68);
            this.txtBoxMailPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxMailPass.Name = "txtBoxMailPass";
            this.txtBoxMailPass.PasswordChar = '*';
            this.txtBoxMailPass.Size = new System.Drawing.Size(327, 29);
            this.txtBoxMailPass.TabIndex = 7;
            this.txtBoxMailPass.Text = "minhtuanhtt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Pass:";
            // 
            // txtBoxMailAddress
            // 
            this.txtBoxMailAddress.Enabled = false;
            this.txtBoxMailAddress.Location = new System.Drawing.Point(127, 26);
            this.txtBoxMailAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxMailAddress.Name = "txtBoxMailAddress";
            this.txtBoxMailAddress.Size = new System.Drawing.Size(327, 29);
            this.txtBoxMailAddress.TabIndex = 5;
            this.txtBoxMailAddress.Text = "dangminhtuanhtt@gmail.com";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Address:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblScanTotal);
            this.groupBox3.Controls.Add(this.lblScanResult);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(392, 52);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(286, 154);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detected result:";
            // 
            // lblScanTotal
            // 
            this.lblScanTotal.AutoSize = true;
            this.lblScanTotal.Location = new System.Drawing.Point(93, 100);
            this.lblScanTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanTotal.Name = "lblScanTotal";
            this.lblScanTotal.Size = new System.Drawing.Size(62, 25);
            this.lblScanTotal.TabIndex = 8;
            this.lblScanTotal.Text = "Total:";
            // 
            // lblScanResult
            // 
            this.lblScanResult.AutoSize = true;
            this.lblScanResult.Location = new System.Drawing.Point(93, 44);
            this.lblScanResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanResult.Name = "lblScanResult";
            this.lblScanResult.Size = new System.Drawing.Size(72, 25);
            this.lblScanResult.TabIndex = 7;
            this.lblScanResult.Text = "Result:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 100);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "Total:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Result:";
            // 
            // lbHistory
            // 
            this.lbHistory.AutoSize = true;
            this.lbHistory.Location = new System.Drawing.Point(127, 278);
            this.lbHistory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(78, 25);
            this.lbHistory.TabIndex = 9;
            this.lbHistory.Text = "History:";
            // 
            // lblSave
            // 
            this.lblSave.Location = new System.Drawing.Point(318, 226);
            this.lblSave.Margin = new System.Windows.Forms.Padding(4);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(103, 35);
            this.lblSave.TabIndex = 9;
            this.lblSave.Text = "Save";
            this.lblSave.UseVisualStyleBackColor = true;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(479, 226);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(103, 35);
            this.lblStart.TabIndex = 10;
            this.lblStart.Text = "Start";
            this.lblStart.UseVisualStyleBackColor = true;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelC);
            this.groupBox4.Controls.Add(this.cb_trip10);
            this.groupBox4.Controls.Add(this.cb_trip11);
            this.groupBox4.Controls.Add(this.labelB);
            this.groupBox4.Controls.Add(this.labelA);
            this.groupBox4.Controls.Add(this.cbConditionB);
            this.groupBox4.Controls.Add(this.cbConditionC);
            this.groupBox4.Controls.Add(this.cbConditionD);
            this.groupBox4.Controls.Add(this.cbConditionA);
            this.groupBox4.Location = new System.Drawing.Point(29, 809);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox4.Size = new System.Drawing.Size(760, 278);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conditions";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(506, 118);
            this.labelC.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(72, 25);
            this.labelC.TabIndex = 8;
            this.labelC.Text = "History";
            // 
            // cb_trip10
            // 
            this.cb_trip10.AutoSize = true;
            this.cb_trip10.Location = new System.Drawing.Point(511, 37);
            this.cb_trip10.Margin = new System.Windows.Forms.Padding(4);
            this.cb_trip10.Name = "cb_trip10";
            this.cb_trip10.Size = new System.Drawing.Size(118, 29);
            this.cb_trip10.TabIndex = 7;
            this.cb_trip10.Text = "10-10-10";
            this.cb_trip10.UseVisualStyleBackColor = true;
            this.cb_trip10.CheckedChanged += new System.EventHandler(this.cb_trip10_CheckedChanged);
            // 
            // cb_trip11
            // 
            this.cb_trip11.AutoSize = true;
            this.cb_trip11.Location = new System.Drawing.Point(511, 79);
            this.cb_trip11.Margin = new System.Windows.Forms.Padding(4);
            this.cb_trip11.Name = "cb_trip11";
            this.cb_trip11.Size = new System.Drawing.Size(118, 29);
            this.cb_trip11.TabIndex = 6;
            this.cb_trip11.Text = "11-11-11";
            this.cb_trip11.UseVisualStyleBackColor = true;
            this.cb_trip11.CheckedChanged += new System.EventHandler(this.cb_trip11_CheckedChanged);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(230, 118);
            this.labelB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(72, 25);
            this.labelB.TabIndex = 5;
            this.labelB.Text = "History";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(24, 118);
            this.labelA.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(83, 25);
            this.labelA.TabIndex = 4;
            this.labelA.Text = "History: ";
            // 
            // cbConditionB
            // 
            this.cbConditionB.AutoSize = true;
            this.cbConditionB.Location = new System.Drawing.Point(29, 79);
            this.cbConditionB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbConditionB.Name = "cbConditionB";
            this.cbConditionB.Size = new System.Drawing.Size(148, 29);
            this.cbConditionB.TabIndex = 3;
            this.cbConditionB.Text = "x - x+1 - x+2";
            this.cbConditionB.UseVisualStyleBackColor = true;
            this.cbConditionB.CheckedChanged += new System.EventHandler(this.cbConditionB_CheckedChanged);
            // 
            // cbConditionC
            // 
            this.cbConditionC.AutoSize = true;
            this.cbConditionC.Location = new System.Drawing.Point(235, 37);
            this.cbConditionC.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbConditionC.Name = "cbConditionC";
            this.cbConditionC.Size = new System.Drawing.Size(243, 29);
            this.cbConditionC.TabIndex = 2;
            this.cbConditionC.Text = "Tai - Xiu - Tai -Xiu - Tai";
            this.cbConditionC.UseVisualStyleBackColor = true;
            this.cbConditionC.CheckedChanged += new System.EventHandler(this.cbConditionC_CheckedChanged);
            // 
            // cbConditionD
            // 
            this.cbConditionD.AutoSize = true;
            this.cbConditionD.Location = new System.Drawing.Point(235, 79);
            this.cbConditionD.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbConditionD.Name = "cbConditionD";
            this.cbConditionD.Size = new System.Drawing.Size(244, 29);
            this.cbConditionD.TabIndex = 1;
            this.cbConditionD.Text = "Xiu - Tai - Xiu - Tai -Xiu";
            this.cbConditionD.UseVisualStyleBackColor = true;
            this.cbConditionD.CheckedChanged += new System.EventHandler(this.cbConditionD_CheckedChanged);
            // 
            // cbConditionA
            // 
            this.cbConditionA.AutoSize = true;
            this.cbConditionA.Location = new System.Drawing.Point(29, 37);
            this.cbConditionA.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbConditionA.Name = "cbConditionA";
            this.cbConditionA.Size = new System.Drawing.Size(133, 29);
            this.cbConditionA.TabIndex = 0;
            this.cbConditionA.Text = "t - t+1 - t+2";
            this.cbConditionA.UseVisualStyleBackColor = true;
            this.cbConditionA.CheckedChanged += new System.EventHandler(this.cbConditionA_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tiSoX);
            this.groupBox5.Controls.Add(this.tiSoY);
            this.groupBox5.Location = new System.Drawing.Point(125, 52);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox5.Size = new System.Drawing.Size(259, 154);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Captured Space:";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 1110);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lbHistory);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCapture);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tiSoY;
        private System.Windows.Forms.Label tiSoX;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxScanTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxMaintenance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBoxMailPass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxMailAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblScanTotal;
        private System.Windows.Forms.Label lblScanResult;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button lblSave;
        private System.Windows.Forms.Button lblStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtBoxReceived;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbConditionB;
        private System.Windows.Forms.CheckBox cbConditionC;
        private System.Windows.Forms.CheckBox cbConditionD;
        private System.Windows.Forms.CheckBox cbConditionA;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label lbHistory;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbtn2;
        private System.Windows.Forms.RadioButton rdbtn1;
        private System.Windows.Forms.CheckBox cb_trip11;
        private System.Windows.Forms.CheckBox cb_trip10;
        private System.Windows.Forms.Label labelC;
    }
}