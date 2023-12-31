﻿using Raylib_cs;
using static QuickCodes.GlobalVar;

namespace QuickCodes.UI;
internal class Input {
  public Rectangle rec { get; set; }
  public string text { get; set; } = string.Empty;
  public bool isFocus { get; set; } = false;
  public char[] options = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
  private Color mainColor = Color.LIGHTGRAY;
  private Color textColor = Color.BLACK;

  public Input(Rectangle rec) {
    this.rec = rec;
  }

  public void Draw() {
    Raylib.DrawRectangleRec(rec, mainColor);
    Raylib.DrawText(text, (_screenW / 2) - (Raylib.MeasureText(text, 50) / 2), (int)rec.y + 5, 50, textColor);
  }

  public void setNotClickable() {
    mainColor = Color.DARKGRAY;
    textColor = Color.LIGHTGRAY;
  }

  public void setClickable() {
    mainColor = Color.LIGHTGRAY;
    textColor = Color.BLACK;
  }
}