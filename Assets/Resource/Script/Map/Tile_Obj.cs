using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Obj : MonoBehaviour
{
    private MapManager MapManager;
    private Array_Index Array_Index;

    [SerializeField] private GameObject Nomal_Object;
    [SerializeField] private GameObject Wall_Object;

    private MeshRenderer rend;

    public void Set_Tile(MapManager mapmanager, Array_Index array_index)
    {
        this.MapManager = mapmanager;
        this.Array_Index = array_index;
        //this.Nomal_Object.gameObject.transform.localScale = new Vector3(0.95f, 0.95f, 1f);
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

    private Tile tile;
    public Tile Tile
    {
        get {   return tile;   }
        set
        {
            tile = value;
            Update_Tile_Sort(tile.Tile_Sort);
            Update_Sight_Sort(tile.Sight_Sort);
        }
    }
    public eTile Tile_Sort
    {
        get { return Tile.Tile_Sort; }
        set
        {
            Tile.Tile_Sort = value;
            Update_Tile_Sort(value);
        }
    }

    public Sight_Sort Sight_Sort
    {
        get { return Tile.Sight_Sort; }
        set
        {
            Tile.Sight_Sort = value;
            Update_Sight_Sort(value);
        }
    }



    private void Update_Tile_Sort(eTile Tile_Sort)
    {
        if(Active_Tile != null)
            Active_Tile.SetActive(false);

        if (Tile_Sort != eTile.NULL)
        {
            switch (MapManager.Is_Move_Able_Tile(Tile_Sort))
            {
                case true:
                    {
                        Active_Tile = Nomal_Object;

                        int Sprite_Num = (int)Tile_Sort - 1;
                        rend = Active_Tile.GetComponent<MeshRenderer>();
                        rend.material.mainTexture = MapManager.Get_Tile_From_Atlas(Sprite_Num);
                        break;
                    }

                case false:
                    {
                        Active_Tile = Wall_Object;

                        int Sprite_Num = (int)Tile_Sort - 1; ;
                        rend = Active_Tile.GetComponent<MeshRenderer>();
                        rend.material.mainTexture = MapManager.Get_Tile_From_Atlas(Sprite_Num);
                        break;
                    }
            }
        }
    }
    private void Update_Sight_Sort(Sight_Sort Sight_Sort)
    {
        if(Active_Tile != null)
        {
            switch (Sight_Sort)
            {
                case Sight_Sort.Black:
                    {
                        rend.enabled = false;
                        break;
                    }
                case Sight_Sort.Deep_Gray:
                    {
                        rend.enabled = true;
                        rend.materials[0].color = new Color(0.2f, 0.2f, 0.2f, 1);
                        break;
                    }
                case Sight_Sort.White:
                    {
                        rend.enabled = true;
                        rend.materials[0].color = Color.white;
                        break;
                    }
            }
        }
    }



    public Array_Index Get_Array_Index()
    {
        return this.Array_Index;
    }

}
