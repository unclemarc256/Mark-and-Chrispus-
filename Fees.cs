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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PROSSY\Documents\College.mdf;Integrated Security=True;Connect Timeout=30");
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtRegistrationNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegistrationNumber_TextChanged_1(object sender, EventArgs e)
        {
            



            if (txtRegistrationNumber.Text != "")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Con;

                cmd.CommandText = "select fname, mname, duration from NewAdmission where NAID = " + txtRegistrationNumber.Text + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                if (DS.Tables[0].Rows.
Count != 0)
                {
                    fnameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    MnameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    durationLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    fnameLabel.Text = "_______";
                    MnameLabel.Text = "_______";
                    durationLabel.Text = "_______";
                }
             
            }
            else
            {
                txtRegistrationNumber.Text = "";
                txtFees.Text = "";
                fnameLabel.Text = "_______";
                MnameLabel.Text = "_______";
                durationLabel.Text = "_______";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;

            cmd.CommandText = "select * from fees where NAID = " + txtRegistrationNumber.Text + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            if (DS.Tables[0].Rows.Count == 0)
            {

                SqlCommand cmd1 = new SqlCommand();
                cmd.Connection = Con;

                cmd1.CommandText = "insert into fees (NAID,fees) values (" + txtRegistrationNumber + ", " + txtFees + ")";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                if (MessageBox.Show("Fees Submited Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegistrationNumber.Text = "";
                    txtFees.Text = "";
                    fnameLabel.Text = "_______";
                    MnameLabel.Text = "_______";
                    durationLabel.Text = "_______";
                }
            }
            else
            {
                MessageBox.Show("Fees is AllReady Submitted.");
                txtRegistrationNumber.Text = "";
                txtFees.Text = "";
                fnameLabel.Text = "_______";
                MnameLabel.Text = "_______";
                durationLabel.Text = "_______";
            }

            
        }
    }
}
