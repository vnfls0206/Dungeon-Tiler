using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventroySlot : MonoBehaviour
{
    public int itemPrice;          //가격
    public int itemCount;          //갯수
    public string itemName;        //이름    
    public string itemDesc;        //설명
    public ItemType itemType;      //타입
    public Image itemImage;        //이미지

    public Explain_Window explain_Window;
    public Text Text_itemCount;

    public void Additem(Item _item)
    {
        itemName = _item.itemName;
        itemPrice = _item.itemPrice;
        itemDesc = _item.itemDesc;
        itemType = _item.itemType;
        itemImage.sprite = _item.itemImage;
        itemCount = _item.itemCount;

        if(itemType == ItemType.Etc)
        {
            if (itemCount > 1)
                Text_itemCount.text = ""+itemCount;
        }
    }

    public void RemoveItem()
    {
        itemName    = null;
        itemDesc    = null;
        itemPrice   = 0;
        itemType    = ItemType.NULL;
        itemImage.sprite = null;
        Text_itemCount.text = "";
    }

    public void OnClick()
    {
        if(itemType != ItemType.NULL)
        {
            explain_Window.OnWindow();

            explain_Window.Item_name.text = itemName;
            explain_Window.item_desc.text = itemDesc;
            explain_Window.Explain_image.sprite = itemImage.sprite;
        }
    }
}
