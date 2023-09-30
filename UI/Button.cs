using Raylib_cs;

namespace QuickCodes.UI;
internal abstract class Button {
  public Rectangle rec { get; set; }
  protected Color colorButton;
  protected string text;

  protected Button(Rectangle rec, Color colorButton, string text) {
    this.rec = rec;
    this.colorButton = colorButton;
    this.text = text;
  }

  public void Draw() {
    Raylib.DrawRectangleRec(rec, colorButton);
    Raylib.DrawText(text, (int)rec.x + (Raylib.MeasureText(text, 15) / 2), (int)rec.y + 5, 30, Color.WHITE);
  }
}

