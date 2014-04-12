using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class URLHelper
{
    public const string authenticateURL = "http://54.200.154.175/authenticate.php?";
    public const string setAttendanceURL = "http://54.200.154.175/setattendance.php?";
    public const string getAttendanceURL = "http://54.200.154.175/getattendance.php?";
    public const string setCharacterURL = "http://54.200.154.175/setcharacter.php?";
    public const string getCharacterURL = "http://54.200.154.175/getcharacter.php?";
    public const string setGoldURL = "http://54.200.154.175/setgold.php?";
}

public static class CharacterData
{
    public static int UserID;
    public static string Name;
    public static int Gold;
    public static int[] Items;
    public static DateTime[] Attendance;
    public static int Level;

    static CharacterData()
    {
        UserID = -1;
        Name = "";
        Gold = 0;
        Items = new int[(int)ShopMain.EShopCategories.MAX];
        Attendance = new DateTime[80];
    }

	public static bool initialised = false;
	public static void InitialiseTestData()
	{
		if (!initialised)
		{
			UserID = 0;
			Name = "Mac";
			Gold = 5;
			Level = 1;

			Items[(int)ShopMain.EShopCategories.Eye] = 300;
			Items[(int)ShopMain.EShopCategories.Feet] = 251;
			Items[(int)ShopMain.EShopCategories.Hair] = 3;
			Items[(int)ShopMain.EShopCategories.Head] = 51;
			Items[(int)ShopMain.EShopCategories.Legs] = 200;
			Items[(int)ShopMain.EShopCategories.Mouth] = 350;
			Items[(int)ShopMain.EShopCategories.Skin] = 150;
			Items[(int)ShopMain.EShopCategories.Torso] = 100;

			initialised = true;
		}
	}

    public static void SetEquipment(int slot, int item)
    {
        Items[slot] = item;

        // Query the database.
    }

    public static void SetGold(int gold)
    {
        Gold = gold;

        if (UserID != -1)
        {
            // Query the database.
            //var setGold = new WWWForm();
            //setGold.AddField("user", UserID);
            //setGold.AddField("gold", Gold);

            //// Wait for the data return
            //var fetch = new WWW(URLHelper.getCharacterURL, setGold);
        }
    }

    public static void SetAttendance(int day, DateTime date)
    {

    }
}
