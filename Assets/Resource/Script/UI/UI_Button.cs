using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;

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
}
