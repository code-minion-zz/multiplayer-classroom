using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopMain : MonoBehaviour 
{
	/// <summary>
	/// Keep this enum alphabetically ordered. Update the lists in the inspector if anything new is introduced.
	/// ItemSlots on the Avatar object need updating and,
	/// ShopCategories in the ShopMain object need updating
	/// </summary>
    public enum EShopCategories
    {
        Eye,
        Feet,
        Hair,
        Head,
        Legs,
        Mouth,
		Skin,
		Torso,

        MAX,
    }

	public UILabel studentName;
	public UILabel studentLevel;
	public UILabel studentGold;

	public CharacterAvatar avatar;

    public UIToggle firstToggle;

    public ShopCategoryList[] shopCategoryLists = new ShopCategoryList[(int)EShopCategories.MAX];

    bool initialised;

	public static UIToggle currentToggle;
	public static int currentCategory;

    public void Start()
    {
		CharacterData.InitialiseTestData();

		studentName.text = CharacterData.Name;
		studentLevel.text = "Level " + CharacterData.Level.ToString();
		studentGold.text = CharacterData.Gold.ToString();

        // Test Items (This is our database for now.
        shopCategoryLists[(int)EShopCategories.Hair].items.Add(Item.GetItem(0));
		shopCategoryLists[(int)EShopCategories.Hair].items.Add(Item.GetItem(1));
		shopCategoryLists[(int)EShopCategories.Hair].items.Add(Item.GetItem(2));
		shopCategoryLists[(int)EShopCategories.Hair].items.Add(Item.GetItem(3));
		shopCategoryLists[(int)EShopCategories.Hair].items.Add(Item.GetItem(4));
		shopCategoryLists[(int)EShopCategories.Hair].items.Add(Item.GetItem(5));

		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(50));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(51));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(52));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(53));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(54));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(55));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(56));
		shopCategoryLists[(int)EShopCategories.Head].items.Add(Item.GetItem(57));

		shopCategoryLists[(int)EShopCategories.Torso].items.Add(Item.GetItem(100));
		shopCategoryLists[(int)EShopCategories.Torso].items.Add(Item.GetItem(101));
		shopCategoryLists[(int)EShopCategories.Torso].items.Add(Item.GetItem(102));
		shopCategoryLists[(int)EShopCategories.Torso].items.Add(Item.GetItem(103));
		shopCategoryLists[(int)EShopCategories.Torso].items.Add(Item.GetItem(104));

		shopCategoryLists[(int)EShopCategories.Skin].items.Add(Item.GetItem(150));
		shopCategoryLists[(int)EShopCategories.Skin].items.Add(Item.GetItem(151));
		shopCategoryLists[(int)EShopCategories.Skin].items.Add(Item.GetItem(152));

        shopCategoryLists[(int)EShopCategories.Legs].items.Add(Item.GetItem(200));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(Item.GetItem(201));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(Item.GetItem(202));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(Item.GetItem(203));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(Item.GetItem(204));
															  
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(Item.GetItem(250));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(Item.GetItem(251));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(Item.GetItem(252));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(Item.GetItem(253));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(Item.GetItem(254));

		shopCategoryLists[(int)EShopCategories.Eye].items.Add(Item.GetItem(300));

		shopCategoryLists[(int)EShopCategories.Mouth].items.Add(Item.GetItem(350));

        // Put items into categories and sort them out.
        for (int i = 0; i < shopCategoryLists.Length; ++i)
        {
            shopCategoryLists[i].gameObject.SetActive(true);

            foreach (Item item in shopCategoryLists[i].items)
            {
				shopCategoryLists[i].shopCategory = i;

                GameObject shopItemObject = GameObject.Instantiate(Resources.Load("Prefabs/ShopItem")) as GameObject;
                ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();		

                shopItem.transform.parent = shopCategoryLists[i].grid.transform;
                shopItem.transform.localScale = Vector3.one;

                shopItem.Initialise(item);

				shopCategoryLists[i].shopItems.Add(shopItem);
            }

			// Resort the list
            shopCategoryLists[i].grid.Reposition();

            shopCategoryLists[i].gameObject.SetActive(false);
        }  
    }

    public void Update()
    {
        // This will ensure that only one list is toggled on and displayed.
        if (!initialised)
        {
			firstToggle.value = true;
			currentToggle = firstToggle;
			UIToggle.current = currentToggle;

			initialised = true;

			ItemSlot newSlot = currentToggle.GetComponent<ItemSlot>();
			int newSlotID = avatar.GetItemSlotID(newSlot);
			shopCategoryLists[newSlotID].Toggle();
        }

		studentGold.text = CharacterData.Gold.ToString();
    }

	public void ShopCategoryToggle()
	{
		if (!initialised)
		    return;

		if (currentToggle != UIToggle.current)
		{
			// Disable current shop categories
			ItemSlot currentSlot = currentToggle.GetComponent<ItemSlot>();
			int currentSlotID = avatar.GetItemSlotID(currentSlot);
			shopCategoryLists[currentSlotID].Toggle();

			// Enable new shop categories
			ItemSlot newSlot = UIToggle.current.GetComponent<ItemSlot>();
			int newSlotID = avatar.GetItemSlotID(newSlot);
			shopCategoryLists[newSlotID].Toggle();

			// Set new toggled
			currentToggle = UIToggle.current;
		}
	}
}
