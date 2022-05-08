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
    public partial class Form3 : Form
    {
        public int EndNum { get; set; }
        private string sqlcnc = "server=localhost;uid=zizett96;pwd=123456;database=EduManageDB";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var Conn = new SqlConnection(sqlcnc);
            Conn.Open();

            var Comm = new SqlCommand("Select name, edunum, birth, email, phone " + "From e_userinfo where edunum = " + EndNum + "", Conn);
            var MyRead = Comm.ExecuteReader();
            if(MyRead.Read())
            {
                this.txtEduNum.Text = MyRead[0].ToString();
                this.txtName.Text = MyRead[1].ToString();
                this.txtBirth.Text = MyRead[2].ToString();
                this.txtEmail.Text = MyRead[3].ToString();
                this.txtPhone.Text = MyRead[4].ToString();
            }
            MyRead.Close();
            Conn.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var Conn = new SqlConnection(sqlcnc);
            Conn.Open();

            var strSQL = "update e_userinfo set birth = '" + this.txtBirth.Text + "', email = '" + this.txtEmail.Text + "', phone = '" + this.txtPhone.Text + "' where edunum = " + EndNum + "";
            var myCom = new SqlCommand(strSQL, Conn);
            int i = myCom.ExecuteNonQuery();
            Conn.Close();
            if (i == 1)
                DialogResult = DialogResult.OK;
        }
    }
}
