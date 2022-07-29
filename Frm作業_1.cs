using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
                                          };
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ClickCount++;
            int C = int.Parse(textBox1.Text);
            if (ClickCount * C < SetQuery1().ToList().Count)
                dataGridView1.DataSource =
                    SetQuery1().Take(ClickCount * C).Skip((ClickCount - 1) * C).ToList();
            else { return; }

            if (ClickCount * C < SetQuery1().ToList().Count)
                dataGridView2.DataSource =
                   SetQuery2().Take(ClickCount * C).Skip(C * (ClickCount - 1)).ToList();
            else { return; }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var Query = from Q in files
                        where Q.Name.ToLower().Contains(".log")
                        select Q;
            this.dataGridView1.DataSource = Query.ToList();
        }
        int ClickCount = 0;
        private EnumerableRowCollection<LinqLabs.NWDataSet.OrdersRow> SetQuery1()
        {
            var Query = from Qs in nwDataSet1.Orders
                        where Qs.OrderDate.Year.ToString() == comboBox1.Text
                        orderby Qs.OrderID
                        select Qs;
            return Query;
        }
        private IEnumerable<LinqLabs.NWDataSet.Order_DetailsRow> SetQuery2()
        {
            var Query2 = from Q in nwDataSet1.Order_Details
                         join O in nwDataSet1.Orders on Q.OrderID equals O.OrderID
                         where O.OrderDate.Year.ToString() == comboBox1.Text
                         orderby Q.OrderID
                         select Q;
            return Query2;
        }
        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

        		
            // 數學不及格 ... 是誰 
            #endregion

        }

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		

            //個人 所有科的  sum, min, max, avg


        }
        void fillin()
        {
            var Query = from Q in nwDataSet1.Orders
                        group Q by Q.OrderDate.Year into Y
                        select Y.Key;
            foreach (object Q in Query)
                comboBox1.Items.Add(Q);
        }
        private void Frm作業_1_Load(object sender, EventArgs e)
        {
            fillin();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClickCount--;
            int C = int.Parse(textBox1.Text);
            if (ClickCount > 0)
            {
                dataGridView1.DataSource =
                    SetQuery1().Take(ClickCount * C).Skip((ClickCount - 1) * C).ToList();
            }
            else
            {
                ClickCount = 1;
                dataGridView1.DataSource =
                    SetQuery1().Take(ClickCount * C).Skip((ClickCount - 1) * C).ToList();
            }
            if (ClickCount > 0)
            {
                dataGridView2.DataSource =
                  SetQuery2().Take(ClickCount * C).Skip((ClickCount - 1) * C).ToList();
            }
            else
            {
                ClickCount = 1;
                dataGridView2.DataSource =
                      SetQuery2().Take(ClickCount * C).Skip(C * (ClickCount - 1)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var Query = from Q in files
                        where Q.CreationTime.Year == 2021
                        select Q;
            this.dataGridView1.DataSource = Query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            var Query = from Q in files
                        where Q.Length > 1000000
                        select Q;
            this.dataGridView1.DataSource = Query.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int result))
            {
                var Query = from Q in nwDataSet1.Orders
                            select Q;
                dataGridView1.DataSource = Query.Take(int.Parse(textBox1.Text)).ToList();
            }
            else
            {
                MessageBox.Show("請輸入整數數字");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Query = from Qs in nwDataSet1.Orders
                        where Qs.OrderDate.Year.ToString() == comboBox1.Text
                        select Qs;

            var Query2 = from Q in nwDataSet1.Order_Details
                         join O in nwDataSet1.Orders on Q.OrderID equals O.OrderID
                         where O.OrderDate.Year.ToString() == comboBox1.Text
                         select Q;
            dataGridView1.DataSource = Query.Take(int.Parse(textBox1.Text)).ToList();
            dataGridView2.DataSource = Query2.Take(int.Parse(textBox1.Text)).ToList();
        }
    }
}
