using Godot;
using System;
using System.Collections.Generic;

//Only in charge of abstraction and handling items. Not in charge of their logic / effects. 
public class Inventory : Node
{
	public List<BaseItem> items = new List<BaseItem>();
	
	public bool AddItem(){
		return false;
	}
	public bool RemoveItem(){
		return false;
	}
	public void TickItems(){
		//Go through all items that have a ticking effect and call the corresponding function. 
	}
}
