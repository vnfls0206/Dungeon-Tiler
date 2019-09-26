using UnityEngine.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;

    public SpriteAtlas spriteAtlas;
    private InventroySlot[] slots;          //인벤토리 슬롯들

    public List<Item> inventoryList_Weapon;    //가지고 있는 무기 리스트
    public List<Item> inventoryList_Tile;      //가지고 있는 타일 리스트
    public List<Item> inventoryList_Etc;       //가지고 있는 기타 아이템 리스트

    public GameObject inventory;                    // slot 부모객체


    void Start()
    {
        inventoryList_Weapon = new List<Item>();
        inventoryList_Tile = new List<Item>();
        inventoryList_Etc = new List<Item>();

        slots = inventory.transform.GetComponentsInChildren<InventroySlot>();

        AddItem(new Item("Axe", 500, "Good Axe", ItemType.Weapon, spriteAtlas.GetSprite("Axe")));
        AddItem(new Item("Apple", 50, "Delicious Apple", ItemType.Etc, spriteAtlas.GetSprite("Apple"),5));
        AddItem(new Item("Wood_Tile", 0, "나무로 된 타일", ItemType.Tile, spriteAtlas.GetSprite("Wood_Tile")));
        AddItem(new Item("Axe", 500, "Good Axe", ItemType.Weapon, spriteAtlas.GetSprite("Axe")));
        AddItem(new Item("Apple", 50, "Delicious Apple", ItemType.Etc, spriteAtlas.GetSprite("Apple"),4));
        AddItem(new Item("Wood_Tile", 0, "나무로 된 타일", ItemType.Tile, spriteAtlas.GetSprite("Wood_Tile")));
        AddItem(new Item("Axe", 500, "Good Axe", ItemType.Weapon, spriteAtlas.GetSprite("Axe")));
        AddItem(new Item("Apple", 50, "Delicious Apple", ItemType.Etc, spriteAtlas.GetSprite("Apple"),1));

        ShowItem(0);
    }
    void Update()
    {
        if(inventoryEnabled == true)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);
    }
    public void AddItem(Item _item)
    {
        switch(_item.itemType)
        {
            case ItemType.Weapon:
                if (inventoryList_Weapon.Count < 20)
                    inventoryList_Weapon.Add(_item);
                else
                    print("웨폰인벤토리 가득참");
                break;
            case ItemType.Tile:
                if (inventoryList_Tile.Count < 20)
                    inventoryList_Tile.Add(_item);
                else
                    print("타일인벤토리 가득참");
                break;
            case ItemType.Etc:
                if (inventoryList_Etc.Count < 20)
                    inventoryList_Etc.Add(_item);
                else
                    print("기타 인벤토리 가득참");
                break;
        }
    }
    public void ShowItem(ItemType itemType)
    {
        RemoveSlot();

        switch(itemType)
        {
            case ItemType.Weapon:
                for(int i=0; i< inventoryList_Weapon.Count; i++)
                {
                    slots[i].Additem(inventoryList_Weapon[i]);
                }
                break;

            case ItemType.Tile:
                for (int i = 0; i < inventoryList_Tile.Count; i++)
                {
                    slots[i].Additem(inventoryList_Tile[i]);

                }
                break;
            case ItemType.Etc:
                for (int i = 0; i < inventoryList_Etc.Count; i++)
                {
                    slots[i].Additem(inventoryList_Etc[i]);
                }
                break;
        }                                  
    }
    void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
            slots[i].RemoveItem();
    }
}
