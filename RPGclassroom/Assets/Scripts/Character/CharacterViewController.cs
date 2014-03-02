using UnityEngine;

public class CharacterViewController : MonoBehaviour
{
	Character character;

	public void GiveExp(int exp)
	{
		character.Exp += exp;
		// TODO: Spawn EXP popup
	}
}