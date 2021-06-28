using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    class SendUserInfoToAPI : IDisposable
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
            httpAddress = "http://127.0.0.1:50082/api/UserInfo/Update";
            httpHelper = new HttpHelper(httpAddress);
            UserInfo userInfo = null;
            Random rnd = new Random();
            int num = 0;
            mbool = true;
            Guid guid = new Guid("0FFD951F-327C-4F81-9948-304961D56682");
            while (mbool)
            {
                userInfo = new UserInfo()
                {
                    id = guid,
                    name = "XXX-" + rnd.Next(10, 99),
                    age = rnd.Next(10, 20),
                    address = "SZ-NS-" + rnd.Next(100, 999)
                };
                httpHelper.SendData(userInfo);
                num++;
                if (num == maxCount) mbool = false;
                Thread.Sleep(sleepNum);
            }
            Trace.WriteLine("Thread: " + id + " *************************************");
        }

        private void run1()
        {
            httpAddress = "http://127.0.0.1:50082/api/UserInfo/Insert";
            httpHelper = new HttpHelper(httpAddress);
            UserInfo userInfo = null;
            Random rnd = new Random();
            int num = 0;
            mbool = true;
            while (mbool)
            {
                userInfo = new UserInfo()
                {
                    name = "XXX-" + rnd.Next(10, 99),
                    age = rnd.Next(10, 20),
                    address = "SZ-NS-" + rnd.Next(100, 999)
                };
                httpHelper.SendData(userInfo);
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

        ~SendUserInfoToAPI()
        {
            ((IDisposable)this).Dispose();
        }
    }
}
