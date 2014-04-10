using UnityEngine;
using System;
using System.Collections;

public class UserRetrieveData : MonoBehaviour 
{
    public delegate void RetrieveDataEvent();
    public event RetrieveDataEvent onDataRetrieved;

    private int _userID;
    private bool _characterRetrieved = false;
    private bool _attendanceRetrieved = false;

    public void RetrieveData(int userId)
    {
        // Reset everything and begin retrieving data.
        _userID = userId;
        _characterRetrieved = false;
        _attendanceRetrieved = false;
        StartCoroutine(RequestAttendance());
        StartCoroutine(RequestCharacter());
        StartCoroutine(WaitForAllRequests());
    }

    IEnumerator RequestAttendance()
    {
        var requestAttendance = new WWWForm();
        requestAttendance.AddField("user", _userID);

        Debug.Log("Fetching attendance");

        // Wait for the data return
        var fetch = new WWW(URLHelper.getAttendanceURL, requestAttendance);
        yield return fetch;
		
		Debug.Log("Attendance fetched");

        _attendanceRetrieved = true;
    }

    IEnumerator RequestCharacter()
    {
        var requestCharacter = new WWWForm();
        requestCharacter.AddField("user", _userID);
		
		Debug.Log("Fetching character");

        // Wait for the data return
        var fetch = new WWW(URLHelper.getCharacterURL, requestCharacter);
		yield return fetch;

		Debug.Log("Character fetched");

        int gold = 0;
        int head = 0;
        int face = 0;
        int torso = 0;
        int legs = 0;
        int shoes = 0;
        int background = 0;

        Int32.TryParse(fetch.responseHeaders["GOLD"], out gold);
        Int32.TryParse(fetch.responseHeaders["HEAD"], out head);
        Int32.TryParse(fetch.responseHeaders["FACE"], out face);
        Int32.TryParse(fetch.responseHeaders["TORSO"], out torso);
        Int32.TryParse(fetch.responseHeaders["LEGS"], out legs);
        Int32.TryParse(fetch.responseHeaders["SHOES"], out shoes);
        Int32.TryParse(fetch.responseHeaders["BACKGROUND"], out background);

        Debug.Log("Gold: " + gold);
        Debug.Log("Head: " + head);
        Debug.Log("Face: " + face);
        Debug.Log("Torso: " + torso);
        Debug.Log("Legs: " + legs);
        Debug.Log("Shoes: " + shoes);
        Debug.Log("Background: " + background);

        // Apply the loaded data to the character data.
        CharacterData.Gold = gold;
        CharacterData.Items[0] = head;
        CharacterData.Items[1] = face;
        CharacterData.Items[2] = torso;
        CharacterData.Items[3] = legs;
        CharacterData.Items[4] = shoes;
        CharacterData.Items[5] = background;

        _characterRetrieved = true;
    }

    IEnumerator WaitForAllRequests()
    {
		bool requests = false;

		while (!requests){
			requests = (_characterRetrieved && _attendanceRetrieved);
			Debug.Log("YIELD RETURN");
			yield return null;
		}
		
		if (onDataRetrieved != null)
		{
			onDataRetrieved();
		}
    }
}
