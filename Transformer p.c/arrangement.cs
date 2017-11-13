using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace Transformer_p.c
{
    class arrangement
    {
        xml xml;
        public void open_folder(object sender, EventArgs e, S1 s1)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                s1.L1.Items.Add(op.SelectedPath);

                S1.processxml = true;
            }


        }
        public void delete_folder(object sender, EventArgs e, S1 s1)
        {

            s1.L1.Items.Remove(s1.L1.SelectedItem); ;
            S1.processxml = true;
        }
        public void Start(object sender, EventArgs e, S1 s1)
        {

            foreach (string foldername in s1.L1.Items)
            {


                if (File.Exists(foldername + "//" + "#nod201#.tea")) {


                    xml.openarr(foldername + "//" + "#nod201#.tea", s1);
                
                
                }



                else    arry(foldername);


            }


        }
        public void check(object sender, EventArgs e, S1 s1)
        {
            if (s1.L1.SelectedIndex == -1)
            {




                s1.handly.Checked = false;

                MessageBox.Show("Select Folder Please");




            }
            else
            {
                if (s1.handly.Checked)
                {
                    s1.handb.Enabled = true;

                    s1.handb1.Enabled = true;
                    s1.handb2.Enabled = true;
                    s1.atx.Enabled = true;
                    s1.atx1.Enabled = true;

                    s1.atx2.Enabled = true;

                    // s1.tree.Enabled = true;


                }
                else
                {
                    s1.handb.Enabled = false;

                    s1.handb1.Enabled = false;
                    s1.handb2.Enabled = false;
                    s1.atx.Enabled = false;
                    s1.atx1.Enabled = false;
                    s1.atx2.Enabled = false;

                    // s1.tree.Enabled = false;
                }
            }





        }
        public void clickl1(object sender, EventArgs e, S1 s1)
        {
            string file = s1.L1.SelectedItem + "//" + "#nod201#.tea";
            if (File.Exists(file))
                xml.listarr(file, s1);
            else { s1.tree.Nodes.Clear(); }
        }
        public void save(object sender, EventArgs e, S1 s1)
        {

            TreeNode ParentNode = new TreeNode();

            ParentNode.Text = s1.atx.Text;
            ParentNode.ForeColor = Color.Red;
            //  ParentNode.NodeFont = new Font("Times New Roman", 15.0f) ;
            s1.tree.Nodes.Add(ParentNode);

            TreeNode ChildNode1 = new TreeNode();
            if (s1.atx1.Text == "" || s1.atx1.Text == null) { ChildNode1.Text = "#.null##"; }
            else    ChildNode1.Text = s1.atx1.Text;
            ChildNode1.ForeColor = Color.Brown;
            ParentNode.Nodes.Add(ChildNode1);
            TreeNode ChildNode2 = new TreeNode();

            s1.atx2.Text = s1.atx2.Text.Replace(".", "");
            if (s1.atx2.Text == "" || s1.atx2.Text == null) { ChildNode2.Text = "#.null#"; }
            else   ChildNode2.Text = "." + s1.atx2.Text;

            ChildNode2.ForeColor = Color.Blue;
            ParentNode.Nodes.Add(ChildNode2);
            s1.atx.Text = s1.atx1.Text = s1.atx2.Text = "";

            xml = new xml();
            sexdxml(s1);
        }//end save

        public void _makeDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        public void objertDragDrop(object sender, DragEventArgs e, S1 s1)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string i in files)
            {
                if (Directory.Exists(i)) { s1.L1.Items.Add(i); }

            }
            S1.processxml = true;
        }


        public void delnode(object sender, EventArgs e, S1 sx)
        {
            try
            {
                if (sx.tree.SelectedNode == sx.tree.SelectedNode.Parent.Nodes[0])
                {
                    if (sx.atx1.Text == null || sx.atx1.Text == "") { sx.tree.SelectedNode.Parent.Nodes[0].Text = "#.null##"; }

                    else sx.tree.SelectedNode.Parent.Nodes[0].Text = sx.atx1.Text;
                }


                else if (sx.tree.SelectedNode == sx.tree.SelectedNode.Parent.Nodes[1])
                {
                    if (sx.atx2.Text == null || sx.atx2.Text == "") { sx.tree.SelectedNode.Parent.Nodes[1].Text = "#.null##"; }
                    else  sx.tree.SelectedNode.Parent.Nodes[1].Text = "." + sx.atx2.Text;
                }
            }
            catch
            {
                try
                {
                    if (sx.atx.Text == null || sx.atx.Text == "") { sx.tree.SelectedNode.Remove(); }
                    else { sx.tree.SelectedNode.Text = sx.atx.Text; }
                }
                catch { }
                //  if (sx.tree.Nodes  == null) { File.Delete(sx.L1.SelectedItem + "//" + "#nod201#.tea"); }

            }
            int i = 0;

            for (i = 0; i < sx.tree.Nodes.Count; i++) { };
            if (i == 0) {


               // File.SetAttributes(sx.L1.SelectedItem + "//" + "#nod201#.tea", FileAttributes.Normal );
                File.Delete(sx.L1.SelectedItem + "//" + "#nod201#.tea"); }
            //   sx.tree.SelectedNode.Text = "";
            //File.Delete(sx.L1.SelectedItem + "//" + "#nod201#.tea");
            xml.arrxml(sx);
        }//end del#node#

        public void delall(object sender, EventArgs e, S1 s1)
        {
            s1.tree.Nodes.Clear();


            File.Delete(s1.L1.SelectedItem + "//" + "#nod201#.tea");



        }// end delall

        public void arry(string folder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);

            try
            {
                // DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    // MessageBox.Show(d.Name);
                    if (!Directory.Exists((folder + "//" + "Directories")))

                        Directory.CreateDirectory(folder + "//" + "Directories");
                  

                    
                    
                    if (!d.Name.Contains("#."))
                    {
                        if (Directory.Exists(folder + "//" + "Directories" + "//" + d.Name.ToString())) {
                            DateTime dt = DateTime.Now;
                        string Time = dt.ToString("HHmmss");

                        try
                        {

                            Directory.Move(d.FullName, folder + "//" + "Directories" + "//" + d.Name.ToString()+Time);


                        }
                        catch { }





                        }//if (Directory.Exists
                        try
                        {

                            Directory.Move(d.FullName, folder + "//" + "Directories" + "//" + d.Name.ToString());


                        }
                        catch { }

                    }

                }

            }
            catch { }

            try
            {


                foreach (FileInfo f in dir.GetFiles())
                {

                    string str = Path.GetExtension(f.Name);
                    if (!Directory.Exists(folder + "//" + "#" + str))
                    {
                        Directory.CreateDirectory(folder + "//" + "#" + str);
                        //   f.MoveTo(folder + "//" + str+"//"+Path.GetFileName(f.FullName));



                    }

                    if (File.Exists(folder + "//" + "#" + str + "//" + Path.GetFileName(f.FullName)))
                    {
                        string name = Path.GetFileName(f.Name);
                        name = name.Replace(Path.GetExtension(name), "");

                        DateTime dt = DateTime.Now;
                        string Time = dt.ToString("HHmmss");
                        File.Copy(f.FullName, folder + "//" + "#" + str + "//" + name + Time + str);
                        File.Delete(f.FullName);
                    }
                    else
                    {
                        File.Move(f.FullName, folder + "//" + "#" + str + "//" + Path.GetFileName(f.FullName));
                    }
                }
            }
            catch { }



        }
        public void sexdxml(S1 s2) { xml.arrxml(s2); }
        public void folderloop( string filename ,string foldier, string word, string ext, S1 select)
        {
            string fol = Path.GetDirectoryName(filename);
            string movfolder = fol + "\\" + foldier;
            DirectoryInfo dir = new DirectoryInfo(fol);
           
            if (!Directory.Exists(movfolder ))
            {
                Directory.CreateDirectory(movfolder);
            } 
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    if (d.Name.Contains(word))
                    {
                        try { Directory.Move(d.FullName, movfolder + "\\" + d.Name.ToString()); }//end try

                        catch { }// end catch

                    }//d.Name.Contains(word)



                    
                }// end dir.GetDirectories

                foreach (FileInfo f in dir.GetFiles())
                {
                     if (f.Name.ToString() != "#nod201#.tea#nod201#.tea")
                        if (Path.GetFileName(f.Name).Contains(word))
                        {
                            if (File.Exists(movfolder + "\\" + Path.GetFileName(f.FullName)))
                            {
                                DateTime dt = DateTime.Now;
                                string Time = dt.ToString("HHmmss");

                                string name = Path.GetFileName(f.Name);
                                name = name.Replace(Path.GetExtension(name), "");

                                try
                                {

                                    File.Move(f.FullName, movfolder + "\\" + name + Time + Path.GetExtension(f.FullName));


                                }
                                catch { }}
          try { File.Move(f.FullName, movfolder + "\\" + Path.GetFileName(f.FullName)); }//end try

                                catch { }// end catch
                        
                            }
                }//  dir.GetFiles word
              
    
                foreach (FileInfo f in dir.GetFiles())
                {
                    if (f.Name.ToString() != "#nod201#.tea")
                    if (Path.GetExtension(f.Name ).Contains(ext))
                    {
                        if (File.Exists(movfolder + "\\" + Path.GetFileName(f.FullName)))
                        {
                            DateTime dt = DateTime.Now;
                            string Time = dt.ToString("HHmmss");

                            string name = Path.GetFileName(f.Name);
                            name = name.Replace(Path.GetExtension(name), "");
                           
                            try
                            {

                                File.Move(f.FullName, movfolder + "\\" + name + Time + Path.GetExtension(f.FullName)); 


                            }
                            catch { }
                        }//end file exists
     try { File.Move(f.FullName, movfolder + "\\" + Path.GetFileName(f.FullName)); }//end try

                        catch { }// end catch

                    }
                }//end f.Extension
            }

        }
    }

