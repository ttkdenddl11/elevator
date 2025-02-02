using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorTest
{
    public partial class inside : Form
    {
        public inside()
        {
            InitializeComponent();

            btnCircular();
        }

        // 10개의 버튼 원형으로 만들기
        private void btnCircular()
        {
            for (int i = 1; i <= 10; i++)
            {
                string buttonName = "btnInside" + i; // 버튼 이름 동적 생성
                Control[] foundControls = this.Controls.Find(buttonName, true);

                if (foundControls.Length > 0 && foundControls[0] is Button btn) // 버튼이 있으면 실행
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0, 0, btnInside1.Width, btnInside1.Height);
                    btn.Region = new Region(path);

                    // 버튼의 Paint 이벤트 핸들러 추가 (테두리 그리기)
                    btn.Paint += (s, e) =>
                    {
                        using (Pen pen = new Pen(Color.Black, 1)) // 검은색 테두리, 두께 1
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // 부드럽게 그리기
                            e.Graphics.DrawEllipse(pen, 1, 1, btn.Width - 3, btn.Height - 3); // 테두리 그리기
                        }
                    };
                }
            }
        }
    }
}
