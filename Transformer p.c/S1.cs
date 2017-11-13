using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Transformer_p.c
{
    public partial class S1 : Form
    {
        public S1()
        {
            InitializeComponent();
            //   x = 0; y = 30;
        }

        public static int second =0;
        TextOpejet ttext = new TextOpejet();
        Lists lists = new Lists();
        //Size size = new Size();
        Load load1 = new Load();
        toolbox tool = new toolbox();
        ListViewItem item;
        public static bool processxml = false;
        private void S1_Load(object sender, EventArgs e)
        {
            load1.listview(v1,v2,this );
           // load1.listview(v2);
            load1.loadbutton(open, open2, this, meuopen,t1);
            load1.loadager(this);
            
            // this.reportViewer1.RefreshReport();
        }

        public void add_Click(object sender, EventArgs e)
        {
            if (textprocess.Text != "")
            {
                if (!Uri.IsWellFormedUriString(textprocess.Text, UriKind.Absolute))
                {
                    if (File.Exists(textprocess.Text) || Directory.Exists(textprocess.Text))
                        if (find())
                        {

                            item = (ListViewItem)ttext.ListViewItem(v1, textprocess.Text);


                            tool.combox(v1, item, 2);


                        }
                }
                else
                {
                    if (findurl())
                    {


                        item = (ListViewItem)ttext.ListViewItem(v1, textprocess.Text);
                        tool.textbox(v1, item);
                        tool.combox(v1, item, 2);

                    }
                }
                processxml = true;
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            meuopen.Show(open.Left + open.Width + this.Left, open.Top + this.Top);
        }



        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { textprocess.Text = openFileDialog1.FileName; }
        }

        private void process_Click(object sender, EventArgs e)
        {
            try { Process.Start(textprocess.Text); }
            catch { }
        }

        private bool find() // find file path  on list or no 
        {


            for (int i = 0; i < v1.Items.Count; i++)
            {

                if (textprocess.Text == v1.Items[i].SubItems[1].Text) { return false; }
                // if(Uri.IsWellFormedUriString(textprocess.Text, UriKind.Absolute)==Uri.IsWellFormedUriString( listView1.Items[i].SubItems[1].Text, UriKind.Absolute)){ return false;}
            }


            return true;
        }

        private bool findurl()// find url in list or no 
        {
            for (int i = 0; i < v1.Items.Count; i++)
            {

                if ((textprocess.Text) == v1.Items[i].SubItems[1].Text) { return false; }

            }


            return true;
        }



        private void timer1_Tick(object sender, EventArgs e)
        { 
            lists.changeSize1(v1);
            if (processxml) { xml.listviewxml1(v1,v2,L1,this );  }


          
           

            lists.changeSize2(v2);
           // second++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(tabControl1);


            this.Controls.Add(v1 );






        }

        private void t2_CheckedChanged(object sender, EventArgs e)
        {
            processxml = true;
        }

        private void t2_Click(object sender, EventArgs e)
        {
            if (t2.Checked) {

                toolbox.check = true;
                
                processxml = true; auto.Start(); }
            else {
                toolbox.check = false;
                
                processxml = true; auto.Stop(); }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            arrangement arr = new arrangement();
            second++;
            try { if (second == Convert.ToInt32(autotext.Text))  { arr.Start(sender, e, this); comander.auto(auto, v2); second = 0; } }
            catch { } 
        //   label1.Text = second.ToString();

        }

        private void autotext_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sen = autotext.Text;
            if (!char.IsNumber(e.KeyChar)) { e.Handled = true; }

            if (e.KeyChar == 8) { e.Handled = false; }
            if (autotext.Text == "") { autotext.Text =sen; }
        
        
        }

       

      

      
       
      

     
      
       

       

      

    }
}
