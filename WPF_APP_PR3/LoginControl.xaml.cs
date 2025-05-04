using System;                             
using System.Collections.Generic;        
using System.Linq;                       
using System.Text;                        
using System.Threading.Tasks;            
using System.Windows;                   
using System.Windows.Controls;          
using System.Windows.Data;          
using System.Windows.Documents;     
using System.Windows.Input;              //з клавіатури
using System.Windows.Media;              
using System.Windows.Media.Imaging;     
using System.Windows.Navigation;         
using System.Windows.Shapes;            

namespace WPF_APP_PR3                    
{
    public partial class LoginControl : UserControl   
    {
        public LoginControl()             
        {
            InitializeComponent();       
            Loaded += (s, e) => usernameBox.Focus(); // фокус на поле користувч
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)  
        {
            AttemptLogin();            
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)     
        {
            if (e.Key == Key.Enter)     // для клави
            {
                AttemptLogin();
            }
        }

        private void AttemptLogin()     
        {
            if (string.IsNullOrWhiteSpace(usernameBox.Text)) //поле пусто iм
            {
                ShowErrorMessage("Будь ласка, потрiбно ввести ім'я користувача"); 
                usernameBox.Focus();     
                return;                  
            }

            if (string.IsNullOrWhiteSpace(passwordBox.Password)) //поле пусто парол
            {
                ShowErrorMessage("Будь ласка, потрiбно ввести пароль"); 
                passwordBox.Focus();    
                return;
            }

            if (passwordBox.Password.Length < 6) 
            {
                ShowErrorMessage("Пароль повинен містити не менше 6 символів", isError: true); 
                return;
            }

            ShowSuccessMessage($"Ласкаво просимо, {usernameBox.Text}!"); 
        }

        private void ShowErrorMessage(string message, bool isError = true) 
        {
            messageText.Foreground = isError ? Brushes.Red : Brushes.Green; 
            messageText.Text = message; 
        }

        private void ShowSuccessMessage(string message) 
        {
            messageText.Foreground = Brushes.Green; 
            messageText.Text = message; 
            loginButton.Content = "Вийти"; //змiна на вийти
            loginButton.Click -= LoginButton_Click; 
            loginButton.Click += LogoutButton_Click; 
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e) 
        {
            ResetForm();
        }

        private void ResetForm() 
        {
            usernameBox.Clear(); 
            passwordBox.Clear(); 
            messageText.Text = string.Empty; 
            loginButton.Content = "Увійти"; 
            loginButton.Click -= LogoutButton_Click; 
            loginButton.Click += LoginButton_Click; 
            usernameBox.Focus(); 
        }

        public event EventHandler OnLoginSuccess; 
    }
}
