using UnityEngine;
using System.Collections;

public class CharacterViewController : MonoBehaviour
{
	static GameObject levelUpPrefab1;
	static GameObject levelUpPrefab2;
	static GameObject levelUpPrefab3;
	static CharacterScene sceneController;
	const int expWidth = 250;
	const float expToLevel = 1000;
	StarCounter expDisplay;
	UI2DSprite AuraSprite;
	UILabel LevelText;
	UILabel NameText;
	Character character;

	void Awake()
	{
		character = new Character();

		AuraSprite = transform.Find("Aura").GetComponent<UI2DSprite>();
		expDisplay = transform.Find("Experience").GetComponent<StarCounter>();
		LevelText = transform.Find("Level").GetComponent<UILabel>();
		NameText = transform.Find("Name").GetComponent<UILabel>();
		AuraSprite.alpha = 0;
		AuraSprite.enabled = false;
		SetExpBar();
		RandomName();
	}

	void RandomName()
	{
		int random = Random.Range(0,8);
		string setName = "";
		switch (random)
		{
		case 0:
			setName = "Larry";
			break;
		case 1:
			setName = "Scott";
			break;
		case 2:
			setName = "Terrence";
			break;
		case 3:
			setName = "Eric";
			break;
		case 4:
			setName = "Stan";
			break;
		case 5:
			setName = "Kenny";
			break;
		case 6:
			setName = "Martin";
			break;
		case 7:
			setName = "John";
			break;
		case 8:
			setName = "Glen";
			break;
		}

		character.Name = setName;
	}

	void Start()
	{
		if (!string.IsNullOrEmpty(character.Name))
		{
			SetName(character.Name);
		}
		
		if (levelUpPrefab1 == null)
		{
			levelUpPrefab1 = Resources.Load("Prefabs/Effects/StarBurst") as GameObject;
		}
		
		if (levelUpPrefab2 == null)
		{
			levelUpPrefab2 = Resources.Load("Prefabs/Effects/StarBurst2") as GameObject;
		}
		
		if (levelUpPrefab3 == null)
		{
			levelUpPrefab3 = Resources.Load("Prefabs/Effects/StarTrail") as GameObject;
		}
		
		if (sceneController == null)
		{
			sceneController = CharacterScene.Instance;
		}
	}

	void SetName(string name)
	{
		NameText.text = name;
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
				LevelUp();
            }
        }

        Debug.Log("Exp Gained " + exp);

		//Classroom.Singleton.DestroyGameObject(gameObject);
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

	IEnumerator LimitedLife(GameObject go)
	{
		yield return new WaitForSeconds(2.5f);

		NGUITools.Destroy(go);
	}

	void LevelUp()
	{
		GameObject go1 = NGUITools.AddChild(gameObject, levelUpPrefab1);
		GameObject go2 = NGUITools.AddChild(gameObject, levelUpPrefab2);
		GameObject go3 = NGUITools.AddChild(gameObject, levelUpPrefab3);
		StartCoroutine(LimitedLife(go1));
		StartCoroutine(LimitedLife(go2));
		StartCoroutine(LimitedLife(go3));
		SetLevelText();
		expDisplay.ResetStars();

		sceneController.LevelUpSound(1f);
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