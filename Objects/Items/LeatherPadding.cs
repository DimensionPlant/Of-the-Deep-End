using Godot;
using System;

public class LeatherPadding : BaseItem
{
	
	public override void OnEquip(BaseEntity entity)
	{
		_itemCount = 1;
		entity.Stats.Health.AddModifier(new StatModifier(50, StatModType.Flat, this));
	}
	public override void OnIncreaseCount(BaseEntity entity)
	{
		_itemCount++;
		entity.Stats.Health.AddModifier(new StatModifier(50 * _itemCount, StatModType.Flat, this));
	}
	public override void OnUnequip(BaseEntity entity)
	{
		entity.Stats.Health.RemoveAllModifiersFromSource(this);
	}
	public override void OnTick(BaseEntity entity)
	{
		return;
	}
}
