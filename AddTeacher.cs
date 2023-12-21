using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace College
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PROSSY\Documents\College.mdf;Integrated Security=True;Connect Timeout=30");
        private void btnSave_Click(object sender, EventArgs e)
        {
            String gender = "";
            bool isChecked = radioMale.Checked;
            if (isChecked)
            {
                gender = radioMale.Text;
            }
            else
            {
                gender = radioFemale.Text;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = "insert into teacher (fname, gender, dob, mobile, email, semester, prog, yer, adr) values ('"+txtFName.Text+"', '"+gender+"', '"+ dateTimePickerDOB.Text+"', '"+txtMobile.Text+"', '"+txtEmail.Text+"', '"+txtSemester.Text+"', '"+txtProgramming+"', '"+txtDuration+"', '"+txtAddress+"')";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
