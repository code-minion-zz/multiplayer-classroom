using UnityEngine;
using System.Collections;

public class StarCounter : MonoBehaviour 
{
	// affects how stars are colored
	public enum EMode
	{
		Normal,
		Temporary,
	}

	public EMode mode = EMode.Normal;
	static GameObject starPrefab;
	int stars = 0;
	public int Stars
	{
		get { return stars; }
		set
		{
			stars = value;
//			dirty = true;
		}
	}
	public UISprite[] starArray;

	// Use this for initialization
	void Start () 
	{
		if (starPrefab == null)
		{
			starPrefab = Resources.Load("Prefabs/GUI/Star") as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// Adds a star to the grid
	/// </summary>
	void AddStar()
	{

	}

	public void PlayGain()
	{

	}
}
