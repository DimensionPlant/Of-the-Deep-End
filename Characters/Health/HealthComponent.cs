using Godot;
using System;

public class HealthComponent : Node
{
	// Public field to obtain current health.
	public int Health { get => (int)Math.Floor(_health); }
	public int MaxHealth { set => _maxHealth += value; }
	private float _health = 0; 
	private float _maxHealth = 100;
	private bool _initialized = false;
	[Export] public int BaseStartingHealth = 100;

	public override void _Ready(){
		if(!_initialized) _health = BaseStartingHealth;
	}
	public void InitializeHealthComponent(int maxHealth){
		_maxHealth = maxHealth;
		_health = maxHealth;
		_initialized = true;
	}
	
	//
	//For debug purposes, delete if needed! 
	//
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey){
			if(eventKey.Pressed){
				if (eventKey.Scancode == (int)KeyList.Space)
					GD.Print(_health);
			}
		}
		else if(@event is InputEventMouseButton eventMouse){
				if(eventMouse.Pressed){
					if(eventMouse.ButtonIndex == (int)ButtonList.Right){ TakeDamage(new DamageInfo(){atk = -10}); }
					else if(eventMouse.ButtonIndex == (int)ButtonList.Left){ TakeDamage(new DamageInfo(){atk = 10}); }
			}
		}
	}
	
	// The central core of this component, use this method to make this character take damage. 
	public DamageReport TakeDamage(DamageInfo damageInfo)
	{
		DamageReport report = new DamageReport(); //Create a new report that stores data about the characters involved + damage. 
		
		float subTotalDamage = damageInfo.atk * damageInfo.atkMult; // Calculate total damage. 
		
		_health -= subTotalDamage; // Apply the damage to health. 
		if(_health <= 0f){ report.kill = true; } // Record whether or not this damage kills this character. 
		
		GD.Print(_health);
		report.damage = subTotalDamage;
		return report;
	}
	public void Heal(int healAmount){
		_health += healAmount;
		if(_health > _maxHealth){ _health = _maxHealth; }
	}
}


