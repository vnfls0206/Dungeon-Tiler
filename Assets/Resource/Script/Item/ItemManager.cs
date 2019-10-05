using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour, IManager
{
    private GameManager GameManager;

    public void Set_Manager(GameManager gamemanager)
    {
        this.GameManager = gamemanager;
    }

    public void Update_Manager()
    {

    }

    [Header("ScriptableObject")]
    [SerializeField] private Tile_Data_Object Tile_Data_Object;

    [Header("Atlas")]
    [SerializeField] private UnityEngine.U2D.SpriteAtlas Tile_atlas;

    public Item_Data Get_Item_Data(Item item)
    {
        Item_Data temp = null;

        switch (item.Item_Type)
        {
            case ItemType.Weapon:
                break;

            case ItemType.Tile:
                temp = Get_Tile_Data(item.Item_No);
                break;

            case ItemType.Etc:
                break;
        }

        return temp;
    }

    public Tile_Data Get_Tile_Data(int Tile_Num)
    {
        return Tile_Data_Object.Tile_Data_List[Tile_Num];
    }


    public Sprite Get_Item_Sprite(Item item)
    {
        Sprite temp = null;

        switch (item.Item_Type)
        {
            case ItemType.Weapon:
                break;

            case ItemType.Tile:
                temp = Get_Tile_Sprite(item.Item_No);
                break;

            case ItemType.Etc:
                break;
        }

        return temp;
    }

    private Sprite Get_Tile_Sprite(int Tile_Num)
    {
        return Tile_atlas.GetSprite("" + Tile_Num);
    }


}
