using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ElevatorTest
{
    partial class Form1
    {
        Timer openDoor = new Timer();
        Timer closeDoor = new Timer();

        private int doorSpeed = 5;
        private int doorSpeedSum = 0;
        private int doorOpenWidth = 50;

        private void OpenDoor_Tick(object? sender, EventArgs e)
        {
            if (doorSpeedSum < doorOpenWidth)
            {
                doorSpeedSum += doorSpeed;
                pnLeftDoor.Left -= doorSpeed;
                pnRightDoor.Left += doorSpeed;

            }
            else
            {
                doorSpeedSum = 0;
                openDoor.Stop();
            }
        }

        private void CloseDoor_Tick(object? sender, EventArgs e)
        {
            if (doorSpeedSum < doorOpenWidth)
            {
                doorSpeedSum += doorSpeed;
                pnLeftDoor.Left += doorSpeed;
                pnRightDoor.Left -= doorSpeed;

            }
            else
            {
                doorSpeedSum = 0;
                closeDoor.Stop();
            }
        }

        private async void OpenCloseDoor()
        {
            openDoor.Start();

            await Task.Delay(2000);

            closeDoor.Start();
        }
    }
}
