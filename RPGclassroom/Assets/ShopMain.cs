using UnityEngine;
using System.Collections;

public class ShopMain : MonoBehaviour 
{
    public GameObject[] ItemList;
    public UIToggle firstToggle;

    bool initialised;

    public void Update()
    {
        // This will ensure that only one list is toggled on and displayed.
        if (!initialised)
        {
            foreach (GameObject g in ItemList)
            {
                g.SetActive(false);
            }

            firstToggle.value = true;

            initialised = true;
        }
    }
}
