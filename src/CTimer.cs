using System.Threading.Tasks;

namespace QuickCodes;
internal class CTimer {
  public int Val { get; set; } = 0;
  public bool isPaused { get; set; } = false;

  public void Start() {
    while(Val > 0) {
      Task.Delay(1000).Wait();
      if(isPaused) continue;
      Val--;
    }
  }

  public void Reset() {
    Val = 0;
    isPaused = false;
  }
}
