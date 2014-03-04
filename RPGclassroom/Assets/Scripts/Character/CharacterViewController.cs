using UnityEngine;

public class CharacterViewController : MonoBehaviour
{
	UISprite ExpBarFront;
	Character character;

	void Awake()
	{
		character = new Character();
		ExpBarFront = transform.Find("Experience").GetComponent<UISprite>();
		SetExpBar();
	}

	public void GiveExp(int exp)
	{
		character.Exp += exp;
		// TODO: Spawn EXP popup
		SetExpBar();
		Classroom.Singleton.DestroyGameObject(gameObject);
		Classroom.Singleton.DisplayReward(exp, gameObject);
	}

	void SetExpBar()
	{
		ExpBarFront.width = character.Exp;
	}
}