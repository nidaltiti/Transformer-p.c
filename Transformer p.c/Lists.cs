using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Transformer_p.c
{
    class Lists : list
    {
        public static List<ComboBox> cobo = new List<ComboBox>();
        public static List<TextBox> tebox = new List<TextBox>();
        public static List<ComboBox> cobo2 = new List<ComboBox>();
        public void changeSize1(ListView listview)
        {
            try
            {
                int n = 0;

                foreach (ComboBox i in cobo)
                {
                    int x = listview.Items[n].SubItems[2].Bounds.Location.X;
                    int y = listview.Items[n].SubItems[2].Bounds.Location.Y;
                    int si = listview.Items[n].Bounds.Width - (listview.Items[n].SubItems[2].Bounds.Location.X);
                    int f = listview.Items[n].SubItems[2].Bounds.Y;
                    i.Size = new System.Drawing.Size(si, f);
                    i.Location = new System.Drawing.Point(x, y);
                    n++;





                }

            }
            catch { }
            try
            {
                foreach (TextBox textbox in tebox)
                {

                    int i = Convert.ToInt32(textbox.Name);
                    int x = listview.Items[i].SubItems[0].Bounds.Location.X;
                    int y = listview.Items[i].SubItems[0].Bounds.Location.Y;
                    textbox.Location = new System.Drawing.Point(x, y);

                    int si = listview.Items[i].SubItems[1].Bounds.Location.X;
                    textbox.Size = new System.Drawing.Size(si, 0);
                }
            }
            catch { }
        }
        public void changeSize2(ListView listview)
        {
            try
            {
                int n = 0;

                foreach (ComboBox i in cobo2)
                {
                    int x = listview.Items[n].SubItems[1].Bounds.Location.X;
                    int y = listview.Items[n].SubItems[1].Bounds.Location.Y;
                    int si = listview.Items[n].SubItems[2].Bounds.Location.X - (listview.Items[n].SubItems[1].Bounds.Location.X);
                    int f = listview.Items[n].SubItems[1].Bounds.Y;
                    i.Size = new System.Drawing.Size(si, f);
                    i.Location = new System.Drawing.Point(x, y);
                    n++;





                }
            }
            catch { }
        }
    }
}