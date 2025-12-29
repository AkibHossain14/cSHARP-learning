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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration
{
    public partial class signUP : Form
    {
        public signUP()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = idTEXT.Text.Trim();
            string pass = passTEXT.Text.Trim();
            string gender;
            string nationality = comboBox1.SelectedItem.ToString();
            string dob = dateTimePicker1.Text.Trim();

            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(nationality) || string.IsNullOrWhiteSpace(dob))
            {
                MessageBox.Show("all fields must be fullfilled", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            string connectionstring = "data source=LAPTOP-F7UNN87C\\SQLEXPRESS; database=Registration; integrated security=SSPI";
            string query = @"INSERT INTO reg (ID, Pass, Gender, Nationality, DOB) 
                 VALUES (@ID, @Pass, @Gender, @Nationality, @DOB)";

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@nationality", nationality);
                    command.Parameters.AddWithValue("@dob", dob);

                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile created successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
    
