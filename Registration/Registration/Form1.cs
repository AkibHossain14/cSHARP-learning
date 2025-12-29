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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            signUP s = new signUP();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idTextBox.Text = " ";
            passTextBox.Text = " ";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = idTextBox.Text;
            string pass = passTextBox.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("all fields must be fullfilled", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            string connectionstring = "data source=LAPTOP-F7UNN87C\\SQLEXPRESS; database=Registration; integrated security=SSPI";
            string query = "SELECT COUNT(*) FROM reg WHERE Id = @Id AND Pass = @Pass";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Pass", pass);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form3 f3 = new Form3(int.Parse(id));
                        f3.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Id or Name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }




            }
        }
    }
}
