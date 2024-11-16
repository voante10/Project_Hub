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

namespace Log_in_e_senha
{
    /// <summary>
    /// Lógica interna para Erro_1.xaml
    /// </summary>
    public partial class Erro_1 : Window
    {
        public Erro_1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.teste();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Log = new MainWindow();
            Log.Close();
            this.Close();
        }
    }
}
