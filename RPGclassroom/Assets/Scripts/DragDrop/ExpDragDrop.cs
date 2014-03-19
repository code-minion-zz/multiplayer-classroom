
using UnityEngine;

public class ExpDragDrop : CharacterDragDropItem
{	
	public int ExpValue = 0;
    private UIPlaySound playSound;
	
	protected override void OnDragDropRelease (GameObject surface)
	{
		if (surface != null)
		{
            playSound = GetComponent<UIPlaySound>();

            if (playSound != null)
            {
                playSound.Play();
            }

			CharacterViewController cvc = surface.GetComponent<CharacterViewController>();
			if (cvc != null)
			{
				//GameObject child = NGUITools.AddChild(cvc.gameObject, prefab);
				cvc.GiveExp(ExpValue);
			}
		}
		NGUITools.Destroy(gameObject);
	}
}
