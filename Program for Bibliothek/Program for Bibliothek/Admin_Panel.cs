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
    public partial class Admin_Panel : Form
    {
        private int TabelNum = 0;
        private string TabelName = "";
        private string AdditionallyTableName = "";
        private string AdditionallyTable_First_Param = "";
        private string First_Param = "";
        private string Second_Param = "";
        private string Third_Param = "";
        private SqlConnection SqlConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = new DataSet();

        public Admin_Panel(int i)
        {
            InitializeComponent();
            button1.Text = "ADD";
            button2.Text = "DELETE";
            button3.Text = "SEARCH";
            button4.Text = "UPDATE";
            label1.Text = "ID";
            TabelNum = i;
            FirstLoad(i);

            toolTip1.SetToolTip(button1, "Insert all empty fields exept ID");
            toolTip1.SetToolTip(button2, "Deleting by ID\nAt first make Search");
            toolTip1.SetToolTip(button4, "To update make Search and input new data");

        }


        #region LOAD
        private void FirstLoad(int cas)
        {
            switch (cas)
            {
                case 1:
                    {
                        label3.Hide();
                        comboBox3.Hide();

                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "FIO";
                        TabelName = "Bibliothek_Worker";
                        First_Param = "FIO";
                        LoadData();
                        toolTip1.SetToolTip(button3, "Search by ID or FIO");

                        label2.Location = new Point(50, 35);
                        textBox2.Location = new Point(30, 55);
                        break;

                    }
                case 2:
                    {
                        label3.Hide();
                        comboBox3.Hide();

                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "FIO";
                        TabelName = "Author";
                        First_Param = "FIO";
                        LoadData();
                        toolTip1.SetToolTip(button3, "Search by ID or FIO");
                        label2.Location = new Point(50, 35);
                        textBox2.Location = new Point(30, 55);
                        break;
                    }
                case 3:
                    {
                        label3.Hide();
                        comboBox3.Hide();

                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "Name";
                        TabelName = "Faculty";
                        First_Param = "name";
                        LoadData();
                        toolTip1.SetToolTip(button3, "Search by ID or Name");
                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        break;
                    }
                case 4:
                    {
                        label3.Hide();
                        comboBox3.Hide();

                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "Name";
                        TabelName = "Publish";
                        First_Param = "name";
                        LoadData();
                        toolTip1.SetToolTip(button3, "Search by ID or Name");
                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        break;
                    }
                case 5:
                    {
                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "FIO";
                        label3.Text = "Faculty";
                        TabelName = "Teacher";
                        AdditionallyTableName = "Faculty";
                        AdditionallyTable_First_Param = "name";
                        First_Param = "FIO";
                        Second_Param = "id_faculty";
                        LoadData();
                        LoadComboBox("Faculty", comboBox3);
                        toolTip1.SetToolTip(button3, "Search by  ID or Faculty and FIO ");
                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        label3.Location = new Point(50, 80);
                        comboBox3.Location = new Point(30, 100);
                        break;
                    }
                case 6:
                    {
                        comboBox3.Width = 150;

                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "FIO";
                        label3.Text = "Group";
                        TabelName = "Student";
                        AdditionallyTableName = "Group1";
                        AdditionallyTable_First_Param = "name";
                        First_Param = "FIO";
                        Second_Param = "id_group";
                        LoadData();
                        LoadComboBox_Stud("Group1");
                        toolTip1.SetToolTip(button3, "Search by  ID or Group and FIO");
                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        label3.Location = new Point(50, 80);
                        comboBox3.Location = new Point(30, 100);
                        break;
                    }
                case 7:
                    {
                        label4.Hide();
                        comboBox4.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "Name";
                        label3.Text = "Faculty";
                        TabelName = "Special";
                        AdditionallyTableName = "Faculty";
                        AdditionallyTable_First_Param = "name";
                        First_Param = "name";
                        Second_Param = "id_faculty";
                        LoadData();
                        LoadComboBox("Faculty", comboBox3);

                        toolTip1.SetToolTip(button3, "Search by  ID or Faculty and Name");

                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        label3.Location = new Point(50, 80);
                        comboBox3.Location = new Point(30, 100);
                        break;
                    }
                case 8:
                    {
                        label2.Hide();
                        textBox2.Hide();

                        label5.Hide();
                        textBox5.Hide();

                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label3.Text = "Author";
                        label4.Text = "Book";
                        TabelName = "Author_Book1";
                        First_Param = "id_autor";
                        Second_Param = "id_book";

                        LoadData();

                        LoadComboBox("Author", comboBox3);

                        LoadComboBox("Book", comboBox4);


                        toolTip1.SetToolTip(button3, "Search by  ID or Author and Book");

                        
                        label3.Location = new Point(50, 30);
                        comboBox3.Location = new Point(30, 55);
                        label4.Location = new Point(50, 80);
                        comboBox4.Location = new Point(30, 100);
                        break;
                    }
                case 9:
                    {
                        label4.Hide();
                        comboBox4.Hide();


                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "Name";
                        label3.Text = "Publish";
                        TabelName = "Book";
                        AdditionallyTableName = "Publish";
                        AdditionallyTable_First_Param = "name";
                        First_Param = "name";
                        Second_Param = "id_publish";
                        Third_Param = "year_date";
                        label5.Text = "Year";
                        LoadData();
                        LoadComboBox("Publish", comboBox3);

                        toolTip1.SetToolTip(button3, "Search by  ID or Name, Year and Publish");


                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        label3.Location = new Point(50, 80);
                        comboBox3.Location = new Point(30, 100);
                        label5.Location = new Point(50, 120);
                        textBox5.Location = new Point(30, 140);



                        break;
                    }
                case 10:
                    {
                        label4.Hide();
                        comboBox4.Hide();


                        label6.Hide();
                        comboBox6.Hide();

                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "Specificator";
                        label3.Text = "Special";
                        TabelName = "Group1";
                        AdditionallyTableName = "Special";
                        AdditionallyTable_First_Param = "name";
                        First_Param = "specificator";
                        Second_Param = "id_special";
                        Third_Param = "come_year";
                        label5.Text = "Year";
                        LoadData();
                        LoadComboBox("Special", comboBox3);

                        toolTip1.SetToolTip(button3, "Search by  ID or Name, Year and Publish");

                        label2.Location = new Point(50, 30);
                        textBox2.Location = new Point(30, 55);
                        label3.Location = new Point(50, 80);
                        comboBox3.Location = new Point(30, 100);
                        label5.Location = new Point(50, 120);
                        textBox5.Location = new Point(30, 140);
                        break;
                    }
                case 11:
                    {



                        label7.Hide();
                        textBox7.Hide();

                        label2.Text = "Issued";
                        label5.Text = "Returned";
                        label3.Text = "Teacher FIO";
                        label4.Text = "Bibliothek Worker";
                        label6.Text = "Book";
                        TabelName = "Teacher_card";
                        LoadData();
                        LoadComboBox("Teacher", comboBox3);
                        LoadComboBox("Bibliothek_Worker", comboBox4);
                        LoadComboBox("Book", comboBox6);

                        textBox2.Text = DateTime.Now.ToShortDateString();
                        toolTip1.SetToolTip(button3, "Search by  FIO and Book");

                        


                        label3.Location = new Point(50, 30);
                        comboBox3.Location = new Point(30, 55);

                        label6.Location = new Point(50, 80);
                        comboBox6.Location = new Point(30, 100);

                        label4.Location = new Point(30, 130);
                        comboBox4.Location = new Point(30, 150);

                        label2.Location = new Point(45, 180);
                        textBox2.Location = new Point(30, 200);

                        label5.Location = new Point(40, 230);
                        textBox5.Location = new Point(30, 250);

                        break;
                    }
                case 12:
                    {

                        label2.Text = "Issued";
                        label5.Text = "Returned";
                        label3.Text = "Student FIO";
                        label4.Text = "Bibliothek Worker";
                        label6.Text = "Book";
                        label7.Text = "Deadline";
                        TabelName = "Student_card";

                        LoadData();
                        LoadComboBox("Student", comboBox3);
                        LoadComboBox("Bibliothek_Worker", comboBox4);
                        LoadComboBox("Book", comboBox6);

                        textBox7.Text = textBox2.Text = DateTime.Now.ToShortDateString();

                        toolTip1.SetToolTip(button3, "Search by  FIO and Book");


                        label3.Location = new Point(50, 30);
                        comboBox3.Location = new Point(30, 55);

                        label6.Location = new Point(50, 80);
                        comboBox6.Location = new Point(30, 100);

                        label4.Location = new Point(30, 130);
                        comboBox4.Location = new Point(30, 150);

                        label2.Location = new Point(45, 180);
                        textBox2.Location = new Point(30, 200);

                        label5.Location = new Point(40, 230);
                        textBox5.Location = new Point(30, 250);


                        label7.Location = new Point(40, 280);
                        textBox7.Location = new Point(30, 300);

                        break;
                    }
            }


        }

        private void LoadData()
        {
            dataSet.Clear();

            SqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");

            SqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM " + TabelName + "", SqlConnection);

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            sqlDataAdapter.Fill(dataSet, "id");

            dataGridView1.DataSource = dataSet.Tables[0];

        }
        private void LoadComboBox(string ComboTable, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            SqlCommand sql_load_combobox = new SqlCommand("select * from " + ComboTable + "", SqlConnection);

            SqlDataReader dataReader = sql_load_combobox.ExecuteReader();

            while (dataReader.Read())
            {
                string nam = dataReader.GetString(1);
                comboBox.Items.Add(nam);
            }
            dataReader.Close();
        }
        private void LoadComboBox_Stud(string ComboTable)
        {
            comboBox3.Items.Clear();
            comboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            SqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Univer_bibliotek_cards;Integrated Security=True;");
            SqlConnection.Open();

            SqlCommand sql_load_combobox = new SqlCommand("SELECT Special.name, Group1.come_year, Group1.specificator FROM Group1 RIGHT JOIN Special ON Group1.id_special = Special.id", SqlConnection);

            SqlDataReader dataReader;

            dataReader = sql_load_combobox.ExecuteReader();

            while (dataReader.Read())
            {
                string nam = dataReader.GetString(0);
                nam += "-";
                nam += (dataReader.GetInt32(1)).ToString();
                nam += "-";
                nam += (dataReader.GetInt32(2)).ToString();
                comboBox3.Items.Add(nam);
            }
            dataReader.Close();
        }


        #endregion


        #region ADD
        private void ADD_1param()
        {

            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [" + TabelName + "](" + First_Param + ") VALUES (@first_param)", SqlConnection);

            ADDcommand.Parameters.AddWithValue("first_param", textBox2.Text);

            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");

        }
        private void ADD_2param()
        {

            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [" + TabelName + "](" + First_Param + "," + Second_Param + ") VALUES (@first_param,@second_param)", SqlConnection);

            ADDcommand.Parameters.AddWithValue("first_param", textBox2.Text);
            ADDcommand.Parameters.AddWithValue("second_param", SearchComboBoxID());

            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");

        }
        private void ADD_2_param()
        {
            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [" + TabelName + "](" + First_Param + "," + Second_Param + ") VALUES (@first_param,@second_param)", SqlConnection);

            ADDcommand.Parameters.AddWithValue("first_param", Convert.ToInt32(SEARCH_Combo1_id("Author", "FIO", comboBox3)));
            ADDcommand.Parameters.AddWithValue("second_param", Convert.ToInt32(SEARCH_Combo1_id("Book", "name", comboBox4)));

            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");

        }
        private void ADD_3param()
        {
            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [" + TabelName + "](" + First_Param + "," + Second_Param + "," + Third_Param + ") VALUES (@first_param,@second_param,@third_param)", SqlConnection);

            ADDcommand.Parameters.AddWithValue("first_param", textBox2.Text);
            ADDcommand.Parameters.AddWithValue("second_param", SearchComboBoxID());
            ADDcommand.Parameters.AddWithValue("third_param", Convert.ToInt32(textBox5.Text));

            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");
        }
        private void ADD_5param()
        {

            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [Teacher_Card](id_teacher,id_bibliother_worker,id_book,issued,returned) VALUES (@id_teacher,@id_bibliother_worker,@id_book,@issued,@returned)", SqlConnection);
            ADDcommand.Parameters.AddWithValue("id_teacher", SEARCH_Combo1_id("Teacher", "FIO", comboBox3));
            ADDcommand.Parameters.AddWithValue("id_bibliother_worker", SEARCH_Combo1_id("Bibliothek_Worker", "FIO", comboBox4));
            ADDcommand.Parameters.AddWithValue("id_book", SEARCH_Combo1_id("Book", "name", comboBox6));
            ADDcommand.Parameters.AddWithValue("issued", Convert.ToDateTime(textBox2.Text));
            ADDcommand.Parameters.AddWithValue("returned", DBNull.Value);


            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");
        }
        private void ADD_6param()
        {

            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [Student_Card](id_student,id_bibliother_worker,id_book,issued,returned,deadline) VALUES (@id_student,@id_bibliother_worker,@id_book,@issued,@returned,@deadline)", SqlConnection);
            ADDcommand.Parameters.AddWithValue("id_student", SEARCH_Combo1_id("Student", "FIO", comboBox3));
            ADDcommand.Parameters.AddWithValue("id_bibliother_worker", SEARCH_Combo1_id("Bibliothek_Worker", "FIO", comboBox4));
            ADDcommand.Parameters.AddWithValue("id_book", SEARCH_Combo1_id("Book", "name", comboBox6));
            ADDcommand.Parameters.AddWithValue("issued", Convert.ToDateTime(textBox2.Text));
            ADDcommand.Parameters.AddWithValue("returned", DBNull.Value);
            ADDcommand.Parameters.AddWithValue("deadline", Convert.ToDateTime(textBox7.Text));


            ADDcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully added!");
        }
        private void ADD_Stud()
        {


            SqlCommand ADDcommand = new SqlCommand($"INSERT INTO [" + TabelName + "](" + First_Param + "," + Second_Param + ") VALUES (@first_param,@second_param)", SqlConnection);

            ADDcommand.Parameters.AddWithValue("first_param", textBox2.Text);
            ADDcommand.Parameters.AddWithValue("second_param", SearchComboBoxIDStud());

            ADDcommand.ExecuteNonQuery();

            MessageBox.Show("Successfully added!");
        }

        #endregion


        #region DELETE

        private void DELETE_1param()
        {
            SqlCommand DELETEcommand = new SqlCommand($"DELETE FROM [" + TabelName + "] WHERE  id=@id", SqlConnection);

            DELETEcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));

            DELETEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully deleted!");
        }

        #endregion


        #region SEARCH
        private int SearchComboBoxID()
        {
            int qwe = 0;

            SqlCommand Search_Command = new SqlCommand("SELECT id FROM [" + AdditionallyTableName + "] WHERE " + AdditionallyTable_First_Param + "=@first_param", SqlConnection);
            Search_Command.Parameters.AddWithValue("@first_param", comboBox3.Text.ToString());
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                qwe = int.Parse(sqlDataReader.GetValue(0).ToString());
            }
            sqlDataReader.Close();

            return qwe;

        }
        private void SEARCH_1param()
        {
            SqlCommand SEARCHcommand = new SqlCommand($"SELECT id," + First_Param + " FROM [" + TabelName + "] WHERE " + First_Param + "=@first_param OR id=@id", SqlConnection);

            if (textBox2.Text.Length > 0)
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", textBox2.Text.ToString());
                SEARCHcommand.Parameters.AddWithValue("id", 0);
            }
            else
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", DBNull.Value);
                SEARCHcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            }


            SqlDataReader sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                textBox1.Text = sqlDataReader.GetValue(0).ToString();
                textBox2.Text = sqlDataReader.GetValue(1).ToString();
            }
            MessageBox.Show("Searching end");
            sqlDataReader.Close();
        }
        private void SEARCH_2param()
        {
            SqlCommand SEARCHcommand = new SqlCommand($"SELECT " + TabelName + ".id," + TabelName + "." + First_Param + " FROM [" + TabelName + "] WHERE " + First_Param + "=@first_param OR id=@id", SqlConnection);


            if (textBox2.Text.Length > 0)
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", textBox2.Text.ToString());
                SEARCHcommand.Parameters.AddWithValue("id", 0);
            }
            else
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", DBNull.Value);
                SEARCHcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            }

            SqlDataReader sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                textBox1.Text = sqlDataReader.GetValue(0).ToString();
                textBox2.Text = sqlDataReader.GetValue(1).ToString();
            }
            sqlDataReader.Close();


            SEARCHcommand = new SqlCommand($"SELECT " + AdditionallyTableName + "." + AdditionallyTable_First_Param + " FROM [" + TabelName + "] INNER JOIN " + AdditionallyTableName + " ON " + TabelName + "." + Second_Param + " = " + AdditionallyTableName + ".id", SqlConnection);
            sqlDataReader = SEARCHcommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox3.Text = sqlDataReader.GetValue(0).ToString();
            }
            sqlDataReader.Close();

            MessageBox.Show("Searching end");

        }
        private int SEARCH_Combo1_id(string TableName, string Param1, ComboBox comboBox)
        {
            int qwe = 0;

            SqlCommand Search_Command = new SqlCommand("SELECT id FROM [" + TableName + "] WHERE " + Param1 + "=@first_param", SqlConnection);
            Search_Command.Parameters.AddWithValue("@first_param", comboBox.Text.ToString());
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                qwe = int.Parse(sqlDataReader.GetValue(0).ToString());
            }
            sqlDataReader.Close();

            return qwe;

        }
        private void SEARCH_2_param()
        {
            SqlCommand SEARCHcommand = new SqlCommand($"SELECT " + TabelName + ".id," + TabelName + "." + First_Param + " FROM [" + TabelName + "] WHERE " + First_Param + "=@first_param OR id=@id", SqlConnection);

            if (textBox2.Text.Length > 0)
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", textBox2.Text.ToString());
                SEARCHcommand.Parameters.AddWithValue("id", 0);
            }
            else
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", DBNull.Value);
                SEARCHcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            }


            SqlDataReader sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                textBox1.Text = sqlDataReader.GetValue(0).ToString();
            }
            sqlDataReader.Close();




            SEARCHcommand = new SqlCommand($"SELECT Author.FIO,Book.name FROM Author INNER JOIN Author_Book1 ON Author_Book1.id_autor=Author.id INNER JOIN Book ON Author_Book1.id_book=Book.id WHERE Author_Book1.id=@autbkid", SqlConnection);
            SEARCHcommand.Parameters.AddWithValue("autbkid", Convert.ToInt32(textBox1.Text));

            sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                comboBox3.Text = sqlDataReader.GetValue(0).ToString();
                comboBox4.Text = sqlDataReader.GetValue(1).ToString();

            }

            sqlDataReader.Close();
            MessageBox.Show("Searching end");


        }
        private void SEARCH_3param()
        {
            SqlCommand SEARCHcommand = new SqlCommand($"SELECT " + TabelName + ".id," + TabelName + "." + First_Param + ", " + TabelName + "." + Third_Param + " FROM [" + TabelName + "] WHERE " + First_Param + "=@first_param OR id=@id", SqlConnection);


            if (textBox2.Text.Length > 0)
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", textBox2.Text.ToString());
                SEARCHcommand.Parameters.AddWithValue("id", 0);
            }
            else
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", DBNull.Value);
                SEARCHcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            }

            SqlDataReader sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                textBox1.Text = sqlDataReader.GetValue(0).ToString();
                textBox2.Text = sqlDataReader.GetValue(1).ToString();
                textBox5.Text = sqlDataReader.GetValue(2).ToString();
            }
            sqlDataReader.Close();


            SEARCHcommand = new SqlCommand($"SELECT " + AdditionallyTableName + "." + AdditionallyTable_First_Param + " FROM [" + TabelName + "] INNER JOIN " + AdditionallyTableName + " ON " + TabelName + "." + Second_Param + " = " + AdditionallyTableName + ".id", SqlConnection);
            sqlDataReader = SEARCHcommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox3.Text = sqlDataReader.GetValue(0).ToString();
            }
            sqlDataReader.Close();

            MessageBox.Show("Searching end");

        }

        private void SEARCH_5param()
        {
            int idd_work = 0;
            SqlCommand Search_Command = new SqlCommand($"SELECT id_book, id,id_teacher,issued,returned,id_bibliother_worker FROM [Teacher_Card] WHERE id_book='{SEARCH_Combo1_id("Book", "name", comboBox6)}' AND id_teacher='{SEARCH_Combo1_id("Teacher", "FIO", comboBox3)}'", SqlConnection);
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {

                textBox1.Text = sqlDataReader.GetValue(1).ToString();

                textBox2.Text = Convert.ToDateTime(sqlDataReader.GetValue(3)).ToString();
                idd_work = int.Parse(sqlDataReader.GetValue(5).ToString());

                if ((sqlDataReader.GetValue(4) is DBNull))
                    textBox5.Text = "";
                else
                    textBox5.Text = Convert.ToDateTime(sqlDataReader.GetValue(4)).ToString();


            }
            sqlDataReader.Close();

            SqlCommand SEARCHcommand = new SqlCommand($"SELECT FIO FROM [Bibliothek_Worker] WHERE id=" + idd_work + " ", SqlConnection);
            sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                comboBox4.Text = sqlDataReader.GetValue(0).ToString();
            }
            MessageBox.Show("Searching end");
            sqlDataReader.Close();

        }

        private void SEARCH_6param()
        {
            int idd_work = 0;
            SqlCommand Search_Command = new SqlCommand($"SELECT id_book, id,id_student,issued,returned,id_bibliother_worker,deadline FROM [Student_Card] WHERE id_book='{SEARCH_Combo1_id("Book", "name", comboBox6)}' AND id_student='{SEARCH_Combo1_id("Student", "FIO", comboBox3)}'", SqlConnection);
            SqlDataReader sqlDataReader = Search_Command.ExecuteReader();

            while (sqlDataReader.Read())
            {

                textBox1.Text = sqlDataReader.GetValue(1).ToString();

                textBox2.Text = Convert.ToDateTime(sqlDataReader.GetValue(3)).ToString();
                idd_work = int.Parse(sqlDataReader.GetValue(5).ToString());


                textBox7.Text = Convert.ToDateTime(sqlDataReader.GetValue(6)).ToString();

                if ((sqlDataReader.GetValue(4) is DBNull))
                    textBox5.Text = "";
                else
                    textBox5.Text = Convert.ToDateTime(sqlDataReader.GetValue(4)).ToString();


            }
            sqlDataReader.Close();

            SqlCommand SEARCHcommand = new SqlCommand($"SELECT FIO FROM [Bibliothek_Worker] WHERE id=" + idd_work + " ", SqlConnection);
            sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                comboBox4.Text = sqlDataReader.GetValue(0).ToString();
            }
            MessageBox.Show("Searching end");
            sqlDataReader.Close();

        }

        private int SearchComboBoxIDStud()
        {
            string[] stud_group_id = comboBox3.Text.Split('-');
            int gr_id = 0;

            SqlCommand SEARCHcommand = new SqlCommand($"SELECT Group1.id FROM Group1 INNER JOIN Special ON Group1.id_special=Special.id AND come_year=" + Convert.ToInt32(stud_group_id[1]) + " AND specificator=" + Convert.ToInt32(stud_group_id[2]) + " AND Special.name=@specname", SqlConnection);
            SEARCHcommand.Parameters.AddWithValue("specname", stud_group_id[0].ToString());
            SqlDataReader sqlDataReader = SEARCHcommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                gr_id = Convert.ToInt32(sqlDataReader.GetValue(0).ToString());
            }
            sqlDataReader.Close();
            return gr_id;
        }


        private void Search_Stud()
        {
            SqlCommand SEARCHcommand = new SqlCommand($"SELECT " + TabelName + ".id," + TabelName + "." + First_Param + " FROM [" + TabelName + "] WHERE " + First_Param + "=@first_param OR id=@id", SqlConnection);

            if (textBox2.Text.Length > 0)
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", textBox2.Text.ToString());
                SEARCHcommand.Parameters.AddWithValue("id", 0);
            }
            else
            {
                SEARCHcommand.Parameters.AddWithValue("first_param", DBNull.Value);
                SEARCHcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            }


            SqlDataReader sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                textBox1.Text = sqlDataReader.GetValue(0).ToString();
                textBox2.Text = sqlDataReader.GetValue(1).ToString();
            }
            sqlDataReader.Close();


            SEARCHcommand = new SqlCommand($"SELECT  Special.name, Group1.come_year, Group1.specificator FROM Group1 INNER JOIN Special ON Group1.id_special = Special.id INNER JOIN Student on Student.id_group=Group1.id AND Student.id=@studid", SqlConnection);
            SEARCHcommand.Parameters.AddWithValue("studid", Convert.ToInt32(textBox1.Text));

            sqlDataReader = SEARCHcommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                string nam = sqlDataReader.GetString(0);
                nam += "-";
                nam += (sqlDataReader.GetInt32(1)).ToString();
                nam += "-";
                nam += (sqlDataReader.GetInt32(2)).ToString();
                comboBox3.Text = nam;
            }

            sqlDataReader.Close();
            MessageBox.Show("Searching end");

        }
        #endregion


        #region UPDATE
        private void UPDATE_1param()
        {
            SqlCommand UPDATEcommand = new SqlCommand($"UPDATE  " + TabelName + " SET  " + First_Param + "=@first_param WHERE  id=" + Convert.ToInt32(textBox1.Text) + "  ", SqlConnection);
            UPDATEcommand.Parameters.AddWithValue("first_param", textBox2.Text);

            UPDATEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully update!");

        }
        private void UPDATE_2param()
        {
            SqlCommand UPDATEcommand = new SqlCommand($"UPDATE  " + TabelName + " SET  " + First_Param + "=@first_param, " + Second_Param + "=@second_param WHERE  id=" + Convert.ToInt32(textBox1.Text) + "  ", SqlConnection);
            UPDATEcommand.Parameters.AddWithValue("first_param", textBox2.Text);
            UPDATEcommand.Parameters.AddWithValue("second_param", SearchComboBoxID());

            UPDATEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully update!");

        }
        private void UPDATE_2_param()
        {
            SqlCommand UPDATEcommand = new SqlCommand($"UPDATE  [" + TabelName + "] SET " + First_Param + "=@first_param," + Second_Param + "=@second_param WHERE id=@id", SqlConnection);

            UPDATEcommand.Parameters.AddWithValue("first_param", Convert.ToInt32(SEARCH_Combo1_id("Author", "FIO", comboBox3)));
            UPDATEcommand.Parameters.AddWithValue("second_param", Convert.ToInt32(SEARCH_Combo1_id("Book", "name", comboBox4)));
            UPDATEcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            UPDATEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully updated!");
        }
        private void UPDATE_3param()
        {
            SqlCommand UPDATEcommand = new SqlCommand($"UPDATE  " + TabelName + " SET  " + First_Param + "=@first_param, " + Second_Param + "=@second_param, " + Third_Param + "=@third_param WHERE  id=" + Convert.ToInt32(textBox1.Text) + "  ", SqlConnection);
            UPDATEcommand.Parameters.AddWithValue("first_param", textBox2.Text);
            UPDATEcommand.Parameters.AddWithValue("second_param", SearchComboBoxID());
            UPDATEcommand.Parameters.AddWithValue("third_param", Convert.ToInt32(textBox5.Text));

            UPDATEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully update!");
        }
        private void UPDATE_5param()
        {
            SqlCommand UPDATEcommand = new SqlCommand($"UPDATE  [Teacher_Card] SET id_teacher=@id_teacher,id_bibliother_worker=@id_bibliother_worker,id_book=@id_book,issued=@issued,returned=@returned   WHERE id=@id", SqlConnection);
            UPDATEcommand.Parameters.AddWithValue("id_teacher", SEARCH_Combo1_id("Teacher", "FIO", comboBox3));
            UPDATEcommand.Parameters.AddWithValue("id_bibliother_worker", SEARCH_Combo1_id("Bibliothek_Worker", "FIO", comboBox4));
            UPDATEcommand.Parameters.AddWithValue("id_book", SEARCH_Combo1_id("Book", "name", comboBox6));
            UPDATEcommand.Parameters.AddWithValue("issued", Convert.ToDateTime(textBox2.Text));
            UPDATEcommand.Parameters.AddWithValue("returned", Convert.ToDateTime(textBox5.Text));
            UPDATEcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));


            UPDATEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully updated!");
        }
        private void UPDATE_6param()
        {
            SqlCommand UPDATEcommand = new SqlCommand($"UPDATE  [Student_Card] SET id_student=@id_student,id_bibliother_worker=@id_bibliother_worker,id_book=@id_book,issued=@issued,returned=@returned, deadline=@deadline   WHERE id=@id", SqlConnection);
            UPDATEcommand.Parameters.AddWithValue("id_student", SEARCH_Combo1_id("Student", "FIO", comboBox3));
            UPDATEcommand.Parameters.AddWithValue("id_bibliother_worker", SEARCH_Combo1_id("Bibliothek_Worker", "FIO", comboBox4));
            UPDATEcommand.Parameters.AddWithValue("id_book", SEARCH_Combo1_id("Book", "name", comboBox6));
            UPDATEcommand.Parameters.AddWithValue("issued", Convert.ToDateTime(textBox2.Text));
            UPDATEcommand.Parameters.AddWithValue("returned", Convert.ToDateTime(textBox5.Text));
            UPDATEcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));
            UPDATEcommand.Parameters.AddWithValue("deadline", Convert.ToDateTime(textBox7.Text));


            UPDATEcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully updated!");
        }
        private void Update_Stud()
        {
            SqlCommand ADDcommand = new SqlCommand($"UPDATE  [" + TabelName + "] SET " + First_Param + "=@first_param," + Second_Param + "=@second_param WHERE id=@id", SqlConnection);

            ADDcommand.Parameters.AddWithValue("first_param", textBox2.Text);
            ADDcommand.Parameters.AddWithValue("second_param", SearchComboBoxIDStud());
            ADDcommand.Parameters.AddWithValue("id", Convert.ToInt32(textBox1.Text));

            ADDcommand.ExecuteNonQuery();

            MessageBox.Show("Successfully added!");
            LoadData();
        }
        #endregion

        private void Clear_Data()
        {
            textBox1.Text = textBox2.Text = textBox5.Text = textBox7.Text = comboBox3.Text = comboBox4.Text = comboBox6.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)//ADD
        {

            try
            {
                switch (TabelNum)
                {
                    case 1: { ADD_1param(); break; }
                    case 2: { ADD_1param(); break; }
                    case 3: { ADD_1param(); break; }
                    case 4: { ADD_1param(); break; }
                    case 5: { ADD_2param(); break; }
                    case 6: { ADD_Stud(); break; }
                    case 7: { ADD_2param(); break; }
                    case 8: { ADD_2_param(); break; }
                    case 9: { ADD_3param(); break; }
                    case 10: { ADD_3param(); break; }
                    case 11: { ADD_5param(); break; }
                    case 12: { ADD_6param(); break; }
                }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            LoadData();

            Clear_Data();
        }

        private void button2_Click(object sender, EventArgs e)//DELETE
        {
            try
            {
                switch (TabelNum)
                {
                    case 1: { DELETE_1param(); break; }
                    case 2: { DELETE_1param(); break; }
                    case 3: { DELETE_1param(); break; }
                    case 4: { DELETE_1param(); break; }
                    case 5: { DELETE_1param(); break; }
                    case 6: { DELETE_1param(); break; }
                    case 7: { DELETE_1param(); break; }
                    case 8: { DELETE_1param(); break; }
                    case 9: { DELETE_1param(); break; }
                    case 10: { DELETE_1param(); break; }
                    case 11: { DELETE_1param(); break; }
                    case 12: { DELETE_1param(); break; }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            LoadData();

            Clear_Data();
        }

        private void button3_Click(object sender, EventArgs e)//SEARCH
        {

            try
            {
                switch (TabelNum)
                {
                    case 1: { SEARCH_1param(); break; }
                    case 2: { SEARCH_1param(); break; }
                    case 3: { SEARCH_1param(); break; }
                    case 4: { SEARCH_1param(); break; }
                    case 5: { SEARCH_2param(); break; }
                    case 6: { Search_Stud(); break; }
                    case 7: { SEARCH_2param(); break; }
                    case 8: { SEARCH_2_param(); break; }
                    case 9: { SEARCH_3param(); break; }
                    case 10: { SEARCH_3param(); break; }
                    case 11: { SEARCH_5param(); break; }
                    case 12: { SEARCH_6param(); break; }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            LoadData();

        }

        private void button4_Click(object sender, EventArgs e)//UPDATE
        {

            switch (TabelNum)
            {
                case 1: { UPDATE_1param(); break; }
                case 2: { UPDATE_1param(); break; }
                case 3: { UPDATE_1param(); break; }
                case 4: { UPDATE_1param(); break; }
                case 5: { UPDATE_2param(); break; }
                case 6: { Update_Stud(); break; }
                case 7: { UPDATE_2param(); break; }
                case 8: { UPDATE_2_param(); break; }
                case 9: { UPDATE_3param(); break; }
                case 10: { UPDATE_3param(); break; }
                case 11: { UPDATE_5param(); break; }
                case 12: { UPDATE_6param(); break; }
            }


            Clear_Data();
            LoadData();
        }


    }
}
