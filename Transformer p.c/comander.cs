using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Transformer_p.c
{
    class comander
    {

        toolbox tool;
        TextOpejet ttext = new TextOpejet();
        // toolbox tool = new toolbox();
        public void drop(string namefile, ListView view)
        {
            switch (view.Name)
            {
                case "v1":
                    {
                        if (File.Exists(namefile) || Directory.Exists(namefile))
                            if (find(namefile, view, 1))
                            {
                                tool = new toolbox();
                                ListViewItem item;
                                item = (ListViewItem)ttext.ListViewItem(view, namefile);


                                tool.combox(view, item, 2);
                            }


                        break;
                    }
                case "v2":
                    {
                        if (File.Exists(namefile))
                        { if(find(namefile,view ,0)){
                            tool = new toolbox();
                            ListViewItem ithem = (ListViewItem)ttext.ListViewItem2(view, namefile); ;

                            tool.combox(view, ithem, 1);}
                        }
                        else
                        {
                            if (click.p == -1)
                            {
                                tool = new toolbox();
                                ListViewItem ithem = (ListViewItem)ttext.ListViewItem2(view, namefile); ;

                                tool.combox(view, ithem, 1);
                            }
                            else
                            {
                                view.Items[click.p].SubItems[2].Text = namefile;

                                click.p = -1;

                            }
                        }
                        break;
                    }




            }

        }
        public void dropurl(string url, ListView view, bool textbox, bool comobo)
        {
            if (findurl(url, view))
                tool = new toolbox();
            ListViewItem item;
            item = (ListViewItem)ttext.ListViewItem(view, url);

            if (textbox)
                tool.textbox(view, item);
            if (comobo)
                tool.combox(view, item, 2);
        }


        private bool findurl(string url, ListView view)// find url in list or no 
        {
            for (int i = 0; i < view.Items.Count; i++)
            {

                if ((url) == view.Items[i].SubItems[1].Text) { return false; }

            }


            return true;
        }
        public bool find(string name, ListView view, int s) // find file path  on list or no 
        {


            for (int i = 0; i < view.Items.Count; i++)
            {

                if (name == view.Items[i].SubItems[s].Text) { return false; }

            }


            return true;
        }

        public static void copymovdel(ListView view)

        {
            int i = 0;
            foreach (ListViewItem Item in view.Items)
            {

                switch (Lists.cobo2[i].Text)
                {
                    case "move To": {

                        try
                        {
                            if (File.Exists(Item.SubItems[0].Text))
                            {
                                if (File.Exists(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text))) { File.Delete(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text)); }
                                File.Move(Item.SubItems[0].Text, Item.SubItems[2].Text +"\\"+Path.GetFileName(Item.SubItems[0].Text));





                            }//
                            else
                            {
                                string d = Path.GetFileName(Item.SubItems[0].Text);

                                if (Directory.Exists(Item.SubItems[0].Text))
                                {

                                    if (Directory.Exists(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text)))
                                    {
                                 
                                        //  MessageBox.Show(d);
                                        comander del = new comander();
                                        if (Directory.Exists(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text)))
                                        {
                                            MessageBox.Show("pk");
                                            Directory.Delete(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text), true);

                                        }
                                      //  del.clearFolder(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text));
                                       // Directory.Delete(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text), true);



                                    }
                                }
                              
                              Directory.Move(Item.SubItems[0].Text, Item.SubItems[2].Text+"//"+d);
                           
                            
                            
                            }
                        }//
                        catch { }

                    
                    }//
                        break;
                    case "Copy":
                        {

                            try
                            {
                                //MessageBox.Show("");
                                if (File.Exists(Item.SubItems[0].Text))
                                {
                                    if (File.Exists(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text))) { File.Delete(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text)); }

                                    File.Copy(Item.SubItems[0].Text, Path.Combine(Item.SubItems[2].Text, Path.GetFileName(Item.SubItems[0].Text)), true);

                                }//
                                else
                                {
                                     if (Directory.Exists(Item.SubItems[0].Text))
                                    {
                                    string dir = Path.GetFileName(Item.SubItems[0].Text);
                                    if (Directory.Exists(Item.SubItems[2].Text + "//" + Path.GetFileName(Item.SubItems[0].Text)))
                                    {
                                        MessageBox.Show("pk");
                                       Directory.Delete(Item.SubItems[2].Text + "//" + Path.GetFileName (Item.SubItems[0].Text), true);
                                       
                                    }
                                            // MessageBox.Show(dir);
                                           // Directory.Delete(Item.SubItems[2].Text + "//" + dir, true);


                                         
                                        
                                        //  Directory.Delete(Item.SubItems[2].Text + "/" + dir,true);
                                       DirectoryCopy(Item.SubItems[0].Text, Item.SubItems[2].Text + "//" + dir, true);
                                    }
                                }//
                            }
                            catch { }
                        }



                        break;
                    case "Delete":
                        {
                            try
                            {
                                if (File.Exists(Item.SubItems[0].Text))
                                {
                                   
                                    File.Delete(Item.SubItems[0].Text);


                                


                                }//
                                else
                                {
                                    comander del = new comander();


                                    if (Directory.Exists(Item.SubItems[0].Text))
                                    {
                                        //DirectoryInfo dir = new DirectoryInfo(Item.SubItems[0].Text);
                                        //DirectoryInfo[] dirs = dir.GetDirectories();

                                        //foreach (DirectoryInfo d in dirs)
                                        //{
                                        //    del.clearFolder((Item.SubItems[0].Text));
                                        //    Directory.Delete(Item.SubItems[0].Text, true);
                                        //}
                                        Directory.Delete(Item.SubItems[0].Text, true);

                                    }
                                    
                                    
                                 
                                    


                                }//
                            }//
                            catch { }




                        }//

                        break; ;




                }//

                i++;

            }//


            


        }
        public  void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);
            DirectoryInfo[] dirs = dir.GetDirectories();
          
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dirs)
            {
                MessageBox.Show(di.Name);
                Directory.Delete(di.FullName, true);
                
                clearFolder(di.FullName);
              
            }
        }
        private static void DirectoryCopy( string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }

            }
        }
        
        public static void  auto(Timer a, ListView view) {

            a.Stop();
            copymovdel(view);
            a.Start();
        
        
        }
       
        
        
        }
    }

