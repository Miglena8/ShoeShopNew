using Miglena_11d_3.Controller;
using Miglena_11d_3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Miglena_11d_3.View
{
    public partial class Form1 : Form
    {
        ShoeLogic shoeController = new ShoeLogic();
        ShoeTypeLogic shoetypesController = new ShoeTypeLogic();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Shoe shoe)
        {
            textBox1.Text = shoe.ID.ToString();
            textBox2.Text = shoe.Marka;
            textBox5.Text = shoe.Price.ToString();
            textBox4.Text = shoe.Nomer.ToString();
            textBox3.Text = shoe.Opisanie;
            comboBox1.Text = shoe.ShoeTypes.Marka;
            listBox1 .Items.Add(shoe.Opisanie.ToString());
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
            {
                MessageBox.Show("Vavedete danni!");
                textBox1.Focus();
                return;
 
            }
            Shoe newShoe = new Shoe();
            newShoe.Marka =textBox2.Text;
            newShoe.Price = double.Parse(textBox5.Text);
            newShoe.Nomer= double.Parse(textBox4.Text);
            newShoe.Opisanie = textBox3.Text;
            newShoe.ShoeTypeId = (int)comboBox1.SelectedValue;
            shoeController.Create(newShoe);
            MessageBox.Show("Zapisat e yspesheo dobaven!");
            ClearScreen();
            btnSelectAll_Click(sender, e);

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Shoe> allShoe = shoeController.GetAll();
            listBox1.Items.Clear();
            foreach(var item in allShoe)
            {
                listBox1.Items.Add($"{item.ID}. Marka: {item.Marka}, Nomer: {item.Nomer}, Price: {item.Price} ShoeType:{item.ShoeTypes.Marka}, Opisanie: {item.Opisanie}");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Shoe findedShoe = shoeController.Get(findId);
            if (findedShoe == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedShoe);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Shoe findedshoe = shoeController.Get(findId);
                if (findedshoe == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedshoe);
            }
            else
            {
                Shoe updatedshoe = new Shoe();
                updatedshoe.ID = int.Parse(textBox1.Text);
                updatedshoe.Marka = textBox2.Text;
                updatedshoe.Price = double.Parse(textBox5.Text);
                updatedshoe.Nomer = double.Parse(textBox4.Text);
                updatedshoe.Opisanie = textBox3.Text;
                updatedshoe.ShoeTypeId = (int)comboBox1.SelectedValue;
                
                MessageBox.Show("Записът е успешно променен!");

                shoeController.Update(findId, updatedshoe);
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Shoe findedshoe = shoeController.Get(findId);
            if (findedshoe == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedshoe);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " + findId + " ?", "PROMPT", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                shoeController.Delete(findId);
            }
            btnSelectAll_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ShoeType> allShoeTypes = shoetypesController.GetShoeTypes();
            comboBox1.DataSource = allShoeTypes;
            comboBox1.DisplayMember = "Marka";
            comboBox1.ValueMember = "Id";

            btnSelectAll_Click(sender, e);
        }
    }
}
