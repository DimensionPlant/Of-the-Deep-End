using Godot;
using System;
using System.Collections.Generic;

//Only in charge of abstraction and handling items. Not in charge of their logic / effects. 
public class Inventory : Node
{
	public List<BaseItem> items = new List<BaseItem>();
	
	//Triggers when item is first added, usually for like one-off effects. 
	public bool AddItem(BaseItem item){
		if(item != null){ //Check if item is null. 
			foreach(BaseItem _item in items){ //Go through every item in the inventory
				if(_item.itemName == item.itemName){ //Check if the item is already in the inventory. 
					_item.OnIncreaseCount();
					item.QueueFree();
				}
				else {
					item.OnEquip();
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
			item.OnTick();
		}
	}
}
