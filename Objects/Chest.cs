using Godot;
using System;

public partial class Chest : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    private void OnProx(Boolean prox)
    {
        GetNode<CenterContainer>("Container").Visible = prox;
    }

    private void OnInteraction()
    {
        GD.Print("It just works!");
        //trigger opening animation
        //select 2 items
        //put items in Options Hbox, best bet is to implement them with buttons and textures from the control tree
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
