using Godot;
using System;
using System.Collections.Generic;

//Only in charge of abstraction and handling items. Not in charge of their logic / effects. 
public class Inventory : Area2D
{
	public BaseEntity inventoryEntity = null;
	public List<BaseItem> items = new List<BaseItem>();

	public override void _EnterTree()
	{
		inventoryEntity = GetParent<BaseEntity>();
		if (inventoryEntity != null) { inventoryEntity.inventory = this; }
	}
	//Triggers when item is first added, usually for like one-off effects. 
	public bool AddItem(BaseItem item){
		if(inventoryEntity == null) { item.QueueFree(); return false; } //Makes sure entity with an inventory is not null

		if(item != null){ //Check if item is null. 
			foreach(BaseItem _item in items){ //Go through every item in the inventory
				if(_item.itemName == item.itemName){ //Check if the item is already in the inventory. 
					_item.OnIncreaseCount(inventoryEntity);
					item.QueueFree();
				}
				else {
					item.OnEquip(inventoryEntity);
					item.Hide();
				}
			}
			return true;
		}
		return false;
	}
	
	//Triggers when item is deleted / removed
	public bool RemoveItem(BaseItem item){
		return false;
	}
	
	//Ticks once every Physics frame
	public void TickItems(){
		foreach(BaseItem item in items){
			item.OnTick(inventoryEntity);
		}
	}
	
	private void _on_Inventory_body_entered(object body)
	{	
		GD.Print("Testing");
		//The check below returns the kinematicbody2d, which is the main body of the wizard
		GD.Print(body.ToString());
		if(body is BaseItem item){ AddItem(item); GD.Print("Successful!"); }
	}
}
