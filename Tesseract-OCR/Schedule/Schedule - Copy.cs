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
using System.Threading;
using System.CodeDom;

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
        private String pre4String = "";
        private int count4Length = 0;
        private int countLength = 0; 
        public string sendMail { get; set; }
        public string mailPass { get; set; }
        public string receiveMail { get; set; }
        public string apiKey { get; set; }
        public string secretKey { get; set; }

        private string preValue = "";

        public int isrunning =0;
        public CheckingClass checkingClass { get; set; }
        public int mailCount { get; set; }
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
                   /* case "A1":
                    case "A2":
                        {
                            if (sum <= 10)
                            {
                                resultString = this.preString + "-xiu";
                            }
                            else
                            {
                                resultString = this.preString +  "-tai";
                            }
                            this.historyQueue.putStringzIntoQueue(resultString, this.preType);
                            this.preString = "";
                            this.preType = "";
                        } break;*/
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

                            if (type.Equals("D") && this.countLength >= 1) { 
                                resultString = this.preString + "-" + type + this.countLength;
                                this.historyQueue.putStringIntoQueue(resultString, this.preType);
                            }
                            this.preString = "";
                            this.preType = "";
                        } break;
                    case "C": {
                            if (sum <= 10)
                            {
                                this.preString = this.preString + "-xiu";
                            }
                            else
                            {
                                this.preString = this.preString + "-tai";
                            }

                            if (this.preString.Split('-').Length == 5) {
                                this.historyQueue.putStringIntoQueue(this.preString, this.preType);
                                this.preString = "";
                                this.preType = "";
                            }
                        } break;
                    case "A":
                        {
                            if (sum <= 10)
                            {
                                resultString = this.preString + "-xiu";
                            }
                            else
                            {
                                resultString = this.preString + "-tai";
                            }
                            this.historyQueue.putStringIntoQueue(resultString, this.preType);
                            this.preString = "";
                            this.preType = "";
                        }
                        break;
                };
            }
        }

        private void pushNotification() {
            try
            {
                int[] list_sum = this.queue_sum.ToArray();
                int last_i = list_sum.Length - 1;
                if (list_sum.Length < 3) return;
                /*//xiu - xiu_a - tai - xiu_a
                bool conditoin_1 = list_sum.Length >= 4
                    && list_sum[last_i] <= 10 
                    && list_sum[last_i - 1] > 10 
                    && list_sum[last_i - 3] <= 10
                    && list_sum[last_i] == list_sum[last_i - 2]
                    && checkingClass.conditionB;

                //tai - tai_a - xiu - tai_a
                bool conditoin_2 = list_sum.Length >= 4
                    && list_sum[last_i] > 10 
                    && list_sum[last_i - 1] <= 10 
                    && list_sum[last_i - 3] > 10
                    && list_sum[last_i] == list_sum[last_i - 2]
                    && checkingClass.conditionA;*/
                //t - t+1 - t+2 or x - x+1 - x+2
                bool isSequenceArray = this.checkSequenceArray(last_i) && !this.checkSequenceArray(last_i - 1);

                //tai - xiu - tai - xiu - tai or xiu - tai - xiu - tai - xiu
                bool isFiveConditions = this.checkingChainFive(last_i) && !this.checkingChainFive(last_i - 1);
                bool isD2 = this.preLength.Equals("D") && this.countLength >= 1;
                //check 10 -10 - 10 or 11 - 11 -11
                bool isTripple = this.checkTriple(last_i) && !this.checkTriple(last_i - 1);

                if (/*conditoin_1 || conditoin_2 || */isFiveConditions || isTripple || isSequenceArray)
                {
                    String type = "";
                    /*if (conditoin_1) { type = "A1"; }
                    else if (conditoin_2) { type = "A2"; }
                    else*/
                    if (isFiveConditions) { type = "B"; }
                    else if (isTripple) { type = "C"; }
                    else if (isSequenceArray) { type = "A"; };

                    string vals = "";
                    /*if (conditoin_1 || conditoin_2) 
                        vals = list_sum[last_i - 3] + "-" + list_sum[last_i - 2] + "-" 
                            + list_sum[last_i - 1] + "-" + list_sum[last_i];*/
                    if (isFiveConditions) 
                        vals = list_sum[last_i - 4] + "-" + list_sum[last_i - 3] + "-" 
                            + list_sum[last_i - 2] + "-" + list_sum[last_i - 1] + "-" + list_sum[last_i];
                    if(isTripple || isSequenceArray)
                        vals = list_sum[last_i-2] + "-" + list_sum[last_i - 1] + "-"
                            + list_sum[last_i];
                    string message = "Chuoi la: " + vals + "\n";
                    if(!type.Equals(""))
                    message += this.generatePreviousString(type);
                    this.preType = type;
                    this.preString = vals;
                    if (!(isFiveConditions && !isD2))
                    {
                        for (int i = 0; i < mailCount; i++)
                        {
                            Thread.Sleep(500);
                            sMS.SendSMS(message, new MailAddress(sendMail), mailPass, new MailAddress(receiveMail));
                        }
                    }
                    //this.sendSpecialMail(type, vals);
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

        bool checkTriple(int last_i) {
            int[] list_sum = this.queue_sum.ToArray();
            //tai - xiu - tai - xiu - tai
            bool condition_3 = last_i >= 3
                && list_sum[last_i] == 10
                && list_sum[last_i - 1] == 10
                && list_sum[last_i - 2] == 10
                && checkingClass.conditionE;
            //xiu - tai - xiu - tai - xiu
            bool condition_4 = last_i >= 3
                && list_sum[last_i] == 11
                && list_sum[last_i - 1] == 11
                && list_sum[last_i - 2] == 11
                && checkingClass.conditionF;

            return condition_3 || condition_4;
        }

        bool checkSequenceArray(int last_i) {
            int[] list_sum = this.queue_sum.ToArray();
            //tai - xiu - tai - xiu - tai
            bool condition_3 = last_i + 1 >= 3
                    && list_sum[last_i] == list_sum[last_i - 1] + 1
                    && list_sum[last_i - 1] == list_sum[last_i - 2] + 1
                    && list_sum[last_i] <= 10
                    && checkingClass.conditionB;
            //xiu - tai - xiu - tai - xiu
            bool condition_4 = last_i + 1 >= 3
                    && list_sum[last_i] == list_sum[last_i - 1] + 1
                    && list_sum[last_i - 1] == list_sum[last_i - 2] + 1
                    && list_sum[last_i - 2] > 10
                    && checkingClass.conditionA;

            return condition_3 || condition_4;
        }

        void sendSpecialMail(String type, String val) {
            if (this.pre4String.Equals(type) && this.count4Length >= 6) {
                string message = "Chuoi la: " + val + " L" + this.count4Length  + "\n";
                message += this.generatePreviousString("D");
                string tempString = val + " L" + this.count4Length;
                this.historyQueue.putStringIntoQueue(tempString, "D");
                sMS.SendSMS(message, new MailAddress(sendMail), mailPass, new MailAddress(receiveMail));
            }

            if (this.pre4String != type)
            {
                this.count4Length = 1;
            }
            else {
                this.count4Length++;
            }
            this.pre4String = type;
        }
    }
}
