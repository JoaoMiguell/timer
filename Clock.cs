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
    Raylib.DrawText(this.Timer.Val.ToString(), _screenW / 2, _screenH / 2, 20, Color.WHITE);

  }
}

