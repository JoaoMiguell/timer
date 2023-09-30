using System;
using Raylib_cs;
using static QuickCodes.GlobalVar;
using QuickCodes.UI;
using System.Linq;
using System.Threading;

namespace QuickCodes;
internal class Program {
  static void Main(string[] args) {
    // Raylib config
    Raylib.InitWindow(_screenW, _screenH, "Timer");
    Raylib.SetTargetFPS(60);

    // Init things
    Clock clock = new(new CTimer());

    // UI
    Input input = new Input(new Rectangle(_screenW / 2 - 100, _screenH / 2 - 50, 200, 50));
    StartButton startButton = new(new Rectangle(_screenW / 2 - 80, input.rec.y + 60, 160, 40), Color.GREEN, "Start");
    PauseButton pauseButton = new(new Rectangle(_screenW / 2 - 80, startButton.rec.y + 50, 160, 40), Color.BLUE, "Pause");
    ResetButton resetButton = new(new Rectangle(_screenW / 2 - 80, pauseButton.rec.y + 50, 160, 40), Color.RED, "Reset");

    // Main loop
    bool isOver = false;
    while(!isOver) {
      isOver = Raylib.WindowShouldClose();
      // Input 
      if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
        && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), input.rec)
        && !clock.WorkTimer.IsBackground) {
        input.isFocus = true;
        input.setClickable();
      }
      if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
        && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), startButton.rec)
        && input.text.Length != 0
        && !clock.WorkTimer.IsBackground) {
        clock.Timer.Val = int.Parse(input.text);
        clock.WorkTimer.Start();
        clock.WorkTimer.IsBackground = true;
        input.setNotClickable();
        input.isFocus = false;
      }
      if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
        && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), pauseButton.rec)
        && clock.WorkTimer.IsBackground) {
        clock.Timer.isPaused = !clock.Timer.isPaused;
        pauseButton.ChangeStatus();
      }
      if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)
        && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), resetButton.rec)
        && clock.WorkTimer.IsBackground) {
        clock.WorkTimer.IsBackground = false;
        clock.WorkTimer = new Thread(clock.Timer.Start);
        pauseButton.Reset();
        clock.Timer.Reset();
        input.setClickable();
      }


      // Make/Update things
      if(input.isFocus) {
        char key = (char)Raylib.GetKeyPressed();

        if(input.text.Length != 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)) {
          input.text = input.text.Substring(0, input.text.Length - 1);
        }
        else if(input.text.Length < 4 && key != '\0'
          && !Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)
          && input.options.Contains(key))
          input.text = $"{input.text}{key}";
      }

      // DRAW
      Raylib.ClearBackground(Color.BLACK);
      Raylib.BeginDrawing();
      clock.Draw();
      input.Draw();
      startButton.Draw();
      pauseButton.Draw();
      resetButton.Draw();
      Raylib.EndDrawing();
    }

    // Close and stop things
    Raylib.CloseWindow();
    if(clock.WorkTimer.IsAlive) {
      try {
        clock.WorkTimer.Interrupt();
        Console.WriteLine("INFO: Thread ended");
      }
      catch(Exception) {
        Console.WriteLine("Unable to stop thread");
      }
    }
  }
}
