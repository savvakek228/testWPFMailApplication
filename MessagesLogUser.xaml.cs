using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MessagesLogUser.xaml
    /// </summary>
    /// 
    public partial class MessagesLogUser : Window
    {
        public MessagesLogUser()
        {          
                InitializeComponent();
                Loaded += MessagesLogUser_Loaded;           
        }

        private async void MessagesLogUser_Loaded(object Sender, RoutedEventArgs e)
        {
            using (var MDContext = new MessageDataContext())
            {
                var msgList = await MDContext.messageDatas.ToListAsync();
                MessagesList.ItemsSource = msgList;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TransitWindow transitWindow = new TransitWindow();
            Close();
            transitWindow.Show();
        }
    }
}
