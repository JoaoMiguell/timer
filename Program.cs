using System;
using System.Threading.Tasks;
using Raylib_cs;

namespace QuickCodes {
  internal class Program {
    static void Main(string[] args) {
      const int _screenW = 300;
      const int _screenH = 300;
      Raylib.InitWindow(_screenW, _screenH, "Timer");
      Raylib.SetTargetFPS(60);

      CTimer clock = new CTimer(30);

      bool isOver = false;
      while(!isOver) {
        isOver = Raylib.WindowShouldClose();
        clock.update();
        Raylib.ClearBackground(Color.BLACK);
        Raylib.BeginDrawing();
        Raylib.DrawText(clock.Val.ToString(), _screenW / 2, _screenH / 2, 20, Color.WHITE);
        Raylib.EndDrawing();
      }

      Raylib.CloseWindow();
    }
  }


  class CTimer {
    public int Val { get; private set; }

    public CTimer(int val) {
      Val = val;
    }

    public void update() {
      Console.WriteLine(Val);
      Task.Delay(1000).Wait();
      Val--;
    }
  }
}