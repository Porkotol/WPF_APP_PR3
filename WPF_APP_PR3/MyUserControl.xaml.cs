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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_APP_PR3
{
 
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            txtMessage.Text = "Тест тексту";
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "Активацiя пройшла успiшно!";
            btnAction.Content = "Пройти ще раз ?";
        }
    }
}
