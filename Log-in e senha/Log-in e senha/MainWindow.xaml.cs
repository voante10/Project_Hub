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

namespace Log_in_e_senha
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string[] linhas;
        int tentativa = 3;
        


        #region Cancel button
        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }
        public void Exit()
        {
            Close();
        }

        #endregion

        #region Arquivo
        static void save(string user, string pin)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("dados.txt", true))
                {
                    writer.WriteLine(user);
                    writer.WriteLine(pin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao armazenar o texto: " + ex.Message);
            }
        }
        
        static void Catch()
        {
            
            try
            {
                using(StreamReader Reader = new StreamReader("dados.txt"))
                {
                    string texto = Reader.ReadToEnd();
                    linhas = texto.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool verify()
        {
            string app = AppDomain.CurrentDomain.BaseDirectory;
            string path = System.IO.Path.Combine(app, "dados.txt");

            if (File.Exists(path)) { return true; }
            else { return false; } 
        }

        static void Clean()
        {
            string app = AppDomain.CurrentDomain.BaseDirectory;
            string path = System.IO.Path.Combine(app, "dados.txt");

            if (File.Exists(path)) { File.Delete(path); }
            else { Console.WriteLine("inexistente"); }
        }
        #endregion


        public void Signin_btn_Click(object sender, RoutedEventArgs e)
        {
            String username = Usernametxt.Text;
            String senha = Senhatxt.Text;
            validador func = new validador();

            
            if (func.securepin(senha))
            {
                Clean();
                save(username, senha);
                MessageBox.Show("informações savas com sucesso");
            }
        }

        public void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            Catch();
            String username = Usernametxt.Text;
            String senha = Senhatxt.Text;
            verify();
            switch (verify()) {

                case true:
                    if (linhas[0] == username && linhas[1] == senha)
                    {
                        AppWindow app = new AppWindow();
                        app.Show();
                        Exit();
                    }
                    break;
            }
            

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove(); 
            }
        }
    }

    public class validador
    {
        Dictionary<string, Func<string, bool>> Crit = new Dictionary<string, Func<string, bool>> {
            {"tamanho de 6 digitos", senha => senha.Length >= 6 },
            {"caractere especial", senha => Regex.IsMatch(senha, @"[W_]")},
            {"letra maiúscula", senha => Regex.IsMatch(senha, @"[A-Z]")},
            {"letra minúscula", senha => Regex.IsMatch(senha, @"[a-z]")},
            {"numeros", senha => Regex.IsMatch(senha, @"[0-9]")}
        };

        public bool securepin(string senha)
        { 
            foreach(var criterios in Crit)
            {
                if (!criterios.Value(senha))
                {
                    MessageBox.Show($"sua senha deve conter {criterios.Key}");
                    return false;
                }
            }
            return true;
        }
    }

}
