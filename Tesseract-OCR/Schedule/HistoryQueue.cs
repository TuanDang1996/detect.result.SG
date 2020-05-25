using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace BongDaSo.Schedule
{
    class HistoryQueue
    {
        private Queue<String> queueA = new Queue<string>();
        private Queue<String> queueB = new Queue<string>();
        private Queue<String> queueC = new Queue<string>();
        private Queue<String> queueD = new Queue<string>();

        public void putStringIntoQueue(String val, String type) {
            switch (type) {
                case "A":
                    {
                        this.queueA.Enqueue(val);
                        if (this.queueA.Count > 3) this.queueA.Dequeue();
                    } break;
                case "B":
                    {
                        this.queueB.Enqueue(val);
                        if (this.queueB.Count > 5) this.queueB.Dequeue();
                    }
                    break;
                case "C":
                    {
                        this.queueC.Enqueue(val);
                        if (this.queueC.Count > 3) this.queueC.Dequeue();
                    }
                    break;
                case "D":
                    {
                        this.queueD.Enqueue(val);
                        if (this.queueD.Count > 3) this.queueD.Dequeue();
                    }
                    break;
            }
        }

        public Queue<String> GetQueueByType(String type) {
            switch (type)
            {
                case "A":
                    {
                        return this.queueA;
                    }
                case "B":
                    {
                        return this.queueB;
                    }
                case "C":
                    {
                        return this.queueC;
                    }
                case "D":
                    {
                        return this.queueD;
                    }
                default: {
                        return this.queueD;
                    }
            }
        }
    }
}
