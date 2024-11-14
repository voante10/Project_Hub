using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Linq.Expressions;
using System.IO.Packaging;
using System.Text.RegularExpressions;
using System.Security.RightsManagement;
using System.Windows.Threading;
using System.Threading;

namespace Log_in_e_senha
{
    /// <summary>
    /// Lógica interna para AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => Clocka();
            timer.Start();
            Clocka();
        }

        #region Básico
        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }
        public void Exit()
        {
            Close();
        }

        private void WindowMD(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        #endregion
        public void Clocka()
        {
           
            var Time = DateTime.Now.ToString("hh : mm : ss");
            Relogio.Text = Time;
        }
        private DispatcherTimer timer;
        
    }
}
