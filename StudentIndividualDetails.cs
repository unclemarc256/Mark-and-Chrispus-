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

namespace College
{
    public partial class StudentIndividualDetails : Form
    {
        public StudentIndividualDetails()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PROSSY\Documents\College.mdf;Integrated Security=True;");

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;

            cmd.CommandText = "select * from NewAdmission where NAID = " + textBox1.Text + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count !=0)
            {


            labelFullName.Text = ds.Tables[0].Rows[0][1].ToString();
            labelMName.Text = ds.Tables[0].Rows[0][2].ToString();
            labelGender.Text = ds.Tables[0].Rows[0][3].ToString();
            labelDOB.Text = ds.Tables[0].Rows[0][4].ToString();
            labelMobile.Text = ds.Tables[0].Rows[0][5].ToString();
            labelEmail.Text = ds.Tables[0].Rows[0][6].ToString();
            labelStandard.Text = ds.Tables[0].Rows[0][7].ToString();
            labelMedium.Text = ds.Tables[0].Rows[0][8].ToString();
            labelSName.Text = ds.Tables[0].Rows[0][9].ToString();
            labelYear.Text = ds.Tables[0].Rows[0][10].ToString();
            labelAddress.Text = ds.Tables[0].Rows[0][11].ToString();

            }
            else
            {
                MessageBox.Show("No Record Found", "No Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelFullName.Text = "_________";
                labelMName.Text = "_________";
                labelGender.Text = "_________";
                labelDOB.Text = "_________";
                labelMobile.Text = "_________";
                labelEmail.Text = "_________";
                labelStandard.Text = "_________";
                labelMedium.Text = "_________";
                labelSName.Text = "_________";
                labelYear.Text = "_________";
                labelAddress.Text = "_________";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            labelFullName.Text = "_________";
            labelMName.Text = "_________";
            labelGender.Text = "_________";
            labelDOB.Text = "_________";
            labelMobile.Text = "_________";
            labelEmail.Text = "_________";
            labelStandard.Text = "_________";
            labelMedium.Text = "_________";
            labelSName.Text = "_________";
            labelYear.Text = "_________";
            labelAddress.Text = "_________";

            textBox1.Text = "";

        }
    }
}
