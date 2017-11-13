using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformer_p.c
{
    class Size
    {//--------                   ListViewItem------------------------------------------------------------------------
        public int ListViewItemX(ListViewItem t, int i) { return t.SubItems[i].Bounds.Location.X; }
        public int ListViewItemY(ListViewItem t, int i) { return t.SubItems[i].Bounds.Location.Y; }
        public int ListViewIteWidth(ListViewItem t, ListView listView  , int i) { return listView.Items[0].Bounds.Width - (t.SubItems[i].Bounds.Location.X); }

        public int ListViewItemBound_Y(ListViewItem t, int i) { return t.SubItems[i].Bounds.Y; }
        public int ListViewItemBound_X(ListViewItem t, int i) { return t.SubItems[i].Bounds.X; }
       //-----------------------------------------------------------------------------------------
        //   place  [] listview ------

        public int place_i_X(ListView t, int i,int y) { return t.Items[i].SubItems[y].Bounds.Location.X; }

        public int place_i_Y(ListView t, int i,int y) { return t.Items[i].SubItems[y].Bounds.Location.Y; }
        public int place_tViewBound_X(ListView t, int i, int y) { return t.Items[i].SubItems[y].Bounds.X; }
        //----------------------------------------------------
    
    }
}
