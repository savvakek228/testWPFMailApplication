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
    public partial class MainWindowReduced : Window
    {
        public int ID = 0;//аналогично MainWindow
        public MainWindowReduced()
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
                UserData user = new UserData(ID++,LoginTextBox.Text,PasswordTextBox.Password.GetHashCode());
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
    }
}
