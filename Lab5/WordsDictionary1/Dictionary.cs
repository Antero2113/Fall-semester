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

namespace WordsDictionary1
{
    public partial class Dictionary : Form
    {
        private Dictionary<string, WordInfo> dictionary;
        public Dictionary(Dictionary<string, WordInfo> dict)
        {
            InitializeComponent();
            dictionary = dict; // Сохраняем словарь в поле класса

            // Создание и настройка ListBox
            listBox1.Dock = DockStyle.Fill;
            Controls.Add(listBox1);

            // Заполнение ListBox содержимым словаря
            foreach (var entry in dictionary)
            {
                string word = entry.Key;
                listBox1.Items.Add(word);
            }
        }

        private void Dictionary_Load(object sender, EventArgs e)
        {

        }

        private void deleteWordButton_Click(object sender, EventArgs e)
        {
            // Проверка, что слово выбрано в ListBox
            if (listBox1.SelectedIndex != -1)
            {
                string selectedWord = listBox1.SelectedItem.ToString();

                // Удаление слова из словаря
                if (dictionary.ContainsKey(selectedWord))
                {
                    dictionary.Remove(selectedWord);

                    // Обновление ListBox после удаления слова
                    listBox1.Items.Remove(selectedWord);
                }
            }
            else
            {
                MessageBox.Show("Выберите слово для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
