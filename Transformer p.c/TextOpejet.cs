using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Transformer_p.c
{
    class TextOpejet
    {
       // toolbox tool = new toolbox();
        public object combox(ComboBox cobox,int i) {
            object ret = new object();
            
            switch (i)
            {   case 1:
                    {
                        cobox.Items.Add("Non");
                        cobox.Items.Add("Copy");
                        cobox.Items.Add("move To");
                        cobox.Items.Add("Delete");
                        cobox.Items.Add("Delete form List");
                        cobox.SelectedIndex = 0;
                        cobox.DropDownStyle = ComboBoxStyle.DropDownList;
                    } break;
                case 2:
                    { 
            cobox.Items.Add("Non");
            cobox.Items.Add("Process");
            cobox.Items.Add("Delete");
            cobox.SelectedIndex = 0;
        cobox.DropDownStyle = ComboBoxStyle.DropDownList; } break;
             
            }
            
           
            
        ret = cobox;
            
            return ret;
        }
        public string listview(ListView text, int i, int y) { return text.Items[i].SubItems[y].Text; }


        public object ListViewItem(ListView view, string text)
        {
            ListViewItem t;
            object ret = new object();
            if (!Uri.IsWellFormedUriString(text, UriKind.Absolute))
            {
                 t = new ListViewItem(Path.GetFileName(text));
                t.SubItems.Add(text);
                t.SubItems.Add("");
                view.Items.Add(t);

                ret = t;
                return ret;
            }
            else
            {
                 t = new ListViewItem((""));
                t.SubItems.Add(text);
                t.SubItems.Add("");
                ret = t;
                view.Items.Add(t);
                return ret;
            }

            return ret;
          
           
         
           


        }

        public object ListViewItem2(ListView view, string text)
        {
            ListViewItem t;
            t = new ListViewItem(text);
            t.SubItems.Add("");
            t.SubItems.Add("");
            view.Items.Add(t);
            object ret = new object();
            return ret = t;
        }
    
    }//

     

}
