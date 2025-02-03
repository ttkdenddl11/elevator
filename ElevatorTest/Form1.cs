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
            // partial 된 Door.cs 내부에 있는 함수 호출
            OpenCloseDoor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 문 열고 닫기에 대한 타이머 세팅 - Door.cs
            openDoor.Interval = 30;
            openDoor.Tick += OpenDoor_Tick;
            closeDoor.Tick += CloseDoor_Tick;


            // 내부버튼, 외부버튼을 위한 폼 생성
            inside inForm = new();
            outside outForm = new();

            _locationX = this.Location.X + this.Width;
            _locationY = this.Location.Y;

            inForm.Location = new Point(_locationX, _locationY);
            inForm.Show();

            _locationX += inForm.Width;
            outForm.Location = new Point(_locationX, _locationY);
            outForm.Show();

            // 엘리베이터 움직이는 것은 계속 실행중
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
            // 현재 스레드가 UI 스레드가 아니면 Invoke로 UI 스레드에서 실행
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lblFloor.Text = FloorNum.ToString();  // UI 스레드에서 실행
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

            // 내부 버튼누른 층수 전달
            elevatorControl.TransBtnInside(btnFloor);
        }
    }
}
