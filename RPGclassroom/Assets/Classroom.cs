using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Classroom : MonoBehaviour {
	List<Character> allPlayers;

	public Character[] GetCharacters()
	{
		return allPlayers.ToArray();
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

}
