using Godot;
using System;

public abstract class BaseItem : Sprite
{
	[Export] public string itemName;
	[Export] public string itemDescription;
	[Export] public ItemRarity itemRarity;
	[Export] public int dropWeight = 5;
	
	public abstract void OnEquip();
	public abstract void OnTick();
	public abstract void OnUnequip();
}
public enum ItemRarity{
	Normal,
	Rare,
	Epic,
	Cursed
}
