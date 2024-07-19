using Godot;
using System;
using System.Runtime.ExceptionServices;

public partial class tinywizard : KinematicBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	private Vector2 _velocity = new Vector2();

	//stats
	//Hitpoints
	private double _hp;
	//attack
	private double _atk;
	//attack speed
	private double _atkspd;
	//health regeneration
	private double _regen;
	//Crit rate
	private double _cr;


	public override void _PhysicsProcess(float delta)
	{

		/** Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;
		*/
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			_velocity = direction * Speed;
		}
		else
		{
			if(_velocity.Length()>0)
			{
				_velocity -= _velocity/4;
			}
			
		}

		_velocity = MoveAndSlide(_velocity);
		
		Hud();
	}

	private void Hud()
	{
		//get relative vector to produce the angle and offset for flathud
		float angle;
		Godot.Vector2 mouserelpos = GetGlobalMousePosition()-Position;
		if(mouserelpos.y>0)
		{
			angle = (float) Math.Acos(mouserelpos.x/mouserelpos.Length());
		}
		else
		{
			angle = (float) -Math.Acos(mouserelpos.x/mouserelpos.Length());
		}
		
		GetNode<Sprite>("Flat Hud").Rotation = (float) (angle+(Math.PI/2));
		//GD.Print(angle, GetNode<Sprite2D>("Flat Hud").Rotation);
		GetNode<Sprite>("Flat Hud").Position = mouserelpos/mouserelpos.Length()*100;
		
	}

}
