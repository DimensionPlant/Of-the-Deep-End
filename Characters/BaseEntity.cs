using Godot;
using System;

public abstract class BaseEntity : KinematicBody2D
{
	public EntityState State = EntityState.Deactivated; 
	public EntityStats Stats;
	
	//Base starting Stats for all entities. 
	[Export] public int Health = 100; //Base max health.  
	[Export] public int MoveSpeed = 100; //Move speed (100 = normal speed)
	[Export] public int AttackSpeed = 100; //Essentially, cooldown for attacks. Weapons for players. Normally does nothing for enemies except for ones with projectiles. 
	[Export] public int Strength = 100; //Base damage multiplication. Every point over 100 equals +1% damage. 
	[Export] public int Armor = 0; //Flat damage reduction. 5 armor and 10 incoming damage equals 5 damage taken. 
	[Export] public int Dodge = 0; //Chance of avoiding damage. Clamped to a maximum of 70%. 
	[Export] public int Regen = 0; //HP regen per 10 seconds. 
	
	protected Vector2 _velocity = new Vector2();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Stats = new EntityStats();
		Stats.Health = Health;
		Stats.MoveSpeed = MoveSpeed;
		Stats.AttackSpeed = AttackSpeed;
		Stats.Strength = Strength;
		Stats.Armor = Armor;
		Stats.Dodge = Dodge;
		Stats.Regen = Regen;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	public void MoveEntityVelocity(Vector2 moveDir){
		if (moveDir != Vector2.Zero) { _velocity = moveDir * (MoveSpeed * 2f); }
		else { if(_velocity.Length()>0) { _velocity -= _velocity/4; } }
		_velocity = MoveAndSlide(_velocity);
	}
}
public enum EntityState {
	Deactivated = 0,
	Activated = 1,
	Dead = 2
}
