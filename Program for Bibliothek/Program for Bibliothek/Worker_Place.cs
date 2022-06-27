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
    public partial class Worker_Place : Form
    {
        private int id_fio, id_boook, id_worker;
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = new DataSet();
        private DataSet dataSet1 = new DataSet();


        public Worker_Place(int id_work)
        {
            InitializeComponent();

            Load_ComboBox_Fio_Stud();
            Load_ComboBox_Book();

            radioButton2.Checked = true;
            id_worker = id_work;

            textBox1.Text = DateTime.Now.Date.ToShortDateString();
            textBox2.Text = "";
            textBox3.Text = DateTime.Now.Date.ToShortDateString();

            label7.Text = "Search by FIO and book\nCheck by FIO";

            radioButton1.Text = "Teacher";
            radioButton2.Text = "Student";
            textBox1.Text = "";

            label2.Text = "FIO";
            label3.Text = "Book";
            label4.Text = "Issued";
            label5.Text = "Returned";
            label6.Text = "Deadline";

            button1.Text = "ADD";
            button2.Text = "DELETE";
            button3.Text = "SEARCH";
            groupBox1.Text = "Who take book?";


        }
        #region LOAD

        private void Load_ComboBox_Fio_Stud()
        {
            comboBox1.Items.Clear();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");
            sqlConnection.Open();

            SqlCommand sql_load_combobox = new SqlCommand("select * from Student", sqlConnection);

            SqlDataReader dataReader;

            dataReader = sql_load_combobox.ExecuteReader();

            while (dataReader.Read())
            {
                string nam = dataReader.GetString(1);
                comboBox1.Items.Add(nam);
            }
            dataReader.Close();
        }

        private void Load_ComboBox_Fio_Teach()
        {
            comboBox1.Items.Clear();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");
            sqlConnection.Open();

            SqlCommand sql_load_combobox = new SqlCommand("select * from Teacher", sqlConnection);

            SqlDataReader dataReader;

            dataReader = sql_load_combobox.ExecuteReader();

            while (dataReader.Read())
            {
                string nam = dataReader.GetString(1);
                comboBox1.Items.Add(nam);
            }
            dataReader.Close();
        }

        private void Load_ComboBox_Book()
        {
            comboBox2.Items.Clear();

            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");
            sqlConnection.Open();

            SqlCommand sql_load_combobox = new SqlCommand("select * from Book", sqlConnection);

            SqlDataReader dataReader;

            dataReader = sql_load_combobox.ExecuteReader();

            while (dataReader.Read())
            {
                string nam = dataReader.GetString(1);
                comboBox2.Items.Add(nam);
            }
            dataReader.Close();
        }

        private void Load_Teacher()
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT Teacher.FIO,Book.name,Teacher_Card.issued,Teacher_Card.returned FROM Teacher_Card  INNER JOIN Teacher ON Teacher.id=Teacher_Card.id_Teacher INNER JOIN Book ON Teacher_Card.id_book=Book.id", sqlConnection);

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlDataAdapter.Fill(dataSet1, "id");
            dataGridView1.DataSource = dataSet1.Tables[0];

        }
        private void Load_Student()
        {
            
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT Student.FIO,Book.name,Student_Card.issued,Student_Card.deadline,Student_Card.returned FROM Student_Card  INNER JOIN Student ON Student.id=Student_Card.id_student INNER JOIN Book ON Student_Card.id_book=Book.id", sqlConnection);

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlDataAdapter.Fill(dataSet, "id");
            dataGridView1.DataSource = dataSet.Tables[0];

        }

        #endregion
        #region FIND
        private void find_fio_teach()
        {
            SqlCommand Search_Command = new SqlCommand($"SELECT id FROM [Teacher] WHERE FIO='{comboBox1.Text}'", sqlConnection);
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                id_fio = int.Parse(sqlDataReader.GetValue(0).ToString());
            }
            sqlDataReader.Close();
        }
        private void find_book()
        {
            SqlCommand Search_Command = new SqlCommand($"SELECT id FROM [Book] WHERE name='{comboBox2.Text}'", sqlConnection);
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                id_boook = int.Parse(sqlDataReader.GetValue(0).ToString());
            }
            sqlDataReader.Close();
        }
        private void find_fio_stud()
        {
            SqlCommand Search_Command = new SqlCommand($"SELECT id FROM [Student] WHERE FIO='{comboBox1.Text}'", sqlConnection);
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                id_fio = int.Parse(sqlDataReader.GetValue(0).ToString());
                // label1.Text = id_fio.ToString();
            }
            sqlDataReader.Close();
        }
        #endregion

        #region ADD
        private void add_teacher()
        {
            dataSet1.Clear();
            find_fio_teach();

            try
            {
                SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [Teacher_Card](id_teacher,id_bibliother_worker,id_book,issued,returned) VALUES (@id_teacher,@id_bibliother_worker,@id_book,@issued,@returned)", sqlConnection);
                ADDcommand.Parameters.AddWithValue("id_teacher", Convert.ToInt32(id_fio));
                ADDcommand.Parameters.AddWithValue("id_bibliother_worker", Convert.ToInt32(id_worker));
                ADDcommand.Parameters.AddWithValue("id_book", Convert.ToInt32(id_boook));
                ADDcommand.Parameters.AddWithValue("issued", Convert.ToDateTime(textBox1.Text));
                ADDcommand.Parameters.AddWithValue("returned", DBNull.Value);


                ADDcommand.ExecuteNonQuery();
                MessageBox.Show("Successfully added!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }


            Load_Teacher();
        }
        private void add_student()
        {
            dataSet.Clear();
            find_fio_stud();

            try
            {
                SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [Student_Card](id_student,id_bibliother_worker,id_book,issued,deadline,returned) VALUES (@id_student,@id_bibliother_worker,@id_book,@issued,@deadline,@returned)", sqlConnection);
                ADDcommand.Parameters.AddWithValue("id_student", Convert.ToInt32(id_fio));
                ADDcommand.Parameters.AddWithValue("id_bibliother_worker", Convert.ToInt32(id_worker));
                ADDcommand.Parameters.AddWithValue("id_book", Convert.ToInt32(id_boook));
                ADDcommand.Parameters.AddWithValue("issued", Convert.ToDateTime(textBox1.Text));
                ADDcommand.Parameters.AddWithValue("deadline", Convert.ToDateTime(textBox3.Text));
                ADDcommand.Parameters.AddWithValue("returned", DBNull.Value);


                ADDcommand.ExecuteNonQuery();
                MessageBox.Show("Successfully added!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }


            Load_Student();


        }
        #endregion
        private void button1_Click(object sender, EventArgs e)///ADD
        {


            find_book();

            if (radioButton2.Checked)
            {
                // find_fio_stud();
                add_student();
            }
            else
            {
                //find_fio_teach();
                add_teacher();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            

            textBox1.Text = DateTime.Now.Date.ToShortDateString();
            textBox3.Text = DateTime.Now.Date.ToShortDateString();

        }//add
        private void button2_Click(object sender, EventArgs e)/////  update
        {

            find_book();

            try
            {
                if (radioButton2.Checked)
                {
                    // find_fio_stud();
                    update_student();
                }
                else
                {
                    //find_fio_teach();
                    update_teacher();
                }
            }
            catch (Exception e11)
            { MessageBox.Show(e11.Message); }




            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
           
            textBox1.Text = DateTime.Now.Date.ToShortDateString();
            textBox3.Text = DateTime.Now.Date.ToShortDateString();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Text = DateTime.Now.Date.ToShortDateString();
            textBox2.Text = "";
            textBox3.Text = DateTime.Now.Date.ToShortDateString();

            dataSet.Clear();
            dataSet1.Clear();

            find_book();

            if (radioButton2.Checked)
            {
                find_fio_stud();
                SqlCommand Search_Command = new SqlCommand($"SELECT id_book, id,id_student,issued,deadline,returned FROM [Student_Card] WHERE id_book='{id_boook}' AND id_student='{id_fio}'", sqlConnection);
                SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    label1.Text = sqlDataReader.GetValue(1).ToString();

                    textBox1.Text = Convert.ToDateTime(sqlDataReader.GetValue(3)).ToString();
                    textBox3.Text = Convert.ToDateTime(sqlDataReader.GetValue(4)).ToString();

                    if ((sqlDataReader.GetValue(5) is DBNull))
                        textBox2.Text = "";
                    else
                        textBox2.Text = Convert.ToDateTime(sqlDataReader.GetValue(5)).ToString();

                }
                MessageBox.Show("Searching end");
                sqlDataReader.Close();
                Load_Student();
            }
            else
            {
                find_fio_teach();
                SqlCommand Search_Command = new SqlCommand($"SELECT id_book, id,id_teacher,issued,returned FROM [Teacher_Card] WHERE id_book='{id_boook}' AND id_teacher='{id_fio}'", sqlConnection);
                SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

                while (sqlDataReader.Read())
                {

                    label1.Text = sqlDataReader.GetValue(1).ToString();

                    textBox1.Text = Convert.ToDateTime(sqlDataReader.GetValue(3)).ToString();

                    if ((sqlDataReader.GetValue(4) is DBNull))
                        textBox2.Text = "";
                    else
                        textBox2.Text = Convert.ToDateTime(sqlDataReader.GetValue(4)).ToString();
                }
                MessageBox.Show("Searching end");
                sqlDataReader.Close();
                Load_Teacher();
            }




        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.Date.ToShortDateString();
            textBox2.Text = "";
            textBox3.Text = DateTime.Now.Date.ToShortDateString();
            Load_ComboBox_Fio_Teach();

            dataSet1.Clear();

            Load_Teacher();
            label6.Hide();
            textBox3.Hide();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.Date.ToShortDateString();
            textBox2.Text = "";
            textBox3.Text = DateTime.Now.Date.ToShortDateString();
            label6.Show();
            textBox3.Show();

            Load_ComboBox_Fio_Stud();

            dataSet.Clear();

            Load_Student();
        }

        #region UPDATE

        private void update_student()
        {
            dataSet.Clear();


            DateTime issued = Convert.ToDateTime(textBox1.Text);
            string issued_Date = issued.ToString("yyyy-MM-dd HH:mm:ss.fff");


            DateTime returned = Convert.ToDateTime(textBox2.Text);
            string returned_Date = returned.ToString("yyyy-MM-dd");


            DateTime deadline = Convert.ToDateTime(textBox3.Text);
            string deadline_Date = deadline.ToString("yyyy-MM-dd HH:mm:ss.fff");


            SqlCommand ADDcommand = new SqlCommand($"UPDATE  [Student_Card] SET id_student='" + Convert.ToInt32(id_fio) + "', id_bibliother_worker='" + Convert.ToInt32(id_worker) + "', id_book='" + Convert.ToInt32(id_boook) + "',issued='" + issued_Date + "',deadline='" + deadline_Date + "',returned='" + returned_Date + "' WHERE id='" + Convert.ToInt32(label1.Text) + "'", sqlConnection);


            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully update!");
            Load_Student();

        }
        private void update_teacher()
        {
            dataSet1.Clear();
            try
            {
                DateTime issued = Convert.ToDateTime(textBox1.Text);
                string issued_Date = issued.ToString("yyyy-MM-dd HH:mm:ss.fff");


                DateTime returned = Convert.ToDateTime(textBox2.Text);
                string returned_Date = returned.ToString("yyyy-MM-dd ");



                SqlCommand ADDcommand = new SqlCommand($"UPDATE  [Teacher_Card] SET id_teacher='" + Convert.ToInt32(id_fio) + "', id_bibliother_worker='" + Convert.ToInt32(id_worker) + "', id_book='" + Convert.ToInt32(id_boook) + "',issued='" + issued_Date + "',returned='" + returned_Date + "'WHERE id='" + Convert.ToInt32(label1.Text) + "'", sqlConnection);

                ADDcommand.ExecuteNonQuery();
                MessageBox.Show("Successfully update!");


            }
            catch (Exception e) { MessageBox.Show("Can't do this\n" + e.Message.ToString()); }

            Load_Teacher();

        }
        #endregion
    }
}
