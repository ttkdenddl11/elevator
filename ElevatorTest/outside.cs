using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorTest
{
    public partial class outside : Form
    {
        public event EventHandler eventDelbtnOutsideClicked;
        public outside()
        {
            InitializeComponent();
        }

        private void btnOutside_Click(object sender, EventArgs e)
        {
            eventDelbtnOutsideClicked(sender, e);
        }
    }
}
