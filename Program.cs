using System;
using System.Threading;
using Raylib_cs;
using static QuickCodes.GlobalVar;

namespace QuickCodes;
internal class Program {
  static void Main(string[] args) {

    Raylib.InitWindow(_screenW, _screenH, "Timer");
    Raylib.SetTargetFPS(60);

    Clock clock = new(new CTimer(20));
    clock.WorkTimer.Start();
    clock.WorkTimer.IsBackground = true;

    bool isOver = false;
    while(!isOver) {
      isOver = Raylib.WindowShouldClose();

      Raylib.ClearBackground(Color.BLACK);
      Raylib.BeginDrawing();
      clock.Draw();
      Raylib.EndDrawing();
    }

    Raylib.CloseWindow();
    if(clock.WorkTimer.IsBackground) {
      try { clock.WorkTimer.Interrupt(); }
      catch(Exception) {
        Console.WriteLine("Unable to stop thread");
      }
    }
  }
}
