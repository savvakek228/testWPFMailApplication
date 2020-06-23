using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Threading;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для PostWindowUser.xaml
    /// </summary>
    public partial class PostWindowUser : Window
    {
        public int ID = 0;
        public PostWindowUser()
        {
            InitializeComponent();
        }
        private async void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            using (var MDContext = new MessageDataContext())
            {
                var wpfEmailer = WPFEmailer.getEmailerInstance(
                    txtUserName.Text,
                    txtTo.Text,
                    txtUserName.Text,
                    txtPassword.Password,
                    txtSubject.Text,
                    txtBody.Text);
                MessageData messageData = new MessageData(ID++, txtUserName.Text, txtBody.Text);
                MDContext.messageDatas.Add(messageData);
                await MDContext.SaveChangesAsync();
                //TODO вынести это в настройки
                //wpfEmailer.Host = txtSMTPServerName.Text;
                //wpfEmailer.Port = Convert.ToInt32(txtSMTPPortNumber.Text);
                try
                {
                    wpfEmailer.SendEmail();
                    MessageBox.Show("Message send successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
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

