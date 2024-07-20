using Godot;
using System;

public class HealthComponent : Node
{
	public int Health { get => (int)Math.Floor(_health); }
	private float _health = 0; 
	public int BaseStartingHealth = 100;

	public override void _EnterTree(){
		_health = BaseStartingHealth;
	}
	
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
	
	public DamageReport TakeDamage(DamageInfo damageInfo)
	{
		DamageReport report = new DamageReport();
		
		float subTotalDamage = damageInfo.atk * damageInfo.atkMult;
		
		_health -= subTotalDamage;
		if(_health <= 0f){ report.kill = true; }
		
		GD.Print(_health);
		report.damage = subTotalDamage;
		return new DamageReport();
	}
}


