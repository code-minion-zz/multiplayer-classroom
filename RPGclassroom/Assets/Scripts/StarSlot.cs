using UnityEngine;
using System.Collections;

public class StarSlot : MonoBehaviour 
{
    public UISprite starSlot;
    public UIPanel star;

	public void EnableStar(bool b)
	{
		star.gameObject.SetActive(b);
	}
}
