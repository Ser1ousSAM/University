using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ending_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Passanger> passangers = new List<Passanger>();
        int allWeight = 0, allCountItems = 0, countOverWeight;
        private async void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (textBoxInputSurname.Text != "" && textBoxInputCountItems.Text != "" && textBoxInputWeight.Text != "")
            {
                if (!int.TryParse(textBoxInputCountItems.Text, out _))
                {
                    MessageBox.Show("Некорректный ввод количества предметов");
                }
                else if (!int.TryParse(textBoxInputWeight.Text, out _))
                {
                    MessageBox.Show("Некорректный ввод веса");
                }
                else
                {
                    Passanger passanger = new Passanger(textBoxInputSurname.Text,
                        Convert.ToInt32(textBoxInputCountItems.Text),
                        Convert.ToInt32(textBoxInputWeight.Text));
                    if (!passangers.Contains(passanger))
                    {
                        string path = "fileF.txt";
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            await writer.WriteAsync(passanger.Surname + ":");
                            await writer.WriteAsync(Convert.ToString(passanger.CountItems) + ":");
                            await writer.WriteLineAsync(Convert.ToString(passanger.Weight));
                        }
                        passangers.Add(passanger);
                        allWeight+=passanger.Weight;
                        allCountItems+=passanger.CountItems;
                        double middleWeight = (double)allWeight / allCountItems;
                        if (passanger.Weight > (int)middleWeight)
                            countOverWeight++;
                        textBoxOverWeight.Text = Convert.ToString(countOverWeight);
                        textBoxInputSurname.Text = "";
                        textBoxInputCountItems.Text = "";
                        textBoxInputWeight.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Такой пассажир уже существует!");

                    }
                }
            }
            else
                MessageBox.Show("Не все поля ввода свойств passenger заполнены");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("fileF.txt"))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    int i = 0;
                    string temp = "";
                    string surname;
                    int countItems, Weight;
                    while (line[i] != ':')
                    {
                        temp += line[i];
                        i++;
                    }
                    i++;
                    surname = temp;
                    temp = "";
                    while (line[i] != ':')
                    {
                        temp += line[i];
                        i++;
                    }
                    i++;
                    countItems = Convert.ToInt32(temp);
                    temp = "";
                    while (i != line.Length)
                    {
                        temp += line[i];
                        i++;
                    }
                    Weight = Convert.ToInt32(temp);
                    var passanger = new Passanger(surname, countItems, Weight);
                    if (!passangers.Contains(passanger))
                    {
                        passangers.Add(passanger);
                        allCountItems += passanger.CountItems;
                        allWeight += passanger.Weight;
                    }
                }
            }
            double middleWeight = (double)allWeight / allCountItems;
            countOverWeight = 0;
            foreach (var passanger in passangers)
            {
                if (passanger.Weight > (int)middleWeight)
                    countOverWeight++;
            }
            textBoxOverWeight.Text = Convert.ToString(countOverWeight);
        }

        private void buttonFileOutput_Click(object sender, EventArgs e)
        {
            textBoxFileOutput.Text = "";
            if (selectorFile.SelectedIndex != -1)
            {
                if (selectorFile.SelectedIndex == 0)
                    foreach (var passanger in passangers)
                        textBoxFileOutput.Text += passanger.ToString() + "\r\n";
                if (selectorFile.SelectedIndex == 1)
                {
                    var sortedPassangers = passangers.OrderBy(p => p.Surname);
                    foreach(var passanger in sortedPassangers)
                        textBoxFileOutput.Text+=passanger.ToString()+"\r\n";
                }
            }
            else
            {
                MessageBox.Show("Choose file");
            }
        }

        private void selectorRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectorRequest.SelectedIndex == 0)
            {
                textBoxFindOnSurname.Enabled = true;
                textBoxFindOnFirstLetter.Enabled = false;
            }else if (selectorRequest.SelectedIndex == 1)
            {
                textBoxFindOnSurname.Enabled = false;
                textBoxFindOnFirstLetter.Enabled = true;
            }
            else
            {
                textBoxFindOnSurname.Enabled = false;
                textBoxFindOnFirstLetter.Enabled = false;
            }
            
        }

        private void buttonFindPassanger_Click(object sender, EventArgs e)
        {
            textBoxRequestOutput.Text = "";
            if (selectorRequest.SelectedIndex == 0)
            {
                string surname = textBoxFindOnSurname.Text;
                List<Passanger> p = findOnSurname(surname);
                if (p != null)
                    foreach (Passanger passanger in p)
                        textBoxRequestOutput.Text += passanger.ToString() + "\r\n";
                else
                    textBoxRequestOutput.Text = "Нет пассажиров с такой фамилией";

            } else if (selectorRequest.SelectedIndex == 1)
            {
                char letter = textBoxFindOnFirstLetter.Text[0];
                List<Passanger> p = findOnFirstLetter(letter);
                if (p != null)
                    foreach (Passanger passanger in p)
                        textBoxRequestOutput.Text += passanger.ToString() + "\r\n";
                else
                    textBoxRequestOutput.Text = "Нет пассажиров на такую букву";
            }
        }

        private void textBoxFindOnFirstLetter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFindOnFirstLetter.Text.Length > 1)
            {
                char letter = textBoxFindOnFirstLetter.Text[1];
                textBoxFindOnFirstLetter.Text = "";
                textBoxFindOnFirstLetter.Text+=letter;
                textBoxFindOnFirstLetter.SelectionStart = 1;
            }
        }

        private void buttonBuildGisto_Click(object sender, EventArgs e)
        {
            GistoForm frGisto = new GistoForm(passangers);
            frGisto.Show();
            Hide();
        }

        private List<Passanger> findOnSurname(string surname)
        {
            List<Passanger> answer = new List<Passanger>();
            foreach (var passenger in passangers)
            {
                if (passenger.Surname.ToLower() == surname.ToLower())
                    answer.Add(passenger);
            }
            if (answer.Count > 0)
                return answer;
            return null;
        }

        private List<Passanger> findOnFirstLetter(char letter)
        {
            List <Passanger> answer = new List<Passanger>();
            foreach (var passenger in passangers)
            {
                if (passenger.Surname[0] == letter)
                   answer.Add(passenger);
            }
            if (answer.Count > 0)
                return answer;
            return null;
        }
    }
}
