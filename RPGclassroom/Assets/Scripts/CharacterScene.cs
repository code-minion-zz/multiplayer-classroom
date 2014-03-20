using UnityEngine;
using System.Collections;

public class CharacterScene : MonoBehaviour {
		
	static CharacterScene characterScene;

	public static CharacterScene Instance
	{
		get
		{
			if (characterScene == null)
			{
				characterScene = GameObject.Find("Characters Window").GetComponent<CharacterScene>();
			}
			return characterScene;
		}
	}

	UIGrid characterGrid;

	// Use this for initialization
	void Awake () 
	{
		characterGrid = transform.Find("Scroll View").Find("Grid").GetComponent<UIGrid>();

		if (characterScene == null)
		{
			characterScene = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCharacter()
	{
		GameObject prefab = Resources.Load("Prefabs/GUI/Character") as GameObject;
		prefab = NGUITools.AddChild(characterGrid.gameObject, prefab);
		characterGrid.repositionNow = true;
	}

	IEnumerator PlaySound(float delay)
	{
		yield return new WaitForSeconds(delay);
		audio.Stop();
		audio.Play();
	}

	public void LevelUpSound(float delay)
	{
		StartCoroutine(PlaySound(delay));
	}
}
