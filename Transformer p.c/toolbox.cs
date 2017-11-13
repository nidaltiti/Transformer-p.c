using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Transformer_p.c
{
    class toolbox
    {
        click click = new click();
        Size size = new Size();
        TextOpejet ti = new TextOpejet();
        int Sx, Sy, SB_x, SBf;
        public static bool check = false;
        public void combox(ListView view ,ListViewItem t,int i)
        { 
            switch (i)
            {  case 1:
                    {
                        Locationitem(view, t, i);
                        ComboBox cb = new ComboBox();

                        cb.Size = new System.Drawing.Size(SB_x-Sx, SBf);


                        cb.Location = new System.Drawing.Point(Sx, Sy);
                        cb.Click += delegate(object sender, EventArgs e) { click.cb_click2(sender, e); };
                        cb.SelectedIndexChanged += delegate(object sender, EventArgs e) { click.cb_SelectedIndexChanged(sender, e,view); };
                        
                        Lists.cobo2.Add(cb);
                        cb = (ComboBox)ti.combox(cb,i);
                        object s = cb;
                        view.Controls.Add(cb);
                    }
                
                
                
                
                break; 
                case 2:
                    {
                        Locationitem(view, t, i);
                        ComboBox cb = new ComboBox();

                        cb.Size = new System.Drawing.Size(SB_x, SBf);


                        cb.Location = new System.Drawing.Point(Sx, Sy);
                        cb.SelectedIndexChanged += delegate(object sender, EventArgs e) { click.cb_SelectedIndexChanged(sender, e, view); };
                        Lists.cobo.Add(cb);
                        cb = (ComboBox)ti.combox(cb,i);
                        object s = cb;
                        view.Controls.Add(cb);
                    }
                
                
                
                
                break; }
           

          //  return s;
        }

    
        public object textbox(ListView m ,ListViewItem t) {
            TextBox text = new TextBox();
          int  x = t.SubItems[0].Bounds.Location.X;
         int   y = t.SubItems[0].Bounds.Location.Y;
            int name = m.Items.Count - 1;
          int  si = t.SubItems[1].Bounds.X;
            text.Location = new System.Drawing.Point(x, y);
            text.Name = name.ToString();
           text.Size = new System.Drawing.Size(si, 0);
           text.KeyDown += delegate(object sender2, KeyEventArgs e2)
           {
              click.text_Enter(sender2, e2, name,m);
           }; ;

           m.Controls.Add(text);
           Lists.tebox.Add(text);
            object s= m ;
            return s;
        }



        public void textbox2(ListView m, int i ,int y)
        {
            TextBox text = new TextBox();
            Location(m, i, y);
            int name = i;
            //int si = m.Items[i].SubItems[1].Bounds.X;
            text.Location = new System.Drawing.Point(Sx, Sy);
            text.Name = i.ToString();
            text.Text = ti.listview(m, i, y);
            text.Size = new System.Drawing.Size(SB_x, 0);
            text.KeyDown += delegate(object sender2, KeyEventArgs e2)
            {
                click.text_Enter(sender2, e2, name, m);
            }; ;

            m.Controls.Add(text);
            Lists.tebox.Add(text);
           
          
        }
        void Location(ListView m,int i ,int y){

            Sx = size.place_i_X(m, i, y);
            Sy = size.place_i_Y(m, i, y);
            SB_x = size.place_tViewBound_X(m, i, y);
        
        }
        void Locationitem(ListView view, ListViewItem t, int i)
        {
            switch (i)
            {
                case 1:
                    {
                        Sx = size.ListViewItemX(t, i);
                        Sy = size.ListViewItemY(t, i);
                        SB_x = size.ListViewItemX(t, i+1); ;
                        SBf = size.ListViewItemBound_Y(t, i); ;
                    } break;
                case 2:
                    {
                        Sx = size.ListViewItemX(t, i);
                        Sy = size.ListViewItemY(t, i);
                        SB_x = size.ListViewIteWidth(t, view, i);
                        SBf = size.ListViewItemBound_Y(t, i); ;
                    } break;
            }
           
        
        
        }
        
        }
    
    
    
    }

