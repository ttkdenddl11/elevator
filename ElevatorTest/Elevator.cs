using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace ElevatorTest
{
    enum ElevatorState{
        STOP,
        UP,
        DOWN,
    }
    
    //호출 버튼이 현재 층보다 위인지 아래인지 즉, 위로 가는 호출인지 아래로 가는 호출인지를 위한 구조체
    struct callInfo
    {
        public bool upCall;
        public bool downCall;

        public callInfo()
        {
            this.upCall = false;
            this.downCall = false;
        }
    }
    
    internal class Elevator
    {
        public delegate void delElevatorDoor();
        public event delElevatorDoor eventDelElevatorDoor;

        public delegate void delElevatorFloorText(int FloorNum);
        public event delElevatorFloorText evendDelElevatorFloorText;

        private object lockObject = new object();


        private ElevatorState currentState = ElevatorState.STOP;
        private int currentFloor = 1;

        private List<int> callList = new List<int>();
        callInfo[] callInfos = new callInfo[11];

        public void MoveFloor()
        {
            while (true)
            {
                // 위로 올라가는 방향일 경우
                if (currentState == ElevatorState.UP)
                {
                    moveUp();
                }
                // 아래로 내려가는 방향일 경우
                else if (currentState == ElevatorState.DOWN)
                {
                    moveDown();
                }
              
            }
        }

        private void moveUp()
        {
            
            while (true)
            {
                Monitor.Enter(lockObject);

                // 올라가는 경우이기 때문에 최고층에 올라갈 때까지 반복
                if (!(callList.Count > 0 && currentFloor <= callList.Max()))
                {
                    Monitor.Exit(lockObject);
                    break;
                }

                // 최고 층이 아닐 경우
                if (currentFloor != callList.Max())
                {
                    // 해당 층이 버튼이 눌린 리스트에 있고 위로 향하는 버튼 이었다면
                    if (callList.Contains(currentFloor) && callInfos[currentFloor].upCall == true)
                    {
                        callInfos[currentFloor].upCall = false;
                        if (callInfos[currentFloor].downCall == false)
                        {
                            callList.Remove(currentFloor);
                        }
                   

                        Monitor.Exit(lockObject);

                        // 문 열고 닫기
                        eventDelElevatorDoor();

                        Monitor.Enter(lockObject);
                    }
                }
                // 최고 층일 경우
                else
                {
                    // 최고층이면서 위에 버튼이 눌렸던 경우
                    if (callInfos[currentFloor].upCall == true)
                    {
                        callInfos[currentFloor].upCall = false;
                        if (callInfos[currentFloor].downCall == false)
                        {
                            callList.Remove(currentFloor);
                        }

                        Monitor.Exit(lockObject);

                        // 문 열고 닫기
                        eventDelElevatorDoor();

                        Monitor.Enter(lockObject);

                        // 둘 다 눌려 있던 경우는 아래층의 버튼이 눌려있기 때문에 리스트에서 제거 안했음
                        if (callList.Count > 0 && currentFloor == callList.Max())
                        {
                            Monitor.Exit(lockObject);
                            continue;
                        }
                        // 최고층이면서 위의 버튼이 눌러져 있었는데 방향 전환이 필요할 경우
                        else if(callList.Count > 0 && currentFloor > callList.Max())
                        {
                            currentState = ElevatorState.DOWN;
                            Monitor.Exit(lockObject);
                            break;
                        }

                        // 문 열고 닫은 후에도 안눌려 있으면
                        if (callList.Count == 0)
                        {
                            currentState = ElevatorState.STOP;
                            Monitor.Exit(lockObject);
                            break;
                        }
                    }
                    // 최고층이면서 아래 버튼이 눌렸던 경우
                    else if (callInfos[currentFloor].upCall == false && callInfos[currentFloor].downCall)
                    {
                        callInfos[currentFloor].downCall = false;
                        callList.Remove(currentFloor);

                        Monitor.Exit(lockObject);

                        // 문 열고 닫기
                        eventDelElevatorDoor();

                        Monitor.Enter(lockObject);

                        // 문 닫았는데 아무것도 안눌린 경우
                        if (callList.Count == 0)
                        {
                            currentState = ElevatorState.STOP;
                        }
                        else
                        {
                            currentState = ElevatorState.DOWN;
                        }
                        Monitor.Exit(lockObject);
                        break;
                    }
                }
                // 1초간 멈춘 후
                Monitor.Exit(lockObject);

                Thread.Sleep(1000);

                Monitor.Enter(lockObject);
   

                currentFloor++;
                // currentFloor 바뀐거 델리게이트로 알려줌 
                evendDelElevatorFloorText(currentFloor);

                Monitor.Exit(lockObject);
            }
        }

        private void moveDown()
        {

            while (true)
            {
                Monitor.Enter(lockObject);

                // 내려가는 경우이기 때문에 최저층에 내려갈 때까지 반복
                if (!(callList.Count > 0 && currentFloor >= callList.Min()))
                {
                    Monitor.Exit(lockObject);
                    break;
                }

                // 최저 층이 아닐 경우
                if (currentFloor != callList.Min())
                {
                    // 해당 층이 버튼이 눌린 리스트에 있고 아래로 향하는 버튼 이었다면
                    if (callList.Contains(currentFloor) && callInfos[currentFloor].downCall == true)
                    {
                        callInfos[currentFloor].downCall = false;
                        if (callInfos[currentFloor].upCall == false)
                        {
                            callList.Remove(currentFloor);
                        }


                        Monitor.Exit(lockObject);

                        // 문 열고 닫기
                        eventDelElevatorDoor();

                        Monitor.Enter(lockObject);
                    }
                }
                // 최저 층일 경우
                else
                {
                    // 최저층이면서 아래에 버튼이 눌렸던 경우
                    if (callInfos[currentFloor].downCall == true)
                    {
                        callInfos[currentFloor].downCall = false;
                        if (callInfos[currentFloor].upCall == false)
                        {
                            callList.Remove(currentFloor);
                        }

                        Monitor.Exit(lockObject);

                        // 문 열고 닫기
                        eventDelElevatorDoor();

                        Monitor.Enter(lockObject);

                        // 둘 다 눌려 있던 경우는 위층의 버튼이 눌려있기 때문에 리스트에서 제거 안했음
                        if (callList.Count > 0 && currentFloor == callList.Min())
                        {
                            Monitor.Exit(lockObject);
                            continue;
                        }
                        // 최고층이면서 위의 버튼이 눌러져 있었는데 방향 전환이 필요할 경우
                        else if (callList.Count > 0 && currentFloor < callList.Min())
                        {
                            currentState = ElevatorState.UP;
                            Monitor.Exit(lockObject);
                            break;
                        }

                        // 문 열고 닫은 후에도 안눌려 있으면
                        if (callList.Count == 0)
                        {
                            currentState = ElevatorState.STOP;
                            Monitor.Exit(lockObject);
                            break;
                        }
                    }
                    // 최저층이면서 위의 버튼이 눌렸던 경우
                    else if (callInfos[currentFloor].downCall == false && callInfos[currentFloor].upCall)
                    {
                        callInfos[currentFloor].upCall = false;
                        callList.Remove(currentFloor);

                        Monitor.Exit(lockObject);

                        // 문 열고 닫기
                        eventDelElevatorDoor();

                        Monitor.Enter(lockObject);

                        // 문 닫았는데 아무것도 안눌린 경우
                        if (callList.Count == 0)
                        {
                            currentState = ElevatorState.STOP;
                        }
                        else
                        {
                            currentState = ElevatorState.UP;
                        }
                        Monitor.Exit(lockObject);
                        break;
                    }
                }
                // 1초간 멈춘 후
                Monitor.Exit(lockObject);

                Thread.Sleep(1000);

                Monitor.Enter(lockObject);


                currentFloor--;
                // currentFloor 바뀐거 델리게이트로 알려줌 
                evendDelElevatorFloorText(currentFloor);

                Monitor.Exit(lockObject);
            }
        }

        // 엘리베이터 내부 버튼 눌렀을 때 동작 함수
        public void setCallList(int btnFloor)
        {
            Monitor.Enter(lockObject);
            // 내부에서 누른 층 수가 이미 눌러져 있지 않은 경우에만
            if (callList.Contains(btnFloor) == false)
            {
                // 현재 층이 누른 층보다 낮다면
                if(currentFloor < btnFloor)
                {
                    callList.Add(btnFloor);
                    // 누른 층 버튼 색깔 바꿀거면 여기서 델리게이트 호출

                    callInfos[btnFloor].upCall = true;

                    if(currentState == ElevatorState.STOP)
                    {
                        currentState = ElevatorState.UP;
                    }
                }
                // 현재 층이 누른 층보다 높다면
                else if(currentFloor > btnFloor)
                {
                    callList.Add(btnFloor);
                    // 누른 층 버튼 색깔 바꿀거면 여기서 델리게이트 호출

                    callInfos[btnFloor].downCall = true;

                    if (currentState == ElevatorState.STOP)
                    {
                        currentState = ElevatorState.DOWN;
                    }
                }
                // 현재 층이 누른 층과 같다면
                else
                {
                    // 일단 무시
                }
            }
            // 내부에서 해당 버튼이 눌러져 있을 경우엔 제거(향후 개발)
            else
            {

            }
            Monitor.Exit(lockObject);
        }
    }
}
