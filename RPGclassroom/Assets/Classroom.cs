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

	List<GameObject> rewardLabelPool;

	int poolSize = 10;

	public Character[] GetCharacters()
	{
		return allPlayers.ToArray();
	}

	void Awake()
	{
		rewardLabelPool = new List<GameObject>(poolSize);
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
		if (rewardLabelPool.Count < poolSize)
		{
			GameObject exp = NGUITools.AddChild(character, expPrefab);
			rewardLabelPool.Add(exp);
			exp.GetComponent<UILabel>().text = amount.ToString();
			StartCoroutine("RemoveReward");
		}
	}

	IEnumerator RemoveReward()
	{
		yield return new WaitForSeconds(1f);
		NGUITools.SetActive(rewardLabelPool.Last(), false);
		StartCoroutine(DestroyGameObject(rewardLabelPool.Last()));
		rewardLabelPool.RemoveAt(0);
	}

	public IEnumerator DestroyGameObject(GameObject go)
	{
		yield return new WaitForFixedUpdate();

		NGUITools.Destroy(go);
	}
}
