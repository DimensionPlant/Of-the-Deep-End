using Godot;
using System;

public partial class tinywizard : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

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
			velocity = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		Hud();
	}

	private void Hud()
	{
		//get relative vector to produce the angle and offset for flathud
		float angle;
		Godot.Vector2 mouserelpos = GetGlobalMousePosition()-Position;
		if(mouserelpos.Y>0)
		{
			angle = (float) Math.Acos(mouserelpos.X/mouserelpos.Length());
		}
		else
		{
			angle = (float) -Math.Acos(mouserelpos.X/mouserelpos.Length());
		}
		
		GetNode<Sprite2D>("Flat Hud").Rotation = (float) (angle+(Math.PI/2));
		//GD.Print(angle, GetNode<Sprite2D>("Flat Hud").Rotation);
		GetNode<Sprite2D>("Flat Hud").Position = mouserelpos/mouserelpos.Length()*200;
	}

}
