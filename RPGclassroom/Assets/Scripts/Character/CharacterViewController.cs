using UnityEngine;

public class CharacterViewController : MonoBehaviour
{
	const int expWidth = 250;
	const float expToLevel = 1000;
	UISprite ExpBarFront;
	UI2DSprite AuraSprite;
	UILabel LevelText;
	Character character;

	void Awake()
	{
		character = new Character();
		AuraSprite = transform.Find("Aura").GetComponent<UI2DSprite>();
		ExpBarFront = transform.Find("Experience").GetComponent<UISprite>();
		LevelText = transform.Find("Level").GetComponent<UILabel>();
		AuraSprite.alpha = 0;
		AuraSprite.enabled = false;
		SetExpBar();
	}

	public void GiveExp(int exp)
	{
		character.Exp += exp;

		SetExpBar();

		Debug.Log ("Exp Gained " + exp);

		if (character.levelsChanged > 0)
		{
//			Debug.Log("Before SetLevelText");
			SetLevelText ();
//			Debug.Log("After SetLevelText");
		}

		Classroom.Singleton.DestroyGameObject(gameObject);
		Classroom.Singleton.DisplayReward(exp, gameObject);
	}

	void SetExpBar()
	{
		float exp = character.Exp;
		Debug.Log ("EXP " + exp);
		float percentage = (exp / expToLevel);
		Debug.Log ("Percentage " + percentage);

		if (percentage == 0)
		{
			ExpBarFront.enabled = false;
		}
		else
		{
			ExpBarFront.enabled = true;
			ExpBarFront.width = (int)(percentage * expWidth);
		}
	}

	void SetLevelText ()
	{
		int level =  character.level;
		string newLevel = "Level " + level.ToString();
		LevelText.text = newLevel;
		character.levelsChanged = 0;
		switch (level)
		{
		case 2:
			AuraSprite.enabled = true;
			AuraSprite.alpha = 0.2f;
			break;
			
		case 3:
			AuraSprite.enabled = true;
			AuraSprite.alpha = 0.4f;
			break;
			
		case 4:
			AuraSprite.enabled = true;
			AuraSprite.alpha = 0.6f;
			break;
			
		case 5:
			AuraSprite.enabled = true;
			AuraSprite.alpha = 0.8f;
			break;
			
		case 6:
			AuraSprite.enabled = true;
			AuraSprite.alpha = 1f;
			break;
		}
	}
}