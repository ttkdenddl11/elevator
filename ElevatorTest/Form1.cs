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

        Thread thread;
        ElevatorControl elevatorControl;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // partial �� Door.cs ���ο� �ִ� �Լ� ȣ��
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

            // ���������� �����̴� ���� ��� ������
            elevatorControl = new ElevatorControl();

            thread = new Thread(elevatorControl.Run);
            thread.IsBackground = true;
            thread.Start();

            inForm.eventDelbtnInsideClicked += InForm_eventDelbtnInsideClicked;
            elevatorControl.evendDelElevatorDoor += ElevatorControl_evendDelElevatorDoor;
            elevatorControl.evendDelElevatorFloorText += ElevatorControl_evendDelElevatorFloorText;


        }

        private void ElevatorControl_evendDelElevatorDoor()
        {
            OpenCloseDoor();
        }

        private void ElevatorControl_evendDelElevatorFloorText(int FloorNum)
        {
            // ���� �����尡 UI �����尡 �ƴϸ� Invoke�� UI �����忡�� ����
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lblFloor.Text = FloorNum.ToString();  // UI �����忡�� ����
                }));
            }
        }

        private void InForm_eventDelbtnInsideClicked(object? sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null) return;

            int btnFloor = 1;

            switch (btn.Name)
            {
                case "btnInside1":
                    btnFloor = 1;
                    break;

                case "btnInside2":
                    btnFloor = 2;
                    break;

                case "btnInside3":
                    btnFloor = 3;
                    break;

                case "btnInside4":
                    btnFloor = 4;
                    break;

                case "btnInside5":
                    btnFloor = 5;
                    break;

                case "btnInside6":
                    btnFloor = 6;
                    break;

                case "btnInside7":
                    btnFloor = 7;
                    break;

                case "btnInside8":
                    btnFloor = 8;
                    break;

                case "btnInside9":
                    btnFloor = 9;
                    break;

                case "btnInside10":
                    btnFloor = 10;
                    break;

                default:
                    break;
            }

            // ���� ��ư���� ���� ����
            elevatorControl.TransBtnInside(btnFloor);
        }
    }
}
