using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class zw_P : Form
    {
        public zw_P()
        {
            InitializeComponent();
            no.Text = pub.Sno;
            name.Text = pub.Sname;
            C.Text = pub.SC;
            G.Text = pub.SG;
            B.Text = pub.B;
            S.Text = pub.S;
            T.Text = pub.T;
            A.Text = pub.A;

        }
    }
}
