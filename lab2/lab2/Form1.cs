namespace lab2
{
    using Newtonsoft.Json;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Validating += textBox1_Validating;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2form = new Form2();
            form2form.Show(); 
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "invalid");
            } 
        }

        private void Year_Validation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                errorProvider1.SetError(maskedTextBox1, "invalid");
            }
        }

        private void TextBox4_Validation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "invalid");
            }
        }

        private void textBox2_Validation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "invalid");
            }
        }

        private void textBox3_Validation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "invalid");
            }
        }

        private void textBox5_Validation(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "invalid");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = string.Empty;
                }
                else if (control is MaskedTextBox)
                {
                    MaskedTextBox comboBox = (MaskedTextBox)control;
                    maskedTextBox1.Text = "";
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)control;
                    dateTimePicker.Value = DateTime.Now;
                }
                // add more control types here as needed
            }
        }


        private string selectedOption = "TXT";

        // ...

        public void button1_Click(object sender, EventArgs e)
        {
            string selectedItem = "Белорусская энциклопедия им. П. Бровки";
            if (listBox1.SelectedItem != null)
            {
                selectedItem = listBox1.SelectedItem.ToString();
            }
            // Create an object that represents the data to be saved
            var data = new
            {
                textBox1 = textBox1.Text,
                textBox2 = textBox2.Text,
                textBox3 = textBox3.Text,
                textBox4 = textBox4.Text,
                selectedOption = selectedOption,
                textBox5 = textBox5.Text,
                selectedItem = selectedItem,
                dateTimePicker1= dateTimePicker1.Text,
            };

            // Serialize the object to JSON format and write it to a file
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("data.json", json);
        }

        public void groupBox1_Enter(object sender, EventArgs e)
        {
            selectedOption = null;
            foreach (RadioButton radioButton in groupBox1.Controls)
            {
                if (radioButton.Checked)
                {   
                    selectedOption = radioButton.Text;
                    break;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("data.json"))
            {
                string json = File.ReadAllText("data.json");
                var data = JsonConvert.DeserializeAnonymousType(json, new
                {
                    textBox1 = "",
                    textBox2 = "",
                    textBox3 = "",
                    textBox4 = "",
                    selectedOption = "",
                    textBox5 = "",
                    selectedItem = "",
                    dateTimePicker1 = ""
                });

                textBox1.Text = data.textBox1;
                textBox2.Text = data.textBox2;
                textBox3.Text = data.textBox3;
                textBox4.Text = data.textBox4;
                textBox5.Text = data.textBox5;
                dateTimePicker1.Text = data.dateTimePicker1;

                if (!string.IsNullOrEmpty(data.selectedOption))
                {
                    foreach (RadioButton radioButton in groupBox1.Controls)
                    {
                        if (radioButton.Text == data.selectedOption)
                        {
                            radioButton.Checked = true;
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(data.selectedItem))
                {
                    listBox1.SelectedItem = data.selectedItem;
                }
            }
        }
    }
}