using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Patient_Form : Form
    {
        HospitalDBEntities db = new HospitalDBEntities();
        Paitent _paitent = null;
        public Patient_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Paitent.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Paitent.Add(new Paitent()
            {
                Name = textBox2.Text,
                Gender = Male.Checked || false,
                BirthDate = dateTimePicker1.Value,
                Smoking = checkBox1.Checked,
                IsFat = checkBox2.Checked 
            });
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            _paitent = db.Paitent.First(p1 => p1.ID == id);
            textBox2.Text = _paitent.Name;
            if(_paitent.Gender == true)
            {
                Male.Checked = true;
            }
            else
             {
                Female.Checked = true;
             }
            dateTimePicker1.Value = Convert.ToDateTime(_paitent.BirthDate );
            checkBox1.Checked = Convert.ToBoolean(_paitent.Smoking );
            checkBox2.Checked = Convert.ToBoolean(_paitent.IsFat);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            _paitent.Name = textBox2.Text;
            _paitent.BirthDate = dateTimePicker1.Value;
            db.SaveChanges();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            db.Paitent.Remove(_paitent);
            db.SaveChanges();
        }
    }
}
