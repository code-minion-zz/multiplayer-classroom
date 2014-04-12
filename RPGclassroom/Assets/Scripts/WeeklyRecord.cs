using UnityEngine;
using System.Collections;

public class WeeklyRecord : MonoBehaviour 
{
    public StarSlot[] starSlots;

	public void EnableStars(bool b)
	{
		foreach(StarSlot star in starSlots)
		{
			star.EnableStar(b);
		}
	}
}
