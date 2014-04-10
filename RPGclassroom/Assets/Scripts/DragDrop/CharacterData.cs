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

    static CharacterData()
    {
        UserID = -1;
        Name = "";
        Gold = 0;
        Items = new int[6];
        Attendance = new DateTime[80];
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
