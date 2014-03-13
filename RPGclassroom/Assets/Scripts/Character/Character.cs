using UnityEngine;
using System.Collections;

public class Character
{
	public int uid;
	int exp = 0;
	public int level = 1;
	public int levelsChanged = 0;

	public int Exp
	{
		get { return exp; }
		set 
		{
			exp = value;
			while (exp > 1000)
			{
				exp -= 1000;
				++levelsChanged;
				++level;
			}
		}
	}

	public Character()
	{
		exp = 0;
		uid = 0;
		// TODO: create a factory or manager that hands out UID and other properties
	}
}
