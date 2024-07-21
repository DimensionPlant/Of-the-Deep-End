using Godot;
using System;
using System.Net.Security;

public partial class InteractComponent : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Boolean Close;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Close = false;
        
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        //if Close and interact
        //roll for items and make both buttons visible
        if(Close&&Input.IsActionJustPressed("interact"))
        {
            EmitSignal(nameof(Interacted));
        }
    }

    private void InRange(object area)
    {
        //still needs to implemented
        if (area is TinyWizard)
        {
            Close = true;
            EmitSignal(nameof(Proximity), Close);
        }
        
    }

    private void OutRange(object area)
    {
        if (area is TinyWizard)
        {
            Close = false;
            EmitSignal(nameof(Proximity), Close);
        }
    }

    [Signal]
    delegate void Interacted();

    [Signal]
    delegate void Proximity(Boolean prox);


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
