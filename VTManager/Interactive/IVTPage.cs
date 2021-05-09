using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTManager.Interactive
{
    interface IVTPage
    {
        void navigate(string url);
        void refresh();
    }
}
