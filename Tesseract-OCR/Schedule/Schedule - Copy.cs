using System;
using System.Drawing;
using Tesseract;
using log4net;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using BongDaSo;
using System.Linq;
using BongDaSo.Schedule;
using System.IO;

namespace Tesseract_OCR.Schedule
{
    public class Schedules2
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Schedules2).Name);
        public Detection[] TextDetection { get; set; }
        public SMS sMS { get; set; }
        public CapView capView { get; set; }

        public int smsCondition { get; set; }
        public int callCondition { get; set; }
        public int sumScores { get; set; }
        public int count { get; set; }
        public int notify { get; set; }
        public string scanResult { get; set; }
        private Queue<int> queue_sum = new Queue<int>();
        private Queue<String> queue_val = new Queue<String>();
        private HistoryQueue historyQueue = new HistoryQueue();
        private String preString = "";
        private String preType = "";
        private String preLength = "";
        private int countLength = 0; 
        public string sendMail { get; set; }
        public string mailPass { get; set; }
        public string receiveMail { get; set; }
        public string apiKey { get; set; }
        public string secretKey { get; set; }

        private string preValue = "";

        public int isrunning =0;
        public CheckingClass checkingClass { get; set; }
        public Schedules2()
        {
            capView = new CapView();
            sMS = new SMS();
            this.initDetectionList();
            this.count = 0;
            this.checkingClass = new CheckingClass();
        }
        public async void Run()
        {
            try
            {
                string result = this.detectByDetectionArray();
                Console.WriteLine(result);
                _logger.Info(">>>>>>>> detect result: " + result);
                if (preValue.Equals(result) || "" == result) {
                    this.Retrain();
                    return;
                };
                if (result.Length == 3)
                {
                    int sum = int.Parse(result[0].ToString()) + int.Parse(result[1].ToString()) + int.Parse(result[2].ToString());
                    if (sum > 0) {
                        this.scanResult = result[0] + "-" + result[1]  + "-" + result[2] ;
                        preValue = result;

                        this.queue_val.Enqueue(result);
                        if (this.queue_val.Count > 20) this.queue_val.Dequeue();

                        isrunning = 0;
                        this.sumScores = sum;
                        this.addToQueueVal(sum);
                        this.queue_sum.Enqueue(sum);
                        if (this.queue_sum.Count > 20) this.queue_sum.Dequeue();
                        pushNotification();
                    }
                    
                }
                else
                {
                    isrunning++;
                    if (isrunning >= notify)
                    {
                        sMS.SendSMS("Hiện không có trận đấu nào diễn ra ",
                                                                            new MailAddress(sendMail),
                                                                            mailPass,
                                                                            new MailAddress(receiveMail));
                        _logger.Info("Hiện không có trận đấu nào diễn ra" + DateTime.Now.ToString());
                        isrunning = 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                _logger.Error(e.Message);
            }
            Retrain();
        }

        public void Retrain()
        {
            foreach (Detection detect in TextDetection) {
                detect.Train();
            }
        }

        private void addToQueueVal(int sum) {
            if (!this.preString.Equals(""))
            {
                String resultString = "";
                String type = "";
                switch (this.preType) {
                    case "A": {
                            if (sum <= 10)
                            {
                                resultString = this.preString + "-xiu";
                            }
                            else
                            {
                                resultString = this.preString +  "-tai";
                            }
                        } break;
                    case "B": {
                            int[] sumArray = this.queue_sum.ToArray();
                            int index = sumArray.Length - 1;
                            if ((sumArray[index] <= 10 && sum > 10)
                                || (sumArray[index] > 10 && sum <= 10))
                            {
                                type = "D";
                            }
                            else {
                                type = "N";
                            }

                            if (preLength.Equals(type))
                            {
                                this.countLength += 1;
                            }
                            else {
                                this.countLength = 1;
                                this.preLength = type;
                            }
                            resultString = this.preString + "-" + type + this.countLength;
                        } break;
                };
                this.historyQueue.putStringIntoQueue(resultString, this.preType);
                this.preString = "";
                this.preType = "";
            }
        }

        private void pushNotification() {
            try
            {
                int[] list_sum = this.queue_sum.ToArray();
                int last_i = list_sum.Length - 1;
                if (list_sum.Length < 4) return;
                //xiu - xiu_a - tai - xiu_a
                bool conditoin_1 = list_sum[last_i] <= 10 
                    && list_sum[last_i - 1] > 10 
                    && list_sum[last_i - 3] <= 10
                    && list_sum[last_i] == list_sum[last_i - 2]
                    && list_sum.Length >= 4
                    && checkingClass.conditionB;

                //tai - tai_a - xiu - tai_a
                bool conditoin_2 = list_sum[last_i] > 10 
                    && list_sum[last_i - 1] <= 10 
                    && list_sum[last_i - 3] > 10
                    && list_sum[last_i] == list_sum[last_i - 2]
                    && list_sum.Length >= 4
                    && checkingClass.conditionA;

                //tai - xiu - tai - xiu - tai or xiu - tai - xiu - tai - xiu
                bool isFiveConditions = this.checkingChainFive(last_i) && !this.checkingChainFive(last_i - 1);

                if (conditoin_1 || conditoin_2 || isFiveConditions)
                {
                    String type = "";
                    if (conditoin_1 || conditoin_2) { type = "A"; }
                    else if (isFiveConditions) { type = "B"; }
                    //else if (condition_4) { type = "D"; }

                    string vals = "";
                    if (conditoin_1 || conditoin_2) 
                        vals = list_sum[last_i - 3] + "-" + list_sum[last_i - 2] + "-" 
                            + list_sum[last_i - 1] + "-" + list_sum[last_i];
                    if (isFiveConditions) 
                        vals = list_sum[last_i - 4] + "-" + list_sum[last_i - 3] + "-" 
                            + list_sum[last_i - 2] + "-" + list_sum[last_i - 1] + "-" + list_sum[last_i];

                    string message = "Chuoi la: " + vals + "\n";
                    if(!type.Equals(""))
                    message += this.generatePreviousString(type);
                    this.preType = type;
                    this.preString = vals;
                    sMS.SendSMS(message,new MailAddress(sendMail),mailPass,new MailAddress(receiveMail));
                }
            }
            catch (Exception ex) 
            {
                _logger.Error(ex.StackTrace);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public String generatePreviousString(String type) {
            String[] preNotification = this.historyQueue.GetQueueByType(type).ToArray();
            int index = preNotification.Length - 1;
            String result = "Ba lan gan nhat: \n";
            while (index >= 0)
            {
                result += preNotification[index] + "\n";
                index--;
            }
            return result;
        }

        public String getHistory() {
            string result = "History:\n";
            int[] stringArray = this.queue_sum.ToArray();
            for (int i = 0; i < stringArray.Length; i++) {
                result += stringArray[i];
                if (i != stringArray.Length - 1) result += " -> ";
                if (i == 9) result += "\n" + "->";
            }
            return result;
        }

        private bool checkingChainFive(int last_i) {
            int[] list_sum = this.queue_sum.ToArray();
            //tai - xiu - tai - xiu - tai
            bool condition_3 = last_i + 1 >= 5
                && list_sum[last_i] <= 10
                && list_sum[last_i - 1] > 10
                && list_sum[last_i - 2] <= 10
                && list_sum[last_i - 3] > 10
                && list_sum[last_i - 4] <= 10
                && checkingClass.conditionC;
            //xiu - tai - xiu - tai - xiu
            bool condition_4 = last_i + 1 >= 5 
                && list_sum[last_i] > 10
                && list_sum[last_i - 1] <= 10
                && list_sum[last_i - 2] > 10
                && list_sum[last_i - 3] <= 10
                && list_sum[last_i - 4] > 10
                && checkingClass.conditionD;

            return condition_3 || condition_4;
        }

        private string removeInvalidString(string input) {
            string result = "";
            string validString = "0123456789";
            for (int i = 0; i < input.Length; i++) {
                if (validString.Contains(input[i])) {
                    result += input[i];
                }
            }
            return result;
        }

        void initDetectionList() {
            this.TextDetection = new Detection[5];
            for (int i = 0; i < 5; i++) {
                string path = "./tessdata";
                this.TextDetection[i] = new Detection(path);
            }
        }

        String detectByDetectionArray() {
            Dictionary<string, int> resultMap = new Dictionary<string, int>();
            Bitmap bitmap4x = capView.GetRectangleTextBitmap4x();
            Bitmap bitmap3x = capView.GetRectangleTextBitmap3x();
            Bitmap bitmap2_5x = capView.GetRectangleTextBitmap2_5x();
            Bitmap bitmap3_5x = capView.GetRectangleTextBitmap3_5x();
            Bitmap bitmap4_5x = capView.GetRectangleTextBitmap4_5x();
            for (int i = 0; i < 5; i++) {
                string result = "";
                switch (i) {
                    case 0: {
                            result = TextDetection[i].Detect(bitmap4x);
                        } break;
                    case 1: {
                            result = TextDetection[i].Detect(bitmap3x);
                        } break;
                    case 2: {
                            result = TextDetection[i].Detect(bitmap2_5x);
                        } break;
                    case 3: {
                            result = TextDetection[i].Detect(bitmap3_5x);
                        } break;
                    case 4: {
                            result = TextDetection[i].Detect(bitmap4_5x);
                        } break;
                }

                result = result.Replace("\n", String.Empty).Trim();
                result = System.Text.RegularExpressions.Regex.Replace(result, " ", "");
                result = this.removeInvalidString(result);

                if (resultMap.ContainsKey(result))
                {
                    resultMap[result] = resultMap[result] + 1;
                }
                else {
                    resultMap.Add(result, 1);
                }
            }

            if (resultMap.Count > 1) {
                foreach (string key in resultMap.Keys) {
                    Console.WriteLine(">>>>>>>>>>>" + key + "-" + resultMap[key]);
                }
            }

            string finalResult = "";
            int current_count = 0;
            foreach(string key in resultMap.Keys) {
                if (key == preValue && preValue != "") return key;
                if (current_count < resultMap[key]) {
                    finalResult = key;
                    current_count = resultMap[key];
                }
            }

            return finalResult;
        }
    }
}
