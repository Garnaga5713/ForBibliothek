using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_for_Bibliothek
{
    public partial class Admin_ALL_Table_Form : Form
    {
        public Admin_ALL_Table_Form()
        {
            InitializeComponent();
            button1.Text = "Bibliothek Worker";
            button2.Text = "Autor";
            button3.Text = "Faculty";
            button4.Text = "Publish";
            button5.Text = "Teacher";
            button6.Text = "Student";
            button7.Text = "Special";
            button8.Text = "Author Book";
            button9.Text = "Book";
            button10.Text = "Group";
            button11.Text = "Teacher Card";
            button12.Text = "Student_Card";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(1);
            admin_Panel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(2);
            admin_Panel.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(3);
            admin_Panel.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(4);
            admin_Panel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(5);
            admin_Panel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(6);
            admin_Panel.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(7);
            admin_Panel.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(8);
            admin_Panel.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(9);
            admin_Panel.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(10);
            admin_Panel.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Admin_Panel Admin_Panel = new Admin_Panel(11);
            Admin_Panel.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Admin_Panel admin_Panel = new Admin_Panel(12);
            admin_Panel.Show();
        }
    }
}
