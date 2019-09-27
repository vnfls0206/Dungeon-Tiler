using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private MapManager MapManager;

    [SerializeField] private GameObject Nomal_Object;
    [SerializeField] private GameObject Wall_Object;

    public void Set_Tile(MapManager mapmanager)
    {
        this.MapManager = mapmanager;
    }

    private GameObject active_tile;
    private GameObject Active_Tile
    {
        get {   return active_tile;  }
        set
        {
            active_tile = value;
            active_tile.SetActive(true);
        }
    }

    private TIle_Data tile_data;
    public TIle_Data Tile_Data
    {
        get {   return tile_data;   }
        set
        {
            tile_data = value;
            Update_Tile_Sort(tile_data.Tile_Sort);
            Update_Sight_Sort(tile_data.Sight_Sort);
        }
    }
    public eTile Tile_Sort
    {
        get { return Tile_Data.Tile_Sort; }
        set
        {
            Update_Tile_Sort(value);
        }
    }

    public Sight_Sort Sight_Sort
    {
        get { return Tile_Data.Sight_Sort; }
        set
        {
            Update_Sight_Sort(value);
        }
    }


    private void Update_Tile_Sort(eTile Tile_Sort)
    {
        if(Active_Tile != null)
            Active_Tile.SetActive(false);

        switch ((int)Tile_Sort)
        { 
            case 1:
            case 3:
                {
                    Active_Tile = Nomal_Object;

                    int Sprite_Num = 0;
                    MeshRenderer renderer = Active_Tile.GetComponent<MeshRenderer>();
                    renderer.material.mainTexture = MapManager.Get_Tile_From_Atlas(Sprite_Num);
                    break;
                }

            case 2:
                {
                    Active_Tile = Wall_Object;

                    int Sprite_Num = 1;
                    MeshRenderer renderer = Active_Tile.GetComponent<MeshRenderer>();
                    renderer.material.mainTexture = MapManager.Get_Tile_From_Atlas(Sprite_Num);
                    break;
                }
        }



    }
    private void Update_Sight_Sort(Sight_Sort Sight_Sort)
    {
        if(Active_Tile != null)
        {
            MeshRenderer renderer = Active_Tile.GetComponent<MeshRenderer>();

            switch (Sight_Sort)
            {
                case Sight_Sort.Black:
                    {
                        renderer.enabled = false;
                        break;
                    }
                case Sight_Sort.Deep_Gray:
                    {
                        renderer.enabled = true;
                        renderer.materials[0].color = new Color(0.2f, 0.2f, 0.2f, 1);
                        break;
                    }
                case Sight_Sort.White:
                    {
                        renderer.enabled = true;
                        renderer.materials[0].color = Color.white;
                        break;
                    }
            }
        }

    }




}
