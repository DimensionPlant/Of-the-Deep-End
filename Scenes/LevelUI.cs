using Godot;
using System;

public partial class LevelUI : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Resize();
        //GetTree().Root.Connect("SizeChanged", this, "Resize");        
    }

    private void Resize()
    {
        Vector2 x = OS.WindowSize;
        RectScale *= x.Length()/RectSize.Length();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
