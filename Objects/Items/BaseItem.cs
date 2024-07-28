using Godot;
using System;

public abstract class BaseItem : Area2D 
{
	[Export] public string itemName;
	[Export] public string itemDescription;
	[Export] public ItemRarity itemRarity;
	[Export] public int dropWeight = 5;
	public int ItemCount { get => _itemCount; }
	protected int _itemCount = 1;
	
	public abstract void OnEquip(BaseEntity entity);
	public abstract void OnIncreaseCount(BaseEntity entity);
	public abstract void OnTick(BaseEntity entity);
	public abstract void OnUnequip(BaseEntity entity);
}
public enum ItemRarity{
	Normal,
	Rare,
	Epic,
	Cursed
}
