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
        int _locationX = 0;
        int _locationY = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCloseDoor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // �� ���� �ݱ⿡ ���� Ÿ�̸� ���� - Door.cs
            openDoor.Interval = 30;
            openDoor.Tick += OpenDoor_Tick;
            closeDoor.Tick += CloseDoor_Tick;


            // ���ι�ư, �ܺι�ư�� ���� �� ����
            inside inForm = new();
            outside outForm = new();

            _locationX = this.Location.X + this.Width;
            _locationY = this.Location.Y;

            inForm.Location = new Point(_locationX, _locationY);
            inForm.Show();

            _locationX += inForm.Width;
            outForm.Location = new Point(_locationX, _locationY);
            outForm.Show();
        }
    }
}
