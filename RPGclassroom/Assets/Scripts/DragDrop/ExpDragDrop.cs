
using UnityEngine;

public class ExpDragDrop : CharacterDragDropItem
{	
	public int ExpValue = 0;
	
	protected override void OnDragDropRelease (GameObject surface)
	{
		if (surface != null)
		{
			CharacterViewController cvc = surface.GetComponent<CharacterViewController>();
			if (cvc != null)
			{
				//GameObject child = NGUITools.AddChild(cvc.gameObject, prefab);
				cvc.GiveExp(ExpValue);
			}
		}
	}
}
