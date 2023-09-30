using Raylib_cs;
using System.Threading;
using static QuickCodes.GlobalVar;

namespace QuickCodes;
internal class Clock {
  private int Val;

  public CTimer Timer { get; set; }
  public Thread WorkTimer { get; set; }

  public Clock(CTimer timer) {
    Timer = timer;
    WorkTimer = new(timer.Start);
    Val = timer.Val;
  }

  public void Draw() {
    int offSet = Raylib.MeasureText(Timer.Val.ToString(), 40);
    Raylib.DrawText(Timer.Val.ToString(),
      _screenW / 2 - offSet / 2, _screenH / 5 - 40,
      40, Color.WHITE);
  }
}

