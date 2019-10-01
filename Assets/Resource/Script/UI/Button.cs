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
    }
    public void TileTabActive()
    {
        inventory.ShowItem(ItemType.Tile);
    }
    public void EtcTabActive()
    {
        inventory.ShowItem(ItemType.Etc);
    }
}
