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
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для TransitWindow.xaml
    /// </summary>
    public partial class TransitWindow : Window
    {            
        PostWindowUser postWindow = new PostWindowUser();
        MessagesLogUser messagesLog = new MessagesLogUser();
        public TransitWindow()
        {
            InitializeComponent();
        }

        private void NewMessage_Click(object sender, RoutedEventArgs e)
        {
            Close();
            postWindow.Show();
        }

        private void MessagesLog_Click(object sender, RoutedEventArgs e)
        {
            Close();
            messagesLog.Show();
        }
    }
}
