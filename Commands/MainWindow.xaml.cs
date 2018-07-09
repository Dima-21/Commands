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
using System.Windows.Forms;
using System.IO;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string path { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog fbd = new SaveFileDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.FileName;
                File.Create(path);
            }
            System.Windows.MessageBox.Show("Файл создан!");
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();         
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = ofd.FileName;
                textBox.Text = File.ReadAllText(path);
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            File.WriteAllText(path ,textBox.Text);
            System.Windows.MessageBox.Show("Файл успешно сохранен!");
        }
    }
}
