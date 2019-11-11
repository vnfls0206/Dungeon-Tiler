using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    private UIManager UIManager;
    private MapManager MapManager;
    private PlayerManager PlayerManager;

    private bool Button_Active_1;            //임시 

    public void Set_Map(MapManager mapmanager)
    {
        this.MapManager = mapmanager;

    }
    public void Set_UI(UIManager uimanager)
    {
        this.UIManager = uimanager;
        Button_Active_1 = false;
    }
    public void Set_Player(PlayerManager playermanager)
    {
        this.PlayerManager = playermanager;
    }

    public void OnInventory()
    {
        UIManager.Get_Inventory_Function().Set_Activate();
    }

    public void OnOption()
    {
        UIManager.Get_Option_Function().Set_Activate();
    }

    public void WeaponTabActive()
    {
        UIManager.Get_Inventory_Function().ShowItem(ItemType.Weapon);
    }
    public void TileTabActive()
    {
        UIManager.Get_Inventory_Function().ShowItem(ItemType.Tile);
    }
    public void EtcTabActive()
    {
        UIManager.Get_Inventory_Function().ShowItem(ItemType.Etc);
    }

    public void Tile_Set()
    {
        UIManager.Pre_TIle_Set();
    }
}
