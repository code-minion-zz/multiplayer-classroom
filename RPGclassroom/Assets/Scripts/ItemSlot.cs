using UnityEngine;
using System.Collections;

public class ItemSlot : MonoBehaviour 
{
    public UISprite sprite;

    private Item item;

	public void Initialise(Item item)
	{
		EquipItem(item);
	}

    public void EquipItem(Item newItem)
    {
        if (item == newItem) return;

        // Set item and update the sprite image
        item = newItem;
        sprite.spriteName = item.spriteName;
    }
}
