using UnityEngine.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemType
{
    Weapon = 0,
    Tile,
    Etc,
    NULL
}

[System.Serializable]
public class Item
{
    public ItemType Item_Type;
    public int Item_No;
    public int Item_Count;

    public Item(ItemType item_type, int item_no, int item_count)
    {
        this.Item_Type = item_type;
        this.Item_No = item_no;
        this.Item_Count = item_count;
    }

}

[System.Serializable]
public abstract class Item_Data
{
    public string itemName;        //이름    
    public string itemDesc;        //설명
    public int itemPrice;          //가격


}
[System.Serializable]
public class Tile_Data :Item_Data
{


}

