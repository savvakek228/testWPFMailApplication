using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();



        public int ID = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void RegisteryBtn_click(object sender, RoutedEventArgs e)
        {
            using (var UDContext = new UserDataContext())
            {
                UserData user = new UserData(ID++, LoginTextBox.Text, PasswordTextBox.Password.GetHashCode());
                UDContext.userDatas.Add(user);
                await UDContext.SaveChangesAsync();
            }
        }
        private async void AuthorisationBtn_click(object sender, RoutedEventArgs e)
        {
            using (var UDContext = new UserDataContext())
            {
                UserData user = new UserData(ID++, LoginTextBox.Text, PasswordTextBox.Password.GetHashCode());
                //UDContext.Find() подходит или нет - проверить
                bool queryResLogin = await UDContext.userDatas.AnyAsync(x => x.Login == user.Login);
                bool queryResPassword = await UDContext.userDatas.AnyAsync(y => y.PasswordHashCode == user.PasswordHashCode);
                if (queryResLogin && queryResPassword)
                {
                    TransitWindow transitWindow = new TransitWindow();
                    Close();
                    transitWindow.Show();
                }
                else MessageBox.Show("Ошибка аутентификации. Неверный логин или пароль");
            }
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            PostWindowUser userPostWindow = new PostWindowUser();
            Close();
            userPostWindow.Show();
        }

        private void DebugConsole_Click(object sender, RoutedEventArgs e)
        {
            AllocConsole();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            JetEntityFrameworkProvider.JetConnection.ShowSqlStatements = true;
        }
    }
}
