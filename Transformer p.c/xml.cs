using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Drawing;
namespace Transformer_p.c
{
    class xml
    {
        public static void listviewxml1(ListView view, ListView view2, ListBox box,S1 s1)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("process-program");
            XmlNode rootNode2 = xmlDoc.CreateElement("V1");
            //  XmlDocument xmlDoc2 = new XmlDocument();
            xmlDoc.AppendChild(rootNode);
            //     xmlDoc.AppendChild(rootNode2);
            for (int i = 0; i < Lists.cobo.Count; i++)
            {
                if (Lists.cobo[i].Text != "Delete")
                {



                    XmlNode userNode = xmlDoc.CreateElement("NameProcess");
                    XmlAttribute attribute = xmlDoc.CreateAttribute("procssing");
                    attribute.Value = Lists.cobo[i].Text;
                    userNode.Attributes.Append(attribute);
                    if (Uri.IsWellFormedUriString(view.Items[i].SubItems[1].Text, UriKind.Absolute))
                    {
                        attribute = xmlDoc.CreateAttribute("url");

                        attribute.Value = view.Items[i].SubItems[0].Text;
                        userNode.Attributes.Append(attribute);

                    }

                    userNode.InnerText = view.Items[i].SubItems[1].Text;
                    rootNode2.AppendChild(userNode);

                    rootNode.AppendChild(rootNode2);

                }

            }
            XmlNode userNode1 = xmlDoc.CreateElement("V2");
            for (int i = 0; i < Lists.cobo2.Count; i++)
            {
                if (Lists.cobo2[i].Text != "Delete form List")
                {
                    XmlNode userNode = xmlDoc.CreateElement("Namefile");
                    XmlAttribute attribute1 = xmlDoc.CreateAttribute("file");
                    XmlAttribute attribute = xmlDoc.CreateAttribute("Trans");
                    attribute1.Value = view2.Items[i].SubItems[0].Text;
                    attribute.Value = Lists.cobo2[i].Text;
                    userNode.Attributes.Append(attribute1);
                    userNode.Attributes.Append(attribute);
                    try
                    {
                        userNode.InnerText = view2.Items[i].SubItems[2].Text;
                    }
                    catch { userNode.InnerText = "Non"; }
                    userNode1.AppendChild(userNode);
                    rootNode.AppendChild(userNode1);

                }
            }
            XmlNode listbox = xmlDoc.CreateElement("listbox");

            for (int i = 0; i < box.Items.Count; i++)
            {
                XmlNode userNode = xmlDoc.CreateElement("Namefolder");

                userNode.InnerText = box.Items[i].ToString();

                listbox.AppendChild(userNode);
            }


            rootNode.AppendChild(listbox);




            XmlNode toolbox1 = xmlDoc.CreateElement("toolbox");

            XmlNode CheckBox1 = xmlDoc.CreateElement("CheckBox");
            XmlAttribute CheckBox1attribute = xmlDoc.CreateAttribute("checked");
            CheckBox1attribute.Value = toolbox.check.ToString();
            CheckBox1.Attributes.Append(CheckBox1attribute);

            toolbox1.AppendChild(CheckBox1);
          //  rootNode.AppendChild(toolbox1);


//


         

            XmlNode CheckBox11 = xmlDoc.CreateElement("auto");
            XmlAttribute CheckBox1attribute1 = xmlDoc.CreateAttribute("sen");
            CheckBox1attribute1.Value = s1.autotext.Text ;
            CheckBox11.Attributes.Append(CheckBox1attribute1);

            toolbox1.AppendChild(CheckBox11);
            rootNode.AppendChild(toolbox1); 
            
            
            
            //



            xmlDoc.Save("process.xml");

            S1.processxml = false;
        }
        public static void xml_v1(ListView view)
        {
            comander add = new comander();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("process.xml");
                XmlNodeList userNodes = xmlDoc.SelectNodes("//process-program/V1/NameProcess");
                int i = 0;

                foreach (XmlNode userNode in userNodes)
                {
                    if (!Uri.IsWellFormedUriString(userNode.InnerText, UriKind.Absolute))
                    {
                        add.drop(userNode.InnerText, view);
                        Lists.cobo[i].Text = userNode.Attributes["procssing"].Value;

                    }//end if
                    else
                    {
                        add.dropurl(userNode.InnerText, view, false, true);

                        Lists.cobo[i].Text = userNode.Attributes["procssing"].Value;
                        view.Items[i].SubItems[0].Text = userNode.Attributes["url"].Value;
                    }
                    i++;
                }
                //  xmlDoc.Save("test-doc.xml");           
            }
            catch { }





        }

        public static void xml_v2(ListView view)
        {
            comander add = new comander();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("process.xml");
                XmlNodeList userNodes = xmlDoc.SelectNodes("//process-program/V2/Namefile");
                int i = 0;

                foreach (XmlNode userNode in userNodes)
                {
                    add.drop(userNode.Attributes["file"].Value, view);
                    Lists.cobo2[i].Text = userNode.Attributes["Trans"].Value;
                    if (userNode.Attributes["Trans"].Value == "Delete") { view.Items[i].SubItems[2].Text = "Delete"; }
                    else
                    {

                        if (userNode.InnerText == "Delete") { view.Items[i].SubItems[2].Text = ""; }
                        else
                        {
                            view.Items[i].SubItems[2].Text = userNode.InnerText;
                        }
                    }


                    i++;

                }



            }



            catch { }
        }
        public static void xml_L1(ListBox view)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("process.xml");
                XmlNodeList userNodes = xmlDoc.SelectNodes("//process-program/listbox/Namefolder");

                foreach (XmlNode userNode in userNodes) { view.Items.Add(userNode.InnerText); }

            }
            catch { }


        }//end  xml_L1
        public static void chk(CheckBox chk,S1 s1)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("process.xml");
                XmlNodeList userNodes = xmlDoc.SelectNodes("//process-program/toolbox/CheckBox");


                foreach (XmlNode userNode in userNodes)
                {
                    chk.Checked = Convert.ToBoolean(userNode.Attributes["checked"].Value);


                }
               
                xmlDoc.Load("process.xml");
                userNodes = xmlDoc.SelectNodes("//process-program/toolbox/auto");


                foreach (XmlNode userNode in userNodes)
                {
                   s1.autotext.Text= userNode.Attributes["sen"].Value;


                }

            }//
            catch { }//



        }

        public static void arrxml(S1 s1)
        {

            try
            {

                int i = 0;
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("treeview");
                //    XmlNode userNode = xmlDoc.CreateElement("Nodes");

                foreach (TreeNode treeNode in s1.tree.Nodes)
                {
                    XmlNode userNode = xmlDoc.CreateElement("Nodes");
                    XmlAttribute attribute = xmlDoc.CreateAttribute("folder");
                    XmlAttribute attribute1 = xmlDoc.CreateAttribute("Word");
                    XmlAttribute attribute2 = xmlDoc.CreateAttribute("Path");

                    attribute.Value = treeNode.Text;

                    attribute1.Value = treeNode.Nodes[0].Text;
                    attribute2.Value = treeNode.Nodes[1].Text;
                    userNode.Attributes.Append(attribute);
                    userNode.Attributes.Append(attribute1);
                    userNode.Attributes.Append(attribute2);
                    rootNode.AppendChild(userNode);
                    i++;

                    xmlDoc.AppendChild(rootNode);

                }

                xmlDoc.Save(s1.L1.SelectedItem + "//" + "#nod201#.tea");
              //  File.SetAttributes(s1.L1.SelectedItem + "//" + "#nod201#.tea", FileAttributes.ReadOnly  );
            }
            catch
            {




            }



        }
        public static void listarr(string file, S1 s1)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNodeList userNodes = xmlDoc.SelectNodes("//treeview/Nodes");

                foreach (XmlNode userNode in userNodes)
                {


                    TreeNode ParentNode = new TreeNode();

                    ParentNode.Text = userNode.Attributes["folder"].Value;
                    ParentNode.ForeColor = Color.Red;
                    //  ParentNode.NodeFont = new Font("Times New Roman", 15.0f) ;
                    s1.tree.Nodes.Add(ParentNode);

                    TreeNode ChildNode1 = new TreeNode();
                    ChildNode1.Text = userNode.Attributes["Word"].Value;
                    ChildNode1.ForeColor = Color.Brown;
                    ParentNode.Nodes.Add(ChildNode1);
                    TreeNode ChildNode2 = new TreeNode();
                    ChildNode2.ForeColor = Color.Blue;
                    ChildNode2.Text = userNode.Attributes["Path"].Value;
                    ParentNode.Nodes.Add(ChildNode2);



                }

            }
            catch { }

        }
        public static void openarr(string file, S1 s1)
        {
            arrangement arr = new arrangement();
            string folder, word, ext;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNodeList userNodes = xmlDoc.SelectNodes("//treeview/Nodes");

                foreach (XmlNode userNode in userNodes)
                {
                    folder = userNode.Attributes["folder"].Value;
                    word= userNode.Attributes["Word"].Value;
                    ext = userNode.Attributes["Path"].Value;

                    arr.folderloop(file, folder, word, ext, s1);
                
                }

            }
            catch { }

        }
    }
}