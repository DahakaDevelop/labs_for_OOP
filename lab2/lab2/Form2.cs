using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    using Newtonsoft.Json;

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox3_Validation(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "invalid");
            }
        }

        private void textBox1_Validation(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider3.SetError(textBox1, "invalid");
            }
        }

        private void textBox2_Validation(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider2.SetError(textBox2, "invalid");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data2 = new
            {
                textBox1 = textBox1.Text,
                textBox2 = textBox2.Text,
                textBox3 = textBox3.Text,
            };
            string json = JsonConvert.SerializeObject(data2, Formatting.Indented);
            File.WriteAllText("data2.json", json);
        }
    }
}
