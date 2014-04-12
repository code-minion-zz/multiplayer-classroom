using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item  
{
    public int itemID;
    public string itemName;
    public int itemCost;
    public int levelRequirement;
    public bool purchased;
    public bool unlocked;
    public string spriteName;

	public static Item GetItem(int itemID)
	{
		// TODO: make this load from file

		switch(itemID)
		{
			case 0: return new Item(0, "Bald", 1, 1, false, "Bald");
			case 1: return new Item(1, "Long Hair", 1, 1, true, "GLH_1");
			case 2: return new Item(2, "Long Hair", 2, 2, false, "GLH_2");
			case 3: return new Item(3, "Short Hair", 1, 1, true, "Comb_Over");
			case 4: return new Item(4, "Short Hair", 2, 2, false, "BSH_1");
			case 5: return new Item(5, "Short Hair", 2, 2, false, "BHS_2");

			case 50: return new Item(50, "Beanie", 1, 1, true, "None");
			case 51: return new Item(51, "Beanie", 1, 1, true, "Beanie");
			case 52: return new Item(52, "Hat", 1, 1, false, "Cap");
			case 53: return new Item(53, "Beanie", 1, 2, false, "Cowboy Hat");
			case 54: return new Item(54, "Cap", 1, 2, false, "Cap");
			case 55: return new Item(55, "Cowboy Hat", 3, 3, false, "Cap");
			case 56: return new Item(56, "Police Hat", 3, 3, false, "Police Hat");
			case 57: return new Item(57, "Fireman Helmet", 3, 3, false, "Police Hat");

			case 100: return new Item(100, "TShirt", 1, 1, true, "TShirt1");
			case 101: return new Item(101, "TShirt", 1, 1, true, "Tshirt2");
			case 102: return new Item(102, "Hoodie", 1, 2, false, "Hoodie");
			case 103: return new Item(103, "Police Shirt", 1, 5, false, "Police_top");
			case 104: return new Item(104, "Blazer", 1, 3, false, "ShirtBlazer");

			case 150: return new Item(150, "White", 0, 1, true, "White");
			case 151: return new Item(151, "Brown", 0, 1, true, "Brown");
			case 152: return new Item(152, "Black", 0, 1, true, "Black");

			case 200: return new Item(200, "Shorts", 1, 1, true, "Shorts");
			case 201: return new Item(201, "Skirt", 1, 1, false, "Skirt");
			case 202: return new Item(202, "Blue Jeans", 1, 1, false, "Jeans");
			case 203: return new Item(203, "Track Pants", 1, 1, false, "Track_Pants");
			case 204: return new Item(204, "Cargo Pants", 1, 1, false, "Cargo_Pants");

			case 250: return new Item(250, "Jandals", 1, 1, false, "Shoes");
			case 251: return new Item(251, "Black Boots", 1, 1, true, "WorkBoots");
			case 252: return new Item(252, "Brown Boots", 1, 1, true, "WorkBoots");
			case 253: return new Item(253, "Sneakers", 1, 1, false, "Shoes");
			case 254: return new Item(254, "Shoes", 1, 1, false, "Girl_Shoes");

			case 300: return new Item(300, "Eyes", 1, 1, true, "Eyes");

			case 350: return new Item(350, "Mouth", 1, 1, true, "Mouth");

			default: Debug.Log("No Item for this ID."); break;
		}

		return null;
	}

	public Item()
	{
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
