using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeAccounting
{
    public partial class EmployeeWindow : Window
    {
        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }

        public string Position
        {
            get => (cbPosition.SelectedItem as ComboBoxItem)?.Content.ToString();
            set
            {
                foreach (ComboBoxItem item in cbPosition.Items)
                {
                    if (item.Content.ToString() == value)
                    {
                        cbPosition.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public EmployeeWindow()
        {
            InitializeComponent();
            cbPosition.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                MessageBox.Show("Введите ФИО сотрудника", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
