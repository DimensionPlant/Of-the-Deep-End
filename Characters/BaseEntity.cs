using Godot;
using System;

public abstract class BaseEntity : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
public enum EntityStates{
	Deactivated = 0,
	Activated = 1,
	Dead = 2
}
