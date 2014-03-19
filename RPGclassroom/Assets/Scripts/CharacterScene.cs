using UnityEngine;
using System.Collections;

public class CharacterScene : MonoBehaviour {

	UIGrid characterGrid;

	// Use this for initialization
	void Start () {
		characterGrid = transform.Find("Scroll View").Find("Grid").GetComponent<UIGrid>();
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
}
