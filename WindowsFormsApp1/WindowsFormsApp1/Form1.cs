using System;
using System.Collections.Generic;
using System.DJ.ImplementFactory;
using System.DJ.ImplementFactory.Commons;
using System.DJ.ImplementFactory.Pipelines.Pojo;
using System.Windows.Forms;
using WindowsFormsApp1.dbInterfaces;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        List<SendUserInfoToAPI> wlists = new List<SendUserInfoToAPI>();
        List<SendEquipInfoToAPI> elists = new List<SendEquipInfoToAPI>();

        [MyAutoCall]
        IEmployeeInfo employeeInfo;

        [MyAutoCall]
        ICalculate calculate;

        [MyAutoCall]
        VirtualMethod virtualMethod;

        public Form1()
        {
            InitializeComponent();            
            ImplementAdapter.Register(this);

            //test_clone();

            getData();

            //int a1 = calculate.Sum(1, 2);

            //virtualMethod.say();

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;

            this.Closed += Form1_Closed;
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            foreach (var item in wlists)
            {
                ((IDisposable)item).Dispose();
            }

            foreach (var item in elists)
            {
                ((IDisposable)item).Dispose();
            }
        }

        private void PList_test()
        {
            PList<Para> pps = new PList<Para>();
            pps.Add(new Para(Guid.NewGuid())
            {
                ParaName = "pn1",
                ParaValue = "pv1"
            });

            pps.Add(new Para(Guid.NewGuid())
            {
                ParaName = "pn2",
                ParaValue = "pv2"
            });

            string pv = pps["pn", true].TryObject<string>();
        }

        /// <summary>
        /// 以实体集合形势获取数据
        /// </summary>
        private void getDatas()
        {
            EmployeeInfo eInfo = new EmployeeInfo();
            eInfo.name = "RongJian3";
            eInfo.address = "ShenZhen3";
            eInfo.telphoneNumber = "0755";

            List<EmployeeInfo> employeeInfosList = employeeInfo.employeeInfoList(eInfo);

            //当 isAsync = true 时, 异步调用 action
            employeeInfo.employeeInfoList(eInfo, list =>
            {
                int nc = list.Count;
            });
        }

        /// <summary>
        /// 以单实体形势获取数据
        /// </summary>
        private void getData()
        {
            EmployeeInfo ei = employeeInfo.getEmployeeInfoByCompanyNameEn("YY");
            ei.ForeachProperty((pi, type, fn, fv) =>
            {
                textBox1.Text += fn + ": " + fv.ToString() + "\r\n";
            });

            string s1 = employeeInfo.getEmployeeInfoByCompanyNameEn1("YY");

            textBox1.Text += s1 + "\r\n";

            string s2 = employeeInfo.getEmployeeInfoByCompanyNameEn2("YY");
            textBox1.Text += s1 + "\r\n";
        }

        /// <summary>
        /// 获取动态字段数据
        /// </summary>
        private void getDataOfDynamicField()
        {
            DataEntity<DataElement> dataElements = new DataEntity<DataElement>();
            dataElements.Add("CompanyNameEn", "YY");
            string s3 = employeeInfo.getEmployeeInfoByCompanyNameEn3(dataElements);

            string s4 = employeeInfo.getEmployeeInfoByCompanyNameEn4(dataElements);

            DataEntity<DataElement> ei1 = employeeInfo.getEmployeeInfoByCompanyNameEn5("YY");
        }

        /// <summary>
        /// 记录统计或判断是否有记录存在
        /// </summary>
        private void dataCount()
        {
            int num = employeeInfo.count();
            bool isExsit = employeeInfo.isExsit();
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        private void insertData()
        {
            EmployeeInfo eInfo = new EmployeeInfo();
            eInfo.name = "RongJian3";
            eInfo.address = "ShenZhen3";
            eInfo.telphoneNumber = "0755";
            ////当 EnabledBuffer = false 时, 同步调用 action
            employeeInfo.insert(eInfo, num =>
            {
                int a = num;
            });

            eInfo = new EmployeeInfo();
            eInfo.name = "RongJian3-1";
            eInfo.address = "ShenZhen3-1";
            eInfo.telphoneNumber = "0755";

            int a1 = employeeInfo.insert(eInfo);

            eInfo = new EmployeeInfo();
            eInfo.name = "RongJian3-2";
            eInfo.address = "ShenZhen3-2";
            eInfo.telphoneNumber = "0755";

            a1 = employeeInfo.insert(eInfo);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        private void updateData()
        {
            //当 EnabledBuffer = true 时, 异步调用 action
            employeeInfo.update(new EmployeeInfo() { id = 3, name = "ZhangSan3" }, 3, un =>
            {
                int u1 = un;
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void deleteData()
        {
            EmployeeInfo ei = employeeInfo.getEmployeeInfoByCompanyNameEn("YY");
            bool isSuccessful = employeeInfo.delete(ei);
        }

        private void test_clone()
        {
            TestClone1 testClone1 = new TestClone1();
            testClone1.id = 3;
            testClone1.list1 = new List<TestClone1>();
            testClone1.list1.Add(new TestClone1()
            {
                id = 3
            });
            testClone1.list1.Add(testClone1);

            testClone1.list2.Add(new TestClone2()
            {
                id = "a",
                age = 23
            });

            TestClone1 tc = AbsClone.Clone(testClone1);
            int id = tc.id;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (var item in wlists)
            {
                ((IDisposable)item).Dispose();
            }

            foreach (var item in elists)
            {
                ((IDisposable)item).Dispose();
            }
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WebApiTest();
            button1.Enabled = false;
        }

        private void WebApiTest()
        {
            SendUserInfoToAPI webapi = null;
            int len = 66;
            for (int i = 0; i < len; i++)
            {
                webapi = new SendUserInfoToAPI()
                {
                    id = i,
                    maxCount = 15002,
                    sleepNum = 10
                };
                webapi.Exec();
                wlists.Add(webapi);
            }

            SendEquipInfoToAPI api = null;
            len = 66;
            for (int i = 0; i < len; i++)
            {
                api = new SendEquipInfoToAPI()
                {
                    id = i,
                    maxCount = 15002,
                    sleepNum = 10
                };
                api.Exec();
                elists.Add(api);
            }
        }
    }
}
