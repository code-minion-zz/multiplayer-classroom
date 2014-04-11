using UnityEngine;
using System.Collections;

public class Item  
{
    public int itemID;
    public string itemName;
    public int itemCost;
    public int levelRequirement;
    public bool purchased;
    public bool unlocked;
    public string spriteName;

    public Item()
    {
    }

	public static Item GetItem(int itemID)
	{
		// Load items from file/s
		return null;
	}

    public Item(int itemID, string itemName, int itemCost, int levelRequirement, bool purchased, string spriteName)
    {
        this.itemID = itemID;
        this.itemName = itemName;
        this.itemCost = itemCost;
        this.levelRequirement = levelRequirement;
        this.purchased = purchased;
        this.spriteName = spriteName;

        unlocked = CharacterData.Level >= levelRequirement;
    }
}
