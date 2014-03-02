//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

[AddComponentMenu("Game/UI/Drag Drop Item (Character)")]
public class CharacterDragDropItem : UIDragDropItem
{
	/// <summary>
	/// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
	/// </summary>
	
	public GameObject prefab;
	
	/// <summary>
	/// Drop a 3D game object onto the surface.
	/// </summary>
	
	protected override void OnDragDropRelease (GameObject surface)
	{
//		if (surface != null)
//		{
//			ExampleDragDropSurface dds = surface.GetComponent<ExampleDragDropSurface>();
//			
//			if (dds != null)
//			{
//				GameObject child = NGUITools.AddChild(dds.gameObject, prefab);
//				
//				Transform trans = child.transform;
//				trans.position = UICamera.lastHit.point;
//				
//				if (dds.rotatePlacedObject)
//				{
//					trans.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
//				}
//				
//				// Destroy this icon as it's no longer needed
//				NGUITools.Destroy(gameObject);
//				return;
//			}
//		}
//		base.OnDragDropRelease(surface);
	}
}
