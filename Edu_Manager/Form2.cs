using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Edu_Manager
{
    public partial class Form2 : Form
    {
        public string UserId { get; set; }
        private string sqlcnc = "server=localhost;uid=zizett96;pwd=123456;database=EduManageDB";
        private int EduNum = 0;
        List<string> subtmp = new List<string>();
        int x = 1;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataLoad();
            SubjectLoad();
        }

        private void DataLoad()
        {
            var Conn = new SqlConnection(sqlcnc);
            Conn.Open();

            var Comm01 = new SqlCommand("Select name, edunum, birth, email, phone " + "from e_userinfo where userid = '" + UserId + "'", Conn);
            var myRead01 = Comm01.ExecuteReader();
            if(myRead01.Read())
            {
                this.lblName.Text = "이름 : " + myRead01[0].ToString();
                this.lblEduNum.Text = "학번 : " + myRead01[1].ToString();
                EduNum = Convert.ToInt32(myRead01[1].ToString());
                this.lblBirth.Text = "생년월일 : " + myRead01[2].ToString();
                this.lblEmail.Text = "이메일 : " + myRead01[3].ToString();
                this.lblPhone.Text = "핸드폰 : " + myRead01[4].ToString();
            }
            myRead01.Close();
            subtmp.Clear();
            var Comm02 = new SqlCommand("Select subject from e_user_subject " + "where edunum = " + EduNum + "", Conn);
            var myRead02 = Comm02.ExecuteReader();
            while(myRead02.Read())
            {
                subtmp.Add(myRead02[0].ToString());
            }
            myRead02.Close();
            Conn.Close();
        }

        private void SubjectLoad()
        {
            var Conn = new SqlConnection(sqlcnc);
            Conn.Open();
            var Comm = new SqlCommand("Select subject from e_subJect", Conn);
            var myRead = Comm.ExecuteReader();
            while (myRead.Read())
            {
                if (!subtmp.Contains(myRead[0].ToString()))
                    this.lbSubject.Items.Add(myRead[0].ToString());
            }
            myRead.Close();
            Conn.Close();
            foreach (string s in subtmp)
                this.lbMySubject.Items.Add(s);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            subtmp.Clear();
            foreach(string s in lbSubject.SelectedItems)
            {
                this.lbMySubject.Items.Add(s);
                subtmp.Add(s);
            }
            foreach(string s in subtmp)
            {
                this.lbSubject.Items.Remove(s);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            subtmp.Clear();
            foreach(string s in lbMySubject.SelectedItems)
            {
                this.lbSubject.Items.Add(s);
                subtmp.Add(s);
            }
            foreach(string s in subtmp)
            {
                this.lbMySubject.Items.Remove(s);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var Conn = new SqlConnection(sqlcnc);
                Conn.Open();

                var myCom01 = new SqlCommand("delete from e_user_subject where edunum = " + EduNum + "", Conn);
                myCom01.ExecuteNonQuery();

                foreach (string sub in this.lbMySubject.Items)
                {
                    var strSQL = "insert into e_user_subject(id, edunum, subject)" + " values(" + x + "," + EduNum + ", '" + sub + "')";
                    x++;
                    var myCom02 = new SqlCommand(strSQL, Conn);
                    myCom02.ExecuteNonQuery();
                }
                Conn.Close();
                MessageBox.Show("데이터가 저장되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("데이터가 저장되지 않았습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.EndNum = EduNum;
            if(frm3.ShowDialog()==DialogResult.OK)
            {
                DataLoad();
                frm3.Close();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
