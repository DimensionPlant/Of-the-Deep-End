using Godot;
using System;

public abstract class BaseEntity : KinematicBody2D
{
	public EntityState EntityState = EntityState.Deactivated; 
	
	[Export] public float Speed = 300.0f;
	[Export] public float JumpVelocity = -400.0f;
	protected Vector2 _velocity = new Vector2();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	public void MoveEntityVelocity(Vector2 moveDir){
		if (moveDir != Vector2.Zero) { _velocity = moveDir * Speed; }
		else { if(_velocity.Length()>0) { _velocity -= _velocity/4; }
		}
		_velocity = MoveAndSlide(_velocity);
	}
}
public enum EntityState {
	Deactivated = 0,
	Activated = 1,
	Dead = 2
}
