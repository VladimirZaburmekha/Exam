using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLEditor.Classes
{
   public class File
    {
      
       public string fileAddress;
       public List<string> tags {get;private set;}   
       public void read()
       {
           XmlTextReader reader = null;             
          try
           {                
               // Load the reader with the XML file.
               reader = new XmlTextReader(fileAddress);
               // Parse the file.  If they exist, display the prefix and 
               // namespace URI of each node.
               while (reader.Read())
               {
                   if (reader.IsStartElement())
                   {
                       if (reader.Prefix == String.Empty)
                       {                      
                           string tmp = reader.LocalName.ToString();
                           tags.Add(tmp);
                       }
                   }
               }
               tags.Distinct();
           }
           catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
           finally
           {
               if (reader != null)
                   reader.Close();
           }    
       
       }
       public File(string address) 
       { fileAddress = address; tags=new List<string>(); read();}
       public override string ToString()
         {
             return this.fileAddress;
         }
    }
}
