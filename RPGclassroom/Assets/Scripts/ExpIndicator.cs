using UnityEngine;
using System.Collections;

public class ExpIndicator : MonoBehaviour {

//	bool dirty = false;
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
	public GameObject[] starArray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PlayGain()
	{

	}
}
