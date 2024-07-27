using Godot;
using System;

public abstract class BaseEntity : KinematicBody2D
{
	public EntityState State = EntityState.Deactivated; 
	public EntityStats Stats;

	//Base starting Stats for all entities. 
	public CharacterStat Health = new CharacterStat(); //Base max health.  
	public CharacterStat MoveSpeed = new CharacterStat(); //Move speed (100 = normal speed)
	public CharacterStat AttackSpeed = new CharacterStat(); //Essentially, cooldown for attacks. Weapons for players. Normally does nothing for enemies except for ones with projectiles. 
	public CharacterStat Strength = new CharacterStat(); //Base damage multiplication. Every point over 100 equals +1% damage. 
	public CharacterStat Armor = new CharacterStat(); //Flat damage reduction. 5 armor and 10 incoming damage equals 5 damage taken. 
	public CharacterStat Dodge = new CharacterStat(); //Chance of avoiding damage. Clamped to a maximum of 70%. 
	public CharacterStat Regen = new CharacterStat(); //HP regen per 10 seconds. 
	
	protected Vector2 _velocity = new Vector2();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        //Health.BaseValue = Stats.Health;
        //MoveSpeed.BaseValue = Stats.MoveSpeed;
        //AttackSpeed.BaseValue = Stats.AttackSpeed;
        //Strength.BaseValue = Stats.Strength;
        //Armor.BaseValue = Stats.Armor;
        //Dodge.BaseValue = Stats.Dodge;
        //Regen.BaseValue = Stats.Regen;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	public void MoveEntityVelocity(Vector2 moveDir){
		if (moveDir != Vector2.Zero) { _velocity = moveDir * (MoveSpeed.Value * 2f); }
		else { if(_velocity.Length()>0) { _velocity -= _velocity/4; } }
		_velocity = MoveAndSlide(_velocity);
	}
}
public enum EntityState {
	Deactivated = 0,
	Activated = 1,
	Dead = 2
}
