using Godot;
using System;
using System.Numerics;

public partial class AbilityDisplay : Control
{

	private Timer _cooldown;
	public double CD {get => _cooldown.TimeLeft;}
	private RichTextLabel _display;

	private ColorRect _bar;

	private float _total;

	//[ExportGroup("Colours")]
	[Export]
	Color Counting = new Color("5a5a5a");
	//Color dark = new Color(0.35f,0.35f,0.35f);
	[Export]
	Color Idle = new Color("ffffff");

	//[ExportGroup("Textures")]
	[Export]
	private Texture Icon;

	[Export]
	private Texture Alt;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_display = GetNode("Center").GetNode<RichTextLabel>("Display");
		_bar = GetNode<ColorRect>("Bar");
		_cooldown = GetNode<Timer>("Cooldown");
		GetNode<TextureRect>("Icon").Texture = Icon;
		GetNode<TextureRect>("Icon").Modulate = Idle;
		//_StartTime(5, true);
	}

	private void _StartTime(float total, Boolean withTimer)
	{
		//_display.Visible = withTimer;
		_total = total;
		_cooldown.WaitTime = total;
		_bar.Visible = withTimer;
		_cooldown.Start();
		GetNode<TextureRect>("Icon").Modulate = Counting;

	}

	public void AddTime(double fuel)
	{
		_cooldown.Stop();
		double reserves = _cooldown.TimeLeft;
		_cooldown.WaitTime = (float) (reserves+fuel);
		_cooldown.Start();		
	}

	public void RemoveTime(double fuel)
	{
		_cooldown.Stop();
		double reserves = _cooldown.TimeLeft;
		_cooldown.WaitTime = (float) (reserves-fuel);
		_cooldown.Start();		
	}

	private void _Elapsed()
	{
		//_display.Visible = false;
		_bar.Visible = false;
		GetNode<TextureRect>("Icon").Modulate = Idle;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		//nooooooo my bbcode doesn't work!!!!!
		_display.BbcodeText = "[b] [center] [color=black] [font_size=32] "+Math.Round(_cooldown.TimeLeft).ToString()+" [/font_size] [/color] [/center] [/b]";
		_bar.RectPosition = new Godot.Vector2(0,(float)(120*_cooldown.TimeLeft/_total));
		//_bar.MarginTop = (float)Math.Round((120*_cooldown.TimeLeft/_total));

	}
}
