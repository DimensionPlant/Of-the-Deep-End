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
		_display = GetNode("Center").GetNode<RichTextLabel>("Display");
		_cooldown = GetNode<Timer>("Cooldown");
		_cooldown.Start();
	}

	public void addTime(double fuel)
	{
		_cooldown.Stop();
		double reserves = _cooldown.TimeLeft;
		_cooldown.WaitTime = (float) (reserves+fuel);
		_cooldown.Start();		
	}

	public void removeTime(double fuel)
	{
		_cooldown.Stop();
		double reserves = _cooldown.TimeLeft;
		_cooldown.WaitTime = (float) (reserves-fuel);
		_cooldown.Start();		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		_display.Text = Math.Round(_cooldown.TimeLeft).ToString();
		if(_cooldown.TimeLeft<10)
		{
			addTime(10);
		}
	}
}
