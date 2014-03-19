using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarCounter : MonoBehaviour {

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
    private List<Star> starsList = new List<Star>();

	// Use this for initialization
	void Start () 
    {
        foreach (Star star in gameObject.GetComponentsInChildren<Star>())
        {
            starsList.Add(star);
        }
	}

    public void ResetStars()
    {
        foreach (Star star in starsList)
        {
            star.Reset();
        }
    }

    public void ActivateMoreStars(int count)
    {
        int usedCount = 0;

        foreach (Star star in starsList)
        {
            if (star.IsActivated == false && usedCount < count)
            {
                star.SetActive();
                usedCount++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
	}

	public void PlayGain()
	{

	}
}
