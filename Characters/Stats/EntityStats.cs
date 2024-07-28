using Godot;
using System;

public class EntityStats
{
	[Export] public CharacterStat Health = new CharacterStat();
	[Export] public CharacterStat MoveSpeed = new CharacterStat();
	[Export] public CharacterStat AttackSpeed = new CharacterStat();
	[Export] public CharacterStat Strength = new CharacterStat();
	[Export] public CharacterStat Armor = new CharacterStat();
	[Export] public CharacterStat Dodge = new CharacterStat();
	[Export] public CharacterStat Regen = new CharacterStat();
}
