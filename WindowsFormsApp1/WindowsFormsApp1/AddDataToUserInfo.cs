using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DJ.ImplementFactory;
using System.Text;
using System.Threading;
using WindowsFormsApp1.dbInterfaces;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    class AddDataToUserInfo: IDisposable
    {
        Thread thread = null;
        bool mbool = false;

        [MyAutoCall]
        IUserInfoMapper InfoMapper;

        public AddDataToUserInfo()
        {
            ImplementAdapter.Register(this);
        }

        public int id { get; set; }

        public void exec()
        {
            thread = new Thread(run);
            thread.Start();
        }

        void IDisposable.Dispose()
        {
            mbool = false;
        }

        void run()
        {
            mbool = true;
            Random rnd = new Random();
            UserInfo ui = null;
            int num = 0;
            int ncount = 1000;
            while (mbool)
            {
                ui = new UserInfo()
                {
                    name = "XXX-" + rnd.Next(10, 99),
                    age = rnd.Next(10, 20),
                    address = "address-" + rnd.Next(1, 9)
                };
                InfoMapper.insert(ui);
                num++;
                if (ncount == num) mbool = false;
                Thread.Sleep(10);
            }
            //Trace.WriteLine("thread id: " + id);
        }
    }
}
