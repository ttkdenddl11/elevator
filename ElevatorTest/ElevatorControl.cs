﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTest
{
    internal class ElevatorControl
    {
        Elevator elevator1;

        public delegate void delElevatorDoor();
        public event delElevatorDoor evendDelElevatorDoor;

        public delegate void delElevatorFloorText(int FloorNum);
        public event delElevatorFloorText evendDelElevatorFloorText;

        // 생성자
        public ElevatorControl()
        {
            elevator1 = new Elevator();

            elevator1.eventDelElevatorDoor += Elevator1_eventDelElevatorDoor;

            elevator1.evendDelElevatorFloorText += Elevator1_eventDelElevatorFloorText;
        }

        public void Run()
        {
            elevator1.MoveFloor();
        }
        
        // 내부에서 누른 버튼 받아와서 세팅 값으로 전달해주기 위한 컨트롤 함수
        public void TransBtnInside(int btnFloor)
        {
            elevator1.setCallList(btnFloor);
        }

        public void Elevator1_eventDelElevatorDoor()
        {
            evendDelElevatorDoor();
        }
        public void Elevator1_eventDelElevatorFloorText(int FloorNum)
        {
            evendDelElevatorFloorText(FloorNum);
        }
    }
}
