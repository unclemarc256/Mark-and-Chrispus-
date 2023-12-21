using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College
{
    public partial class SearchStudent : Form
    {
        public SearchStudent()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PROSSY\Documents\College.mdf;Integrated Security=True;Connect Timeout=30");
        private void SearchStudent_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;

            cmd.CommandText = "select NewAdmission.NAID as Student_ID, NewAdmission.fname as Full_Name, NewAdmission.mname as Mother_Name, NewAdmission.gender as Gender, NewAdmission.dob as Date_of_Birth,  NewAdmission.Mobile as Mobile, NewAdmission.email as Email, NewAdmission.semester as UpgradeSemester, NewAdmission.prog as Programming, NewAdmission.sname as School_Name, NewAdmission.duration as Course_Duration, NewAdmission.address as Address, fees as fees from NewAdmission inner join fees on NewAdmission .NAID=fees.NAID";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;

            cmd.CommandText = "select * from NewAdmission where NAID = "+textBox1.Text+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}
