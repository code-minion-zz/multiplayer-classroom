using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopMain : MonoBehaviour 
{
    public enum EShopCategories
    {
        Hair,
        Head,
        Face,
        Torso,
        Legs,
        Feet,

        MAX,
    }

    public GameObject[] ItemList;
    public UIToggle firstToggle;

    public ShopCategoryList[] shopCategoryLists = new ShopCategoryList[(int)EShopCategories.MAX];

    bool initialised;

    public void Start()
    {
        // Test Items (This is our database for now.
        shopCategoryLists[(int)EShopCategories.Hair].items.Add(new Item(0, "Bald", 0, 1, true, "Bald"));
        shopCategoryLists[(int)EShopCategories.Hair].items.Add(new Item(0, "Long Hair", 1, 1, true, "LongHair1"));
        shopCategoryLists[(int)EShopCategories.Hair].items.Add(new Item(0, "Long Hair", 2, 2, true, "LongHair2"));
        shopCategoryLists[(int)EShopCategories.Hair].items.Add(new Item(0, "Short Hair", 1, 1, true, "ShortHair1"));
        shopCategoryLists[(int)EShopCategories.Hair].items.Add(new Item(0, "Short Hair", 2, 2, true, "ShortHair2"));

        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Beanie", 0, 1, true, "Beanie"));
        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Hat", 0, 2, true, "Beanie"));
        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Beanie", 1, 2, true, "Beanie"));
        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Cap", 1, 2, true, "Beanie"));
        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Cowboy Hat", 3, 3, true, "Beanie"));
        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Police Hat", 3, 3, true, "Beanie"));
        shopCategoryLists[(int)EShopCategories.Head].items.Add(new Item(0, "Fireman Helmet", 3, 3, true, "Beanie"));

        shopCategoryLists[(int)EShopCategories.Torso].items.Add(new Item(0, "TShirt", 0, 1, true, "TShirt1"));
        shopCategoryLists[(int)EShopCategories.Torso].items.Add(new Item(0, "TShirt", 0, 1, true, "TShirt2"));
        shopCategoryLists[(int)EShopCategories.Torso].items.Add(new Item(0, "Hoodie", 0, 1, true, "Hoodie"));
        shopCategoryLists[(int)EShopCategories.Torso].items.Add(new Item(0, "Police Shirt", 0, 1, true, "PoliceShirt"));
        shopCategoryLists[(int)EShopCategories.Torso].items.Add(new Item(0, "Blazer", 0, 1, true, "ShirtBlazer"));

        shopCategoryLists[(int)EShopCategories.Face].items.Add(new Item(0, "White", 0, 1, true, "White"));
        shopCategoryLists[(int)EShopCategories.Face].items.Add(new Item(0, "Brown", 0, 1, true, "Brown"));
        shopCategoryLists[(int)EShopCategories.Face].items.Add(new Item(0, "Black", 0, 1, true, "Black"));

        shopCategoryLists[(int)EShopCategories.Legs].items.Add(new Item(0, "Shorts", 0, 1, true, "Shorts"));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(new Item(0, "Skirt", 0, 1, true, "Skirt"));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(new Item(0, "Blue Jeans", 0, 1, true, "BlueJeans"));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(new Item(0, "Track Pants", 0, 1, true, "TrackPants"));
        shopCategoryLists[(int)EShopCategories.Legs].items.Add(new Item(0, "Cargo Pants", 0, 1, true, "CargoPants"));

        shopCategoryLists[(int)EShopCategories.Feet].items.Add(new Item(0, "Jandals", 0, 1, true, "Jandals"));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(new Item(0, "Black Boots", 0, 1, true, "BlackWorkBoots"));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(new Item(0, "Brown Boots", 0, 1, true, "BrownBoots"));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(new Item(0, "Sneakers", 0, 1, true, "Sneakers"));
        shopCategoryLists[(int)EShopCategories.Feet].items.Add(new Item(0, "Shoes", 0, 1, true, "GirlShoes"));

        // Put items into categories and sort them out.
        for (int i = 0; i < shopCategoryLists.Length; ++i)
        {
            shopCategoryLists[i].gameObject.SetActive(true);

            foreach (Item item in shopCategoryLists[i].items)
            {
                GameObject shopItemObject = GameObject.Instantiate(Resources.Load("Prefabs/ShopItem")) as GameObject;
                ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();

                shopItem.transform.parent = shopCategoryLists[i].grid.transform;
                shopItem.transform.localScale = Vector3.one;

                shopItem.Initialise(item);
            }

            shopCategoryLists[i].grid.Reposition();
            shopCategoryLists[i].gameObject.SetActive(false);
        }  
    }

    public void Update()
    {
        // This will ensure that only one list is toggled on and displayed.
        if (!initialised)
        {
            foreach (GameObject g in ItemList)
            {
                g.SetActive(false);
            }

            firstToggle.value = true;

            initialised = true;
        }
    }
}
