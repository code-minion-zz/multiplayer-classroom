using UnityEngine;
using System.Collections;

public class StudentMain : MonoBehaviour 
{
	public UILabel studentNameLabel;
    public UILabel levelLabel;
    public UILabel goldLabel;

    public StarSlot[] starSlots;

	public void Start()
	{
		CharacterData.InitialiseTestData();

		studentNameLabel.text = CharacterData.Name;
		levelLabel.text = "Level " + CharacterData.Level.ToString();
		goldLabel.text = CharacterData.Gold.ToString();
	}
}