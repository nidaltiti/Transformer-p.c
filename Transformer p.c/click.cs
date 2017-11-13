using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Transformer_p.c
{
    class click
    {
        comander conmad = new comander();
        public static int p=-1;
       // toolbox box = new toolbox();
        public void text_Enter(object sender, KeyEventArgs e, int s, ListView listviewcommder)
        {
            TextBox text = (TextBox)sender;
            // S1 m = new S1();


            if (e.KeyCode == Keys.Enter)
            {

                listviewcommder.Items[s].SubItems[0].Text = text.Text;
                //  MessageBox.Show(s.ToString());

                listviewcommder.Controls.Remove(text);
                S1.processxml = true;
            }

        }
        public void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListView listview = (ListView)sender;
            Point m = e.Location;

            if (e.Button == MouseButtons.Left)
            {

                int i = 0;
                for (i = 0; i < listview.Items.Count; i++)
                {
                    if (listview.Items[i].Bounds.Contains(e.Location)) { pp(i, m, listview); }

                }


            }
        }

        void pp(int i, Point m, ListView v)
        {
            if (!v.Items[i].SubItems[1].Bounds.Contains(m))
            {
                if (Uri.IsWellFormedUriString(v.Items[i].SubItems[1].Text, UriKind.Absolute)) {

                    toolbox box = new toolbox();
                    box.textbox2(v, i, 0); }

            }
       
        
        }
        public void moudclick(object sender, MouseEventArgs e)
        {
            ListView listview = (ListView)sender;
            for (int i = 0; i < listview.Items.Count; i++)
            {
                if (listview.Items[i].SubItems[1].Bounds.Contains(e.Location)) { try { System.Diagnostics.Process.Start(listview.Items[i].SubItems[1].Text); }
                catch { MessageBox.Show("can not Process program try Again "); }
                }

            }

        }
        public void _makeDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        public void objertDragDrop(object sender, DragEventArgs e, ListView view)
        {

            switch (view.Name)
            {
                case "v1":
                    {


                        try
                        {
                            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                            foreach (string i in files)
                            {
                                conmad.drop(i, view);

                            }

                        }
                        catch
                        {
                            string f = e.Data.GetData(DataFormats.Text).ToString(); conmad.dropurl(f, view, true, true);

                          


                        }

                        break;

                    }
                case "v2":
                    {
                        string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];


                        toolbox tool = new toolbox();
                        TextOpejet ttext = new TextOpejet();
                         conmad = new comander ();
                        foreach (string i in files)
                        {
conmad.drop(i,view);
                        } break;


                        
                    }//
                  
            }
            S1.processxml = true;
        }
     public    void cb_SelectedIndexChanged(object sender, EventArgs e,ListView view)
        {
            if (view.Name == "v2") {
                try {
                    if (Lists.cobo2[p].Text == "Non" || Lists.cobo2[p].Text == "Delete" || Lists.cobo2[p].Text == "Delete form List")
                    {


                        if (Lists.cobo2[p].Text == "Non") { p = -1; }

                        else
                        {
                            view.Items[p].SubItems[2].Text = Lists.cobo2[p].Text; p = -1;
                        }
                    }
                   
                }
                catch { }
            }
           
            
            
            S1.processxml = true;
        }


     public void open_Click(object sender, EventArgs e, ContextMenuStrip m,S1 s1) {
         Button open = (Button)sender;
         
         m.Show(open.Left + open.Width + s1.Left, open.Top + s1.Top);
         Load.bopen = open;
     
     }
     public void menewfoldierk(object sender, EventArgs e, Button button, ListView view1, ListView view2, TextBox TextBox)
     {
         switch (button.Name) {
             case "open":
                 {
                     FolderBrowserDialog op = new FolderBrowserDialog();
                     if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {

                         TextBox.Text = (op.SelectedPath);


                     }
                 }


                 break;
             case "open2":
                 {
                     conmad = new comander();
                     toolbox tool=new toolbox ();
                     TextOpejet ttext=new TextOpejet ();
                     FolderBrowserDialog op = new FolderBrowserDialog();
                     if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {
                        
                         {
                           if (p == -1)
                           {
                               if (conmad.find(op.SelectedPath, view2, 0))
                               {
                                   ListViewItem ithem = (ListViewItem)ttext.ListViewItem2(view2, op.SelectedPath); ;

                                   tool.combox(view2, ithem, 1);
                               }

                     }
                           else
                           {
                               view2.Items[p].SubItems[2].Text = op.SelectedPath;

                               p = -1;

                           }
                         }
                     }

                     
                 


                 break;

         }
     }}
     public  void files_Click(object sender, EventArgs e, Button button, ListView view1, ListView view2, TextBox TextBox) {

         switch (button.Name)
         {
             case "open":
                 {
                     OpenFileDialog openFileDialog1 = new OpenFileDialog();
                     openFileDialog1.Filter = "All files (*.*)|*.*";
                     if (openFileDialog1.ShowDialog() == DialogResult.OK) { TextBox.Text = openFileDialog1.FileName; }
                 } break;


         case "open2": {
            
                 conmad = new comander();
                 toolbox tool = new toolbox();
                 TextOpejet ttext = new TextOpejet();
                 OpenFileDialog openFileDialog1 = new OpenFileDialog();
                 openFileDialog1.Filter = "All files (*.*)|*.*";
                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                   
                         ListViewItem ithem = (ListViewItem)ttext.ListViewItem2(view2, openFileDialog1.FileName); ;

                         tool.combox(view2, ithem, 1);

                   
             }
             
         
         
         } break;
         
         
         
         }
     
     
     }
     public void cb_click2(object sender, EventArgs e) {
         ComboBox ComboBox = (ComboBox)sender;
         for (int i = 0; i < Lists.cobo2.Count; i++) {
             if (ComboBox == Lists.cobo2[i]) { p = i;
            
                 
                 ;
             
             }
         
         
         }
     
     
     }
     public void Trans_Click(object sender, EventArgs e,ListView view){


         comander.copymovdel(view);
     
     
     
     
     
     }//
    }
}