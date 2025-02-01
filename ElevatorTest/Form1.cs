using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openDoor.Interval = 30;
            openDoor.Tick += OpenDoor_Tick;
            closeDoor.Tick += CloseDoor_Tick;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCloseDoor();
        }
    }
}
