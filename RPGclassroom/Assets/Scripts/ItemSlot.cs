using UnityEngine;
using System.Collections;

public class ItemSlot : MonoBehaviour 
{
    public UISprite sprite;
	public int shopCategory;

    private Item item;

	public void Initialise(Item item, int shopCategory)
	{
		this.shopCategory = shopCategory;
		EquipItem(item);
	}

    public void EquipItem(Item newItem)
    {
        if (item == newItem) return;

        // Set item and update the sprite image
        item = newItem;
		sprite.spriteName = item.spriteName;

		CharacterData.Items[shopCategory] = item.itemID;
    }
}
