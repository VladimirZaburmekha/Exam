using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLEditor.Classes
{
    public class FileHandler
    {
       
       public List<File> ListOfFiles = new List<File>();
        private List<string> intesectLists(List<string> List1, List<string> List2)
       {
           List<string> intersectedlist = new List<string>();
           foreach (var item in List1) 
           {
               if (List2.Contains(item)) { intersectedlist.Add(item); }
           }

           return intersectedlist;
       }
        
       /*public HashSet<string> getIntersectTags()*/
        public List<string> getIntersectTags()
       {
           if (ListOfFiles != null)
           {
              /* HashSet<string> finish = new HashSet<string>(this.ListOfFiles[0].tags);*/
               List<string> finish = new List<string>(this.ListOfFiles[0].tags);
               foreach (File item in ListOfFiles)
               {
                  finish = intesectLists(finish, item.tags);                
               }
               return finish;
           }
           else return null;
       }
        public void packetReplaceValue(string tagsToReplace, string newValues)
        {
            try
            {
                foreach (File item in this.ListOfFiles)
                {
                    ReplaceValue(tagsToReplace, newValues, item);
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
        }
        public void ReplaceValue(string tagToReplace, string newValue, File FileToHandle)
        {
            try
            {
                XDocument doc = XDocument.Load(FileToHandle.fileAddress);
                foreach (XElement el in doc.Root.Elements(tagToReplace))
                {
                    /* el.SetAttributeValue(tagToReplace, newValue);*/
                    el.SetValue(newValue);
                }
                doc.Save(FileToHandle.fileAddress);
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
        }
    }
}
