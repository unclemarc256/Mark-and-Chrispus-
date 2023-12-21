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
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PROSSY\Documents\College.mdf;Integrated Security=True;Connect Timeout=30");
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String name = txtFullName.Text;
                String mname = txtMotherName.Text;
                String gender = radioButtonMale.Checked ? radioButtonMale.Text : radioButtonFemale.Text;
                String dob = dateTimePickerDOB.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String email = txtEmail.Text;
                String semester = txtSemester.Text;
                String prog = txtProgramming.Text;
                String sname = txtShoolName.Text;
                String duration = txtDuration.Text;
                String add = txtAddress.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Con;

                cmd.CommandText = "INSERT INTO NewAdmission (fname, mname, gender, dob, mobile, email, semester, prog, sname, duration, address) " +
                                  "VALUES (@name, @mname, @gender, @dob, @mobile, @email, @semester, @prog, @sname, @duration, @add)";

                // Use parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@mname", mname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@semester", semester);
                cmd.Parameters.AddWithValue("@prog", prog);
                cmd.Parameters.AddWithValue("@sname", sname);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@add", add);

                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("Data Saved. Remember the Registration ID", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtAddress.Clear();
            txtMotherName.Clear();
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;
            txtMobile.Clear();
            txtEmail.Clear();
            txtProgramming.ResetText();
            txtSemester.ResetText();
            txtShoolName.Clear();
            txtDuration.ResetText();

        }

        private void New_Admission_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Con;

                cmd.CommandText = "select max(NAID) from NewAdmission";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;  // Set the SelectCommand

                DataSet DS = new DataSet();
                DA.Fill(DS);

                object result = DS.Tables[0].Rows[0][0];

                if (result != DBNull.Value)
                {
                    Int64 abc = Convert.ToInt64(result);
                    label13.Text = (abc + 1).ToString();
                }
                else
                {
                    // Handle the case where the result is DBNull.Value
                    label13.Text = "1"; // or any default value you prefer
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
