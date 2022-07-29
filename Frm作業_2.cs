using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
            Fill();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var Q = awDataSet1.ProductPhoto.
                OrderBy(n => n.ModifiedDate).
                Select(n=>n );
            dataGridView1.DataSource = Q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Q = awDataSet1.ProductPhoto.
                Where(n => n.ModifiedDate > dateTimePicker1.Value
                && n.ModifiedDate < dateTimePicker2.Value).
                Select(n =>n);
            dataGridView1.DataSource = Q.ToList();
        }
        public void Fill()
        {
            var Q = awDataSet1.ProductPhoto.Select(n =>  n.ModifiedDate.Year ).Distinct();
            foreach(int item in Q)
                comboBox3.Items.Add(item);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "") { comboBox3.Text = "2008"; }
            var Q = awDataSet1.ProductPhoto.
                Where(m => m.ModifiedDate.Year.ToString() == comboBox3.Text).
                OrderBy(m => m.ProductPhotoID).
                Select(m => m);
            dataGridView1.DataSource = Q.ToList();
            
        }
       
Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
        private void button10_Click(object sender, EventArgs e)
        {
            if (dic.Count == 0)
            {
                dic.Add("第一季", new int[] { 1, 2, 3 });
                dic.Add("第二季", new int[] { 4, 5, 6 });
                dic.Add("第三季", new int[] { 7, 8, 9 });
                dic.Add("第四季", new int[] { 10, 11, 12 });
            }
            if (comboBox2.Text == "") { comboBox2.Text = "第一季"; }
            var Q = awDataSet1.ProductPhoto.
                Where(m => dic[comboBox2.Text].
                Contains(m.ModifiedDate.Month)).
                OrderBy(m => m.ProductPhotoID).
                Select(m => m);

            var Qs = from i in awDataSet1.ProductPhoto
                    group i by Season(i.ModifiedDate.Month) into season
                    where season.ToString() == comboBox2.Text
                    select new { k = season.Count()};
            dataGridView1.DataSource = Q.ToList();
            MessageBox.Show("共" + Q.Count() + "筆");
        }

        private string Season (int m)
        {
            if (m == 1 || m == 2 || m == 3)
                return "第一季";
            else if (m == 4 || m == 5 || m == 6)
                return "第二季";
            else if (m == 7|| m == 8 || m ==9)
                return "第三季";
            else
                return "第四季";
        }


        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow is null) { }
            else
            {
                Byte[] byted =
                    (Byte[])dataGridView1.CurrentRow.Cells["LargePhoto"].Value;
                MemoryStream memoryStream = new MemoryStream(byted);
                pictureBox1.Image = Image.FromStream(memoryStream);
                memoryStream.Close();
            }
        }
    }
}
