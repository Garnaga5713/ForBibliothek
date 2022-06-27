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

namespace Program_for_Bibliothek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Input name";
            button1.Text = "Check";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                MessageBox.Show("Hello, admin!");


                Admin_ALL_Table_Form admin_ALL_Table_Form = new Admin_ALL_Table_Form();
                admin_ALL_Table_Form.Show();


            }
            else
            {

                try
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");
                    sqlConnection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Bibliothek_Worker WHERE FIO='" + textBox1.Text + "'", sqlConnection);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    int id_wk = 0;


                    sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");
                    sqlConnection.Open();

                    SqlCommand sql_load_combobox = new SqlCommand("select * from Bibliothek_Worker", sqlConnection);

                    SqlDataReader dataReader;

                    dataReader = sql_load_combobox.ExecuteReader();

                    while (dataReader.Read())
                    {
                        id_wk = dataReader.GetInt32(0);
                    }


                    if (dt.Rows[0][0].ToString() != null)
                    {
                        MessageBox.Show("Hello, worker!");
                         Worker_Place worker_Place = new Worker_Place(id_wk);
                         worker_Place.Show();

                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Wrong input\nTry one more time");
                }
            }


        }

      
    }
}
