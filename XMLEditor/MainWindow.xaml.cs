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
//using System.Windows.MessageBox;

namespace XMLEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileHandler FH=new FileHandler();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void updateListBox()
        {
                                                try
           {
                FieldToReplace.Items.Clear();
                if (FH.ListOfFiles.Count > 0)
                {
                    if (ToAllRadio.IsChecked == true)
                    {
                        /*HashSet<string> tmp = new HashSet<string>();*/
                        List<string> tmp = new List<string>();
                        tmp.Clear();
                        tmp = FH.getIntersectTags();
                        foreach (string tag in tmp)
                        {
                            FieldToReplace.Items.Add(tag);
                        }
                    }
                    else
                    {
                        if (FilesListBox.SelectedItem == null)
                        {
                            FilesListBox.SelectedIndex = FilesListBox.Items.Count - 1;
                        }
                        foreach (string tag in (FilesListBox.SelectedItem as File).tags.Distinct())
                        {
                            FieldToReplace.Items.Add(tag);
                        }
                    }
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
            if (FH.ListOfFiles.Count == 0) { UseToSelectedButton.IsEnabled = false; UseToAllButton.IsEnabled = false; }
            if (ToAllRadio.IsChecked == false) { UseToAllButton.IsEnabled = false; UseToSelectedButton.IsEnabled = true; } else {if(FH.ListOfFiles.Count>1) UseToAllButton.IsEnabled = true; }
            if (FilesListBox.Items.Count == 0) { DeleteButton.IsEnabled = false; UseToSelectedButton.IsEnabled = false; } else { DeleteButton.IsEnabled = true; }
            if (FH.ListOfFiles.Count > 1) { ToAllRadio.IsEnabled = true; } else { ToAllRadio.IsEnabled = false; ToSelectedRadio.IsChecked = true; UseToAllButton.IsEnabled = false; }
           
               
               
                
        }
       
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "XML Файли|*xml";
            OFD.ShowDialog();
            if (OFD.FileName != "") 
            {
                File f = new File(OFD.FileName);
                FH.ListOfFiles.Add(f);
                FilesListBox.Items.Add(f);
                updateListBox();
            }
            

            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //try 
            //{
            if (FilesListBox.Items.Count > 1)
            {
                FH.ListOfFiles.Remove(FilesListBox.SelectedItem as File);
                FilesListBox.Items.RemoveAt(FilesListBox.SelectedIndex);
                updateListBox();
            }
            else 
            {
                FH.ListOfFiles.Remove(FilesListBox.SelectedItem as File);
                FH.ListOfFiles.Clear();
                FilesListBox.Items.Clear();
              //  FilesListBox.Items.Add("vassa");
              //  updateListBox();
                FieldToReplace.Items.Clear();
            }
           // }
            //catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
        }

        private void ToAllRadio_Click(object sender, RoutedEventArgs e)
        {
            updateListBox();
            
        }

        private void ToSelectedRadio_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ToSelectedRadio_Click(object sender, RoutedEventArgs e)
        {
            updateListBox();
        }

        private void FilesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if (ToSelectedRadio.IsChecked == true) { FieldToReplace.Items.Clear(); updateListBox(); }
        }

        private void UseToSelectedButton_Click(object sender, RoutedEventArgs e)
        {            
            FH.ReplaceValue(FieldToReplace.SelectedItem.ToString(), NewValueTextBox.Text, FilesListBox.SelectedItem as File);
            System.Windows.MessageBox.Show("Успішно записано!");
        }

        private void UseToAllButton_Click(object sender, RoutedEventArgs e)
        {
            FH.packetReplaceValue(FieldToReplace.SelectedItem.ToString(), NewValueTextBox.Text);
            System.Windows.MessageBox.Show("Успішно записано!");
        }
    }
}
