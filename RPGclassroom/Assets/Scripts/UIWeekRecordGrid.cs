using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("WeekGrid")]
public class UIWeekRecordGrid :  UIGrid
{
    [ContextMenu("Execute")]
    public override void Reposition()
    {
        base.Reposition();

        Transform myTrans = transform;

        List<Transform> list = new List<Transform>();

        for (int i = 0; i < myTrans.childCount; ++i)
        {
            Transform t = myTrans.GetChild(i);
            if (t && (!hideInactive || NGUITools.GetActive(t.gameObject))) list.Add(t);
        }
       // Sort(list);

        for (int i = 0; i < list.Count; ++i)
        {
            list[i].GetComponent<UILabel>().text = "Week " + (i + 1);
        }
    }
}
