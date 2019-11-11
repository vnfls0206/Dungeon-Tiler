using UnityEngine.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour, UIManager.IUI
{
    private UIManager UIManager;
    private ItemManager ItemManager;

    [SerializeField] private GameObject Inventory_Obj;   // 객체

    private InventroySlot[] slots;          //인벤토리 슬롯들
    private List<Item> inventoryList_Weapon;    //가지고 있는 무기 리스트
    private List<Item> inventoryList_Tile;      //가지고 있는 타일 리스트
    private List<Item> inventoryList_Etc;       //가지고 있는 기타 아이템 리스트


    private bool object_enabled;
    public bool Object_Enabled
    {
        get
        {
            return object_enabled;
        }
        set
        {
            object_enabled = value;
            Inventory_Obj.SetActive(object_enabled);
            if (object_enabled)
            {
                UIManager.Active_UI = this;
                ShowItem(ItemType.Tile);
            }

        }
    }

    public Explain_Window Explain_Window;
    public Log log;

    public void Set_UI(UIManager uImanager)
    {
        this.UIManager = uImanager;

        object_enabled = false;

        inventoryList_Weapon = new List<Item>();
        inventoryList_Tile = new List<Item>();
        inventoryList_Etc = new List<Item>();

        slots = Inventory_Obj.transform.GetComponentsInChildren<InventroySlot>();

        inventoryList_Tile.Add(new Item(ItemType.Tile, 0101, 1));
        inventoryList_Tile.Add(new Item(ItemType.Tile, 0100, 1));
        inventoryList_Tile.Add(new Item(ItemType.Tile, 0200, 1));
        inventoryList_Tile.Add(new Item(ItemType.Tile, 0101, 1));
        inventoryList_Tile.Add(new Item(ItemType.Tile, 0101, 1));

        //AddItem(new Item("Axe", 500, "Good Axe", ItemType.Weapon, spriteAtlas.GetSprite("Axe")));
        //AddItem(new Item("Apple", 50, "Delicious Apple", ItemType.Etc, spriteAtlas.GetSprite("Apple"),5));
        //AddItem(new Item("Wood_Tile", 0, "나무로 된 타일", ItemType.Tile, spriteAtlas.GetSprite("Wood_Tile")));
        //AddItem(new Item("Axe", 500, "Good Axe", ItemType.Weapon, spriteAtlas.GetSprite("Axe")));
        //AddItem(new Item("Apple", 50, "Delicious Apple", ItemType.Etc, spriteAtlas.GetSprite("Apple"),4));
        //AddItem(new Item("Wood_Tile", 0, "나무로 된 타일", ItemType.Tile, spriteAtlas.GetSprite("Wood_Tile")));
        //AddItem(new Item("Axe", 500, "Good Axe", ItemType.Weapon, spriteAtlas.GetSprite("Axe")));
        //AddItem(new Item("Apple", 50, "Delicious Apple", ItemType.Etc, spriteAtlas.GetSprite("Apple"),1));

        //ShowItem(ItemType.Weapon);
    }

    public void Set_Item(ItemManager itemmanager)
    {
        this.ItemManager = itemmanager;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Set_Item(this.ItemManager);
        }
    }

    public void Update_UI()
    {
        
    }

    public void AddItem(Item _item)
    {
        List<Item> temp = Get_Item_List(_item.Item_Type);

        if (temp.Count < 20)
        {
            temp.Add(_item);
            ShowItem(_item.Item_Type);
        }
        else
            print("웨폰인벤토리 가득참");
    }
    public void ShowItem(ItemType itemType)
    {
        List<Item> temp = Get_Item_List(itemType);

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < temp.Count)
            {
                slots[i].Slot_Item = temp[i];
            }
            else
            {
                slots[i].Slot_Item = null;
            }
        }
    }

    public void Remove_Item(ItemType itemType, Item _item, int count)
    {
        List<Item> temp = Get_Item_List(_item.Item_Type);

    }

    public List<Item> Get_Item_List(ItemType itemtype )
    {
        List<Item> temp = null;

        switch (itemtype)
        {
            case ItemType.Weapon:
                temp = inventoryList_Weapon;
                break;
            case ItemType.Tile:
                temp = inventoryList_Tile;
                break;
            case ItemType.Etc:
                temp = inventoryList_Etc;
                break;
        }

        return temp;
    }


    public void Set_Activate()
    {
        Object_Enabled = !Object_Enabled;
    }
}
