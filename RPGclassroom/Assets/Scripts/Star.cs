using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{
    private UISprite sprite;
    private bool isActivated;

    public bool IsActivated
    {
        get { return isActivated; }
        set { isActivated = value; }
    }

	// Use this for initialization
	void Start () 
    {
        sprite = GetComponent<UISprite>();
	}

    public void Reset()
    {
        isActivated = false;

        if (sprite != null)
        {
            sprite.color = Color.grey;
        }
    }

    public void SetActive()
    {
        if (sprite != null)
        {
            sprite.color = Color.magenta;
        }

        isActivated = true;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
