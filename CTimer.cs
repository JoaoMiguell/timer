using System;
using System.Threading.Tasks;
namespace QuickCodes;

internal class CTimer {
  public int Val { get; private set; } = 0;

  public void Start() {
    while(Val > 0) {
      Console.WriteLine(Val);
      Task.Delay(1000).Wait();
      Val--;
    }
  }
}
