using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace College
{
    public partial class UpgradeSemester : Form
    {
        public UpgradeSemester()
        {
            InitializeComponent();
        }

        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PROSSY\Documents\College.mdf;Integrated Security=True;Connect Timeout=30");

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Semester Update Warning!", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = "UPDATE NewAdmission SET semester = @To WHERE semester = @From";

                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@To", comboBoxTo.Text);
                    cmd.Parameters.AddWithValue("@From", comboBoxFrom.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show($"{rowsAffected} rows updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Con.Close();
                }
            }
            else
            {
                MessageBox.Show("Upgrade Cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
