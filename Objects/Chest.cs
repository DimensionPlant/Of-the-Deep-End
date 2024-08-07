using Godot;
using System;

public partial class Chest : Node2D
{
	//maybe rename it to activateable item
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Sprite _skin;
	private int _orientation;
	
	[Export]
	Color Activated = new Color("5a5a5a");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_skin = GetNode<Sprite>("Sprite");
		var rand = new Random();
		_orientation = rand.Next(8);
		_skin.Frame = _orientation;
	}

	private void _Activate()
	{
		//check if enough time left to open it
		_skin.Frame = _orientation+8;
		_skin.Modulate = Activated;
		//spawn item
		//figure out id then add script to item object
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
