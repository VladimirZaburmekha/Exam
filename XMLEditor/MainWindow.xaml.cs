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
using XMLEditor.Classes;
using System.Windows.Forms;

namespace XMLEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void updateListBox()
        {   
            if (ToAllRadio.IsChecked == true) 
            {
                HashSet<string> s = new HashSet<string>();
               // s.Intersect()
            }
        }
       //.. public List<string> ListOfFiles()
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
           /* File F=new File();
            List<string> s = F.getFileTags();*/
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();
            if (OFD.FileName != null) 
            {
                File f = new File(OFD.FileName);
                foreach (string tag in f.tags) { System.Console.WriteLine(tag);}//перевірка чи пахає запис в множину
            }

            
        }
    }
}
