using Raylib_cs;

namespace QuickCodes.UI;
internal class PauseButton : Button {
  public PauseButton(Rectangle rec, Color colorButton, string text)
    : base(rec, colorButton, text) { }

  public void ChangeStatus() {
    if(text == "Pause")
      text = "Resume";
    else
      text = "Pause";
  }

  public void Reset() {
    text = "Pause";
  }
}