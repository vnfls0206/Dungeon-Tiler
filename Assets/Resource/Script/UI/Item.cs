using UnityEngine.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon =0,
    Tile,
    Etc,
    NULL
}

[System.Serializable]
public class Item
{
    public ItemType itemType;      //타입
    public string itemName;        //이름    
    public string itemDesc;        //설명
    public int itemPrice;          //가격
    public int itemCount;          //갯수
    public Sprite itemImage;       //이미지


    public Item(string _itemName, int _itemPrice, string _itemDesc, ItemType _itemType, Sprite _itemSprite, int _itemCount =1)
    {
        itemName = _itemName;
        itemPrice = _itemPrice;
        itemDesc = _itemDesc;
        itemType = _itemType;
        itemImage = _itemSprite;
        itemCount = _itemCount;
    }
}

