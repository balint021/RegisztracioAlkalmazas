using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nameText.Text != null && !nameText.Text.Equals("") && dateTimePicker1.Text != null && hobbiList.SelectedItem != null)
            {
                StreamWriter fw = new StreamWriter("data.txt");

                fw.WriteLine(nameText.Text);
                fw.WriteLine(dateTimePicker1.Text);
                if (Ferfi.Checked == true)
                {
                    fw.WriteLine("Ferfi");
                }
                if (No.Checked == true)
                {
                    fw.WriteLine("No");
                }
                fw.WriteLine(hobbiList.SelectedItem);
                fw.Close();

                MessageBox.Show("Mentés sikeres.");
            }
            else
            {
                MessageBox.Show("gatya");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            hobbiList.Items.Add(hobbiText.Text);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (hobbiList.SelectedItem != null)
            {
                hobbiList.Items.Remove(hobbiList.SelectedItem);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("data.txt");

                nameText.Text = sr.ReadLine();
                sr.ReadLine();
                String nem = sr.ReadLine();
                if (nem.Equals("Ferfi"))
                {
                    Ferfi.Checked = true;
                }
                else
                {
                    No.Checked = true;
                }
                hobbiList.Items.Clear();
                hobbiList.Items.Add(sr.ReadLine());

                sr.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            
        }
    }
}
