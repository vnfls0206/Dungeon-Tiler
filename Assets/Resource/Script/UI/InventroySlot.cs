using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventroySlot : MonoBehaviour
{
    private ItemManager ItemManager;

    [SerializeField] private Explain_Window explain_Window;

    [SerializeField] private Image Item_Image;
    [SerializeField] private Text Text_itemCount;


    public void Set_Item(ItemManager itemmanager)
    {
        this.ItemManager = itemmanager;
    }

    private Item slot_item;
    public Item Slot_Item
    {
        get
        {
            return slot_item;
        }
        set
        {
            slot_item = value;

            if(value != null)
            {
                Item_Image.enabled = true;
                Item_Image.sprite = ItemManager.Get_Item_Sprite(slot_item);

                Text_itemCount.enabled = true;
                Text_itemCount.text = "" + slot_item.Item_Count;
            }
            else
            {
                Item_Image.enabled = false;
                Text_itemCount.enabled = false;
            }

        }
    }


    public void OnClick()
    {
        if (Slot_Item != null)
        {
            Item_Data temp = ItemManager.Get_Item_Data(Slot_Item);


            explain_Window.OnWindow();

            explain_Window.Item_name.text = temp.itemName;
            explain_Window.item_desc.text = temp.itemDesc;
            //explain_Window.Explain_image.sprite = itemImage.sprite;
        }
    }
}
