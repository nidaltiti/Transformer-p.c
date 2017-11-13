using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Transformer_p.c
{
    class Load
    {
        //S1 s1 = new S1();
        click click2 = new click();
       

        public static Button bopen;
        public void listview(ListView view, ListView view2 ,S1 s1)
        {

            v1_Load(view);

            v2_Load(view2,s1); 
            
            
           

        }
        public void v1_Load(ListView view)
        {
            view.MouseDown += delegate(object sender2, MouseEventArgs e2)
            {

                click2.listView1_MouseDown(sender2, e2);


            };
            view.MouseDoubleClick += delegate(object sender2, MouseEventArgs e2) { click2.moudclick(sender2, e2); };
            view.DragOver += delegate(object sender, DragEventArgs e2)
            {
                click2._makeDragOver(sender, e2);
            };
            view.DragDrop += delegate(object sender, DragEventArgs e2)
            {
                click2.objertDragDrop (sender, e2,view);
            };
            xml.xml_v1(view);
           
            try{
                int i = 0;
                foreach (ListViewItem p in view.Items) {

                    if (Lists.cobo[i].Text != "Non")
                    
                    Process.Start(p.SubItems[1].Text);
                    i++;
                
                }
            }catch{}
            
            
            }

        public void v2_Load(ListView view, S1 check)
        {


            view.DragOver += delegate(object sender, DragEventArgs e2)
            {
                click2._makeDragOver(sender, e2);
            };
            view.DragDrop += delegate(object sender, DragEventArgs e2)
            {
                click2.objertDragDrop(sender, e2, view);
            };



            view.AllowDrop = true;
            xml.xml_v2(view);
            xml.chk(check.t2,check);
            if (check.t2.Checked) { check.auto.Start(); }
        
        }
        public void loadbutton(Button o1,Button o2,S1 s1,ContextMenuStrip m,Button t1){

            o1.Click += delegate(object sender, EventArgs e) { click2.open_Click(sender, e, m, s1); };

            o2.Click += delegate(object sender, EventArgs e) { click2.open_Click(sender, e, m, s1); };

            m.Items[0].Click += delegate(object sender, EventArgs e) { click2. menewfoldierk( sender,  e, bopen , s1.v1 , s1.v2,s1.textprocess) ;};

            m.Items[1].Click += delegate(object sender, EventArgs e) { click2.files_Click(sender, e, bopen, s1.v1, s1.v2, s1.textprocess); };
            t1.Click += delegate(object sender, EventArgs e) { click2.Trans_Click(sender, e, s1.v2); };
        }

        public void loadager(S1 s1) { 
         arrangement arr=new arrangement ();
         s1.L1.AllowDrop = true;
         s1.L1.DragOver += delegate(object sender, DragEventArgs e) { arr._makeDragOver(sender, e); };
         s1.L1.DragDrop += delegate(object sender, DragEventArgs e) { arr.objertDragDrop(sender, e, s1); };
         s1.L1.Click += delegate(object sender, EventArgs e) { arr.clickl1(sender, e, s1); };
            s1.abopen.Click += delegate(object sender, EventArgs e) { arr.open_folder(sender, e,s1); };

         s1.abdetet.Click += delegate(object sender, EventArgs e) { arr.delete_folder(sender, e, s1); };

         s1.abStrat.Click += delegate(object sender, EventArgs e) { arr.Start (sender, e, s1); };
         s1.handly.CheckedChanged += delegate(object sender, EventArgs e) { arr.check(sender, e, s1); };
         s1.handb.Click += delegate(object sender, EventArgs e) { arr.save (sender, e, s1); };


         s1.handb1.Click += delegate(object sender, EventArgs e) { arr.delnode(sender, e, s1); };
         s1.handb2.Click += delegate(object sender, EventArgs e) { arr.delall(sender, e, s1); }; 
            
            if (s1.handly.Checked)
         {
             s1.handb.Enabled = true;

             s1.handb1.Enabled = true;
             s1.handb2.Enabled = true;
             s1.atx.Enabled = true;
             s1.atx1.Enabled = true;
             s1.atx2.Enabled = true;

           //  s1.tree.Enabled = true;


         }
         else
         {
             s1.handb.Enabled = false ;

             s1.handb1.Enabled = false;
             s1.handb2.Enabled = false;
             s1.atx.Enabled = false;
             s1.atx1.Enabled = false;
             s1.atx2.Enabled = false;

           //  s1.tree.Enabled = false;
         }

            xml xml = new xml();
            xml.xml_L1(s1.L1);
        }
    }
}