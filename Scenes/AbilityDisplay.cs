using Godot;
using System;

public partial class AbilityDisplay : Control
{

	private Timer _cooldown;
	public double CD {get => _cooldown.TimeLeft;}
	private RichTextLabel _display;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_display = GetNode("Container").GetNode<RichTextLabel>("TimeDisplay");
		_cooldown = GetNode<Timer>("Brightness");
		_cooldown.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	}
}
