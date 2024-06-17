using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<string, int> initialDictionary = new Dictionary<string, int>()
        {
            { "Яблоко", 5 },
            { "Банан", 3 },
            { "Мандарин", 2 },
            { "Вишня", 7}
        };
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text) & !String.IsNullOrEmpty(textBox2.Text))
                {
                    Dictionary<string, int> userDictionary = new Dictionary<string, int>();

                    string[] fruit = textBox1.Text.Split(',');
                    string[] weight = textBox2.Text.Split(',');

                    for (int i = 0; i < fruit.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(fruit[i].Trim()) && !String.IsNullOrEmpty(weight[i].Trim()))
                        {
                            userDictionary[fruit[i].Trim()] = Int32.Parse(weight[i].Trim());
                        }
                    }

                    string cleanlList = String.Join(", ", userDictionary.Select(n => n.ToString()));

                    Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(); // Объединение словарей и суммирование значений

                    foreach (KeyValuePair<string, int> item in initialDictionary)
                    {
                        mergedDictionary.Add(item.Key, item.Value);
                    }

                    foreach (KeyValuePair<string, int> item in userDictionary)
                    {
                        if (mergedDictionary.ContainsKey(item.Key))
                        {
                            mergedDictionary[item.Key] += item.Value;
                        }
                        else
                        {
                            mergedDictionary.Add(item.Key, item.Value);
                        }
                    }
                    foreach (KeyValuePair<string, int> item in mergedDictionary)
                    {
                        listBox2.Items.Add($"{item.Key}: {item.Value}");
                    }
                }
                else
                {
                    MessageBox.Show("Поля для ввода не должны быть пустые!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBox2.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
