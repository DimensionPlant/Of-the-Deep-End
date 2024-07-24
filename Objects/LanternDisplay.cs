using Godot;
using System;

public partial class LanternDisplay : TextureRect
{

	private Timer _bright;
	public double Bright {get => _bright.TimeLeft;}
	private RichTextLabel _display;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_display = GetNode("Container").GetNode<RichTextLabel>("TimeDisplay");
		_bright = GetNode<Timer>("Brightness");
		_bright.Start();
	}

	public void addFuel(double fuel)
	{
		double reserves = _bright.TimeLeft;
		_bright.Stop();
		_bright.WaitTime = (float) (reserves+fuel);
		_bright.Start();		
	}

	public void removeFuel(double fuel)
	{
		double reserves = _bright.TimeLeft;
		_bright.Stop();
		_bright.WaitTime = (float) (reserves-fuel);
		_bright.Start();		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		_display.Text = Math.Round(_bright.TimeLeft).ToString();
		if(_bright.TimeLeft<10)
		{
			addFuel(10);
		}
	}
}
