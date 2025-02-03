# 💬Elevator simulator
### 엘리베이터 타다가 문득 알고리즘이 궁금해서 설계

- **GUI : C# Winform**
- **Algorithm : directional collective control && CSCAN 알고리즘과 유사**
  - 방향이 지정되면 그 방향으로 눌린 층수의 최대 혹은 최소 도달까지 방향 전환 불가능한 알고리즘 입니다.

- **멀티 스레딩**
  - Elevator.cs의 move() 함수는 ElevatorControl.cs의 Run() 함수를 통해 백그라운드 스레드로 while문이 계속 돌아가고 있음
  - 방향은 STOP, UP, DOWN => 초기 방향은 STOP, 초기 층수는 1층으로 설정
 
   
  - 메인스레드에서 내부버튼과 외부버튼이 계속 입력 받고 있음.
  - 내부 외부 버튼들은 Run 함수와 동기화를 Moniter로 동기화 되어있고 문열고닫을때 그리고 엘리베이터가 올라가고 내려갈때 2가지 경우에 thread.sleep()이 동작시에만 비동기처리
 
- **gif 예시**
  1. 외부 10층 down 버튼 클릭  - 1층에서
  2. 외부 4층 up 버튼 클릭     - 3층에서
  3. 내부 8층 버튼 클릭        - 7층에서
  4. 내부 2층 버튼 클릭        - 8층에서
  5. 외부 3층 down 버튼 클릭   - 10층에서

       
  **도착 순서 4층 -> 8층 -> 10층 -> 3층 -> 2층**
    
**예시 실행결과**

![_2025_02_03_23_39_14_523-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/9dfa5cfb-e146-4ab7-bcb8-be7378653309)

