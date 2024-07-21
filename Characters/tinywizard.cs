using Godot;
using System;
using System.Security.Authentication;

public partial class TinyWizard : BaseEntity
{
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	//public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	Vector2 mouserelpos;

	public override void _Process(float delta)
	{
		mouserelpos = GetGlobalMousePosition()-Position;
		Sprite Hat = GetNode<Sprite>("Hat");
		Sprite Staff = GetNode<Sprite>("Staff");
		int sprite_id = (int) Math.Round(4*((AngleViaX(mouserelpos))/Math.PI+1));
		if(sprite_id<8)
		{
			Hat.Frame = sprite_id;
			Staff.Frame = sprite_id;

		}
		else
		{
			Hat.Frame = 0;
			Staff.Frame = 0;
		}
		
	}
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
		//Hud();
	}

	/**private void Hud()
	{
		//get relative vector to produce the angle and offset for flathud
		float angle = AngleViaX(mouserelpos);

		GetNode<Sprite>("Flat Hud").Rotation = (float) (angle+(Math.PI/2));
		//GD.Print(angle, GetNode<Sprite2D>("Flat Hud").Rotation);
		GetNode<Sprite>("Flat Hud").Position = mouserelpos/mouserelpos.Length()*100;
	}*/

	private float AngleViaX(Vector2 mouserelpos)
	{
		float angle;
		if(mouserelpos.y>0)
		{
			angle = (float) Math.Acos(mouserelpos.x/mouserelpos.Length());
		}
		else
		{
			angle = (float) -Math.Acos(mouserelpos.x/mouserelpos.Length());
		}
		
		return angle;
	}

	private double AngleViaY(Vector2 mouserelpos)
	{
		float angle;
		if(mouserelpos.x>0)
		{
			angle = (float) Math.Asin(mouserelpos.y/mouserelpos.Length());
		}
		else
		{
			angle = (float) -Math.Asin(mouserelpos.y/mouserelpos.Length());
		}
		
		return angle;
	}
}
