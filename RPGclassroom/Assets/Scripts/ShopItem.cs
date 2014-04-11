using UnityEngine;
using System.Collections;

public class ShopItem : MonoBehaviour 
{
    public UISprite sprite;
    public UIButton button;

    public UISprite lockedSprite;
    public UISprite redBannerSprite;

    public UILabel costLabel;
    public UILabel levelReqLabel;

    public UISprite goldCoinSprite;

    private bool canBuy;
    private bool canEquip;

    private Item item;

    public void Start()
    {
        button.enabled = false;
    }

    public void Initialise(Item item)
    {
        if (item == null)
            return;

        this.item = item;

        // Disable the lock sprites if the items are unlocked
        if (item.unlocked)
        {
            lockedSprite.enabled = false;
            redBannerSprite.enabled = false;
            levelReqLabel.enabled = false;
        }
        else
        {
            lockedSprite.enabled = true;
            redBannerSprite.enabled = true;
            levelReqLabel.enabled = true;
            levelReqLabel.text = "Req Lv " + item.levelRequirement;
        }

        if (item.purchased)
        {
            costLabel.enabled = true;
            costLabel.text = item.itemCost.ToString();
        }
        else
        {
            costLabel.enabled = false;
        }
    }

    public void Update()
    {
        if (gameObject == transform.parent.GetComponent<UICenterOnChild>().centeredObject)
        {
            button.enabled = true;
        }
        else
        {
            button.enabled = false;
        }
    }

    public void SetItem(Item newItem)
    {
        if (item == newItem) return;

        // Set item and update the sprite image
        item = newItem;
        sprite.spriteName = item.spriteName;
    }

    public void OnClick()
    {
        if (canBuy)
        {
            Purchase();
        }
    }

    public void Purchase()
    {
        
    }

    public void Equip()
    {

    }
}
