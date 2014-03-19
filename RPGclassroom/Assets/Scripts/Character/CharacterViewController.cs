using UnityEngine;

public class CharacterViewController : MonoBehaviour
{
	const int expWidth = 250;
	const float expToLevel = 1000;
	StarCounter expDisplay;
	UI2DSprite AuraSprite;
	UILabel LevelText;
	Character character;

	void Awake()
	{
		character = new Character();
		AuraSprite = transform.Find("Aura").GetComponent<UI2DSprite>();
		expDisplay = transform.Find("Experience").GetComponent<StarCounter>();
		LevelText = transform.Find("Level").GetComponent<UILabel>();
		AuraSprite.alpha = 0;
		AuraSprite.enabled = false;
		SetExpBar();
	}

	public void GiveExp(int exp)
	{
        for (int i = 1; i <= exp; ++i)
        {
            int prevLevel = character.level;

            character.Exp++;

            expDisplay.ActivateMoreStars(1);
            SetExpBar();

            // If the level changed we want to reset the stars
            // and change the text for the new level.
            if (character.levelsChanged > 0)
            {
                SetLevelText();
                expDisplay.ResetStars();
            }
        }

        Debug.Log("Exp Gained " + exp);

		Classroom.Singleton.DestroyGameObject(gameObject);
		Classroom.Singleton.DisplayReward(exp, gameObject);
	}

	void SetExpBar()
	{
		float exp = character.Exp;
		Debug.Log ("EXP " + exp);
		float percentage = 0;
		percentage = (exp / expToLevel);
		Debug.Log ("Percentage " + percentage);

//		if (percentage == 0)
//		{
//			//NGUITools.SetActive(ExpBarFront.gameObject, false);
//			//ExpBarFront.enabled = false;
//		}
//		else
//		{
			//NGUITools.SetActive(ExpBarFront.gameObject, true);
			//ExpBarFront.enabled = true;
			//ExpBarFront.width = (int)(percentage * expWidth);
			//expDisplay.value = percentage;
//		}
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