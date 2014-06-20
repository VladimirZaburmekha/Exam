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
      
       private string fileAddress;
       public HashSet<string> tags = new HashSet<string>();      
       public void setFileTags()
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
                           tags.Add(reader.LocalName.ToString());
                   }
               }
           }
           finally
           {
               if (reader != null)
                   reader.Close();
           }           
       }
       public File(string address) { fileAddress = address; setFileTags(); tags.Distinct(); }
    }
}
