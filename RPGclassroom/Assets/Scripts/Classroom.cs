using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class Classroom : MonoBehaviour {

	static Classroom singleton;

	public static Classroom Singleton
	{
		get 
		{
			return singleton;
		}
		private set
		{		
			singleton = value;
		}
	}

	List<Character> allPlayers;

	public GameObject expPrefab;

	public Character[] GetCharacters()
	{
		return allPlayers.ToArray();
	}

	void Awake()
	{

	}

	void OnEnable()
	{
		if (Singleton == null)
		{
			Singleton = this;
		}
	}

	public Character GetCharacterFromID(int id)
	{
		Character[] chars = allPlayers.Where(character => character.uid == id).ToArray();
		if (chars.Count() <= 0) 
		{
			Debug.Log("Character with this ID Not Found");
			return null;
		}
		return chars[0];
	}

	public int GetCharacterIndex(Character character)
	{
		return allPlayers.IndexOf(character);
	}

	public void DisplayReward(int amount, GameObject character)
	{
        // Create an exp label, set the text of it to the star amount.
		GameObject exp = NGUITools.AddChild(character, expPrefab);
		exp.GetComponent<UILabel>().text = amount.ToString();

        // Destory it after 1 second.
        GameObject.Destroy(exp, 1.0f);
	}
}
