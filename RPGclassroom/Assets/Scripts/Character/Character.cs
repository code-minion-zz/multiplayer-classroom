using UnityEngine;
using System.Collections;

public class Character
{
	public int uid;
	int exp;

	public int Exp
	{
		get { return exp; }
		set { exp = value; }
	}

	public Character()
	{
		exp = 0;
		uid = 0;
		// TODO: create a factory or manager that hands out UID and other properties
	}
}
