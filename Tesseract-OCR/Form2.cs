using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract_OCR.Schedule;

namespace Tesseract_OCR
{
    public partial class Form2 : Form
    {
        Boolean isRun;
        Schedules2 schedule;
        int a = 0;
        bool isDetecting = false;

        public Form2()
        {
            InitializeComponent();

            schedule = new Schedules2();

            this.isRun = true;
            this.timer1.Interval = int.Parse(txtBoxScanTime.Text) * 1000;
            schedule.sendMail = txtBoxMailAddress.Text;
            schedule.mailPass = txtBoxMailPass.Text;
            schedule.receiveMail = txtBoxReceived.Text;
            schedule.notify = 30;
            cbConditionA.Checked = true;
            cbConditionB.Checked = true;
            cbConditionC.Checked = true;
            cbConditionD.Checked = true;
            cb_trip10.Checked = true;
            cb_trip11.Checked = true;
            this.rdbtn1.Checked = true;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Rectangle canvasBoundMatch = Screen.GetBounds(Point.Empty);
            this.Hide();
            if (schedule.capView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                canvasBoundMatch = schedule.capView.GetRectangleText();
                this.tiSoX.Text = "(x,y)=(" + canvasBoundMatch.X + "," + canvasBoundMatch.Y + ")";
                this.tiSoY.Text = "(W,H)=(" + canvasBoundMatch.Width + "," + canvasBoundMatch.Height + ")";
            }
            this.Show();
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            if (isRun == true)
            {
                timer1.Enabled = true;
                lblStart.Text = "Stop";
                isRun = false;
            }
            else
            {
                timer1.Enabled = false;
                lblStart.Text = "Start";
                isRun = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!isDetecting)
                {
                    isDetecting = true;
                    this.schedule.mailCount = this.rdbtn1.Checked ? 1 : 2;
                    this.schedule.Run();
                    this.lblScanResult.Text = this.schedule.scanResult;
                    this.lblScanTotal.Text = this.schedule.sumScores.ToString();
                    this.labelA.Text = this.schedule.generatePreviousString("A");
                    this.labelB.Text = this.schedule.generatePreviousString("B");
                    this.labelC.Text = this.schedule.generatePreviousString("C");
                    this.lbHistory.Text = this.schedule.getHistory();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            finally {
                isDetecting = false;
            }
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txtBoxScanTime.Text) * 1000;
            schedule.sendMail = txtBoxMailAddress.Text;
            schedule.mailPass = txtBoxMailPass.Text;
            schedule.receiveMail = textBox1.Text;
            schedule.notify = (int.Parse(txtBoxMaintenance.Text) * 60) / int.Parse(txtBoxScanTime.Text);
        }

        private void cbConditionB_CheckedChanged(object sender, EventArgs e)
        {
            this.schedule.checkingClass.conditionB = cbConditionB.Checked;
        }

        private void cbConditionA_CheckedChanged(object sender, EventArgs e)
        {
            this.schedule.checkingClass.conditionA = cbConditionA.Checked;
        }

        private void cbConditionC_CheckedChanged(object sender, EventArgs e)
        {
            this.schedule.checkingClass.conditionC = cbConditionC.Checked;
        }

        private void cbConditionD_CheckedChanged(object sender, EventArgs e)
        {
            this.schedule.checkingClass.conditionD = cbConditionD.Checked;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void cb_trip10_CheckedChanged(object sender, EventArgs e)
        {
            this.schedule.checkingClass.conditionE = cb_trip10.Checked;
        }

        private void cb_trip11_CheckedChanged(object sender, EventArgs e)
        {
            this.schedule.checkingClass.conditionF = cb_trip11.Checked;
        }
    }
}
