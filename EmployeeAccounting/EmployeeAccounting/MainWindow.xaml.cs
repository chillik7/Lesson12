using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeAccounting
{
    public partial class MainWindow : Window
    {
        private List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            employees.Add(new Employee("Иванов Иван Иванович", "Менеджер"));
            employees.Add(new Employee("Петров Петр Петрович", "Разработчик"));
            employees.Add(new Employee("Сидорова Анна Михайловна", "Аналитик"));
            employees.Add(new Employee("Кузнецов Дмитрий Сергеевич", "Разработчик"));
            employees.Add(new Employee("Смирнова Елена Владимировна", "Менеджер"));

            UpdateEmployeeList();
        }

        private void UpdateEmployeeList()
        {
            var filteredEmployees = employees;

            if (rbManager.IsChecked == true)
                filteredEmployees = employees.Where(e => e.Position == "Менеджер").ToList();
            else if (rbDeveloper.IsChecked == true)
                filteredEmployees = employees.Where(e => e.Position == "Разработчик").ToList();
            else if (rbAnalyst.IsChecked == true)
                filteredEmployees = employees.Where(e => e.Position == "Аналитик").ToList();

            employeesGrid.ItemsSource = filteredEmployees;
        }

        private void FilterChanged(object sender, RoutedEventArgs e)
        {
            UpdateEmployeeList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new EmployeeWindow();
            if (window.ShowDialog() == true)
            {
                employees.Add(new Employee(window.FullName, window.Position));
                UpdateEmployeeList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (employeesGrid.SelectedItem is Employee selectedEmployee)
            {
                var window = new EmployeeWindow
                {
                    FullName = selectedEmployee.FullName,
                    Position = selectedEmployee.Position
                };

                if (window.ShowDialog() == true)
                {
                    selectedEmployee.FullName = window.FullName;
                    selectedEmployee.Position = window.Position;
                    UpdateEmployeeList();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (employeesGrid.SelectedItem is Employee selectedEmployee)
            {
                if (MessageBox.Show($"Удалить сотрудника {selectedEmployee.FullName}?", "Подтверждение",
                                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    employees.Remove(selectedEmployee);
                    UpdateEmployeeList();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
