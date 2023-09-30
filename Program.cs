using System;
using Raylib_cs;
using static QuickCodes.GlobalVar;
using QuickCodes.UI;
using System.Linq;

namespace QuickCodes;
internal class Program {
  static void Main(string[] args) {
    // Raylib config
    Raylib.InitWindow(_screenW, _screenH, "Timer");
    Raylib.SetTargetFPS(60);

    // Init things
    Clock clock = new(new CTimer());

    // UI
    Input input = new Input(new Rectangle(_screenW / 2 - 100, _screenH / 2, 200, 50));

    // Main loop
    bool isOver = false;
    while(!isOver) {
      isOver = Raylib.WindowShouldClose();
      // Input 
      if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), input.rec))
        input.isFocus = true;

      // TODO: Fazer o Input do timer
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
      Raylib.DrawFPS(5, 5);
      clock.Draw();
      input.Draw();
      Raylib.EndDrawing();
    }

    // Close and stop things
    Raylib.CloseWindow();
    if(clock.WorkTimer.IsBackground) {
      try {
        clock.WorkTimer.Interrupt();
        Console.WriteLine("Thread ended!");
      }
      catch(Exception) {
        Console.WriteLine("Unable to stop thread");
      }
    }
  }
}
