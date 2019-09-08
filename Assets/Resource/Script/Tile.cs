using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject Nomal_Object;
    [SerializeField] private GameObject Wall_Object;


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
            Update_Tile(value);
        }
    }


    private void Update_Tile(TIle_Data tile_data)
    {
        if(Active_Tile != null)
            Active_Tile.SetActive(false);

        switch ((int)tile_data.Tile_Sort)
        { 
            case 1:
            case 3:
                {
                    Active_Tile = Nomal_Object;
                    break;
                }

            case 2:
                Active_Tile = Wall_Object;
                Wall_Object.GetComponent<MeshRenderer>().materials[0].color = Color.black;
                break;


        }


    }




}
