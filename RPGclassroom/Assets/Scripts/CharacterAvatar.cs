using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAvatar : MonoBehaviour 
{
	public ItemSlot[] itemSlots = new ItemSlot[(int)ShopMain.EShopCategories.MAX];

	public void Start()
	{
		// Equip items based on records.
		for (int i = 0; i < (int)ShopMain.EShopCategories.MAX; ++i)
		{
			Item loadedItem = Item.GetItem(CharacterData.Items[i]);
			itemSlots[i].Initialise(loadedItem, i);
		}
	}

	public int GetItemSlotID(ItemSlot item)
	{
		for (int i = 0; i < itemSlots.Length; ++i)
		{
			if (item == itemSlots[i])
			{
				return i;
			}
		}

		Debug.Log("Given ItemSlot could not be found in CharacterAvatar");

		return -1;
	}
}
