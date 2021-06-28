using System;
using System.Diagnostics;
using System.Threading;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    class SendEquipInfoToAPI : IDisposable
    {
        string httpAddress = "";
        Thread thread = null;
        bool mbool = false;
        HttpHelper httpHelper = null;

        public void Exec()
        {
            thread = new Thread(run1);
            thread.Start();
        }

        private void run()
        {
            httpAddress = "http://127.0.0.1:50082/api/EquipmentInfo/Update";
            httpHelper = new HttpHelper(httpAddress);
            
            EquipmentInfo ei = null;
            Random rnd = new Random();
            int num = 0;
            mbool = true;
            Guid guid = new Guid("C00DF89E-5993-4359-B62C-0A6D0CE6B249");
            while (mbool)
            {
                ei = new EquipmentInfo()
                {
                    id = guid,
                    equipmentName = "Equipment -" + rnd.Next(10, 99),
                    height = rnd.Next(10, 20),
                    width = rnd.Next(10, 20),
                    code = "SZ-NS-" + rnd.Next(100, 999)
                };
                httpHelper.SendData(ei);
                num++;
                if (num == maxCount) mbool = false;
                Thread.Sleep(sleepNum);
            }
            Trace.WriteLine("Thread: " + id + " *************************************");
        }

        private void run1()
        {
            httpAddress = "http://127.0.0.1:50082/api/EquipmentInfo/Insert";
            httpHelper = new HttpHelper(httpAddress);
            EquipmentInfo ei = null;
            Random rnd = new Random();
            int num = 0;
            mbool = true;
            while (mbool)
            {
                ei = new EquipmentInfo()
                {
                    equipmentName = "Equipment -" + rnd.Next(10, 99),
                    height = rnd.Next(10, 20),
                    width = rnd.Next(10, 20),
                    code = "SZ-NS-" + rnd.Next(100, 999)
                };
                httpHelper.SendData(ei);
                num++;
                if (num == maxCount) mbool = false;
                Thread.Sleep(sleepNum);
            }
            Trace.WriteLine("Thread: " + id + " *************************************");
        }

        public int id { get; set; }

        public int maxCount { get; set; } = 100;

        public int sleepNum { get; set; } = 100;

        void IDisposable.Dispose()
        {
            mbool = false;
        }

        ~SendEquipInfoToAPI()
        {
            ((IDisposable)this).Dispose();
        }
    }
}
