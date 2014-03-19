using UnityEngine;
using System.Collections;

public class Character
{
	public int uid;
	int exp = 0;
	public int level = 1;
	public int levelsChanged = 0;

	string name = "";
	public string Name
	{
		get {return name;}
		set {name = value;}
	}

	public int Exp
	{
		get { return exp; }
		set 
		{
			exp = value;
			while (exp >= 10)
			{
				exp -= 10;
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
