using Godot;
using System;

[Serializable]
public class EntityStats : Resource
{
	[Export] public int Health = 100;
	[Export] public int MoveSpeed = 100;
	[Export] public int AttackSpeed = 100;
	[Export] public int Strength = 100;
	[Export] public int Armor = 0;
	[Export] public int Dodge = 0;
	[Export] public int Regen = 0;
}
