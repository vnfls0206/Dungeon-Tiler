using UnityEngine.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public SpriteAtlas m_atlas;
    public static ItemDatabase instance;
    public List<Item> items = new List<Item>();
    
    void Awake()
    {
        instance = this;

        Add("Axe", 500, "Good Axe", ItemType.Weapon);
        Add("Apple", 50, "Delicious Apple", ItemType.Etc);
        Add("Wood_Tile", 0, "나무로 된 타일", ItemType.Tile);
    }

    void Add(string itemName, int itemPrice, string itemDesc, ItemType itemType)
    {
        items.Add(new Item(itemName, itemPrice, itemDesc, itemType, m_atlas.GetSprite(itemName)));
    }

}
