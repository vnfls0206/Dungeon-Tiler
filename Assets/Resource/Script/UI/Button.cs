using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Inventory inventory;
    // Start is called before the first frame update
    public void OnInventory()
    {
        inventory.inventoryEnabled = !inventory.inventoryEnabled;
    }
    public void WeaponTabActive()
    {
        inventory.ShowItem(ItemType.Weapon);
        print("WeaponTabActive");
    }
    public void TileTabActive()
    {
        inventory.ShowItem(ItemType.Tile);
        print("TileTabActive");
    }
    public void EtcTabActive()
    {
        inventory.ShowItem(ItemType.Etc);
        print("EtcTabActive");
    }
}
