using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VTManager.Interactive
{
public abstract class VTManagerPage : Page {

        public static Frame ThisFrame;

        VTManagerPage(Frame frame) {
            ThisFrame = frame;
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 120000;
            timer1.Tick += t_Tick;
            timer1.Enabled = true;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            ThisFrame.Refresh();
        }
    }
}
