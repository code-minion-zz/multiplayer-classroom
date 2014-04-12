using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopCategoryList : MonoBehaviour 
{
	public int shopCategory = -1;
    public UIGrid grid;
    public List<Item> items = new List<Item>();
	public List<ShopItem> shopItems = new List<ShopItem>();

	private bool firstToggle = true;

	public void Toggle()
	{
		gameObject.SetActive(!gameObject.activeInHierarchy);

		if (firstToggle)
		{
			Item currentItem = Item.GetItem(CharacterData.Items[shopCategory]);
			ShopItem centerItem = null;

			foreach (ShopItem item in shopItems)
			{
				if (currentItem.itemID == item.item.itemID)
				{
					centerItem = item;
				}
			}

			if (centerItem != null)
			{
				centerItem.GetComponent<UICenterOnClick>().OnClick();
			}

			firstToggle = false;
			return;
		}

	}

}
