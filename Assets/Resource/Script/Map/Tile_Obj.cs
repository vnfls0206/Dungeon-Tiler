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
    public Tile_Sort tile_Sort
    {
        get { return Tile.Tile_Sort; }
        set
        {
            tile.Tile_Sort = value;
            Update_Tile_Sort(value);
        }
    }

    public Sight_Sort Sight_Sort
    {
        get { return Tile.Sight_Sort; }
        set
        {
            tile.Sight_Sort = value;
            Update_Sight_Sort(value);
        }
    }



    private void Update_Tile_Sort(Tile_Sort Tile_Sort)
    {
        Nomal_Object.SetActive(false);
        Wall_Object.SetActive(false);

        int z_axis = 0;

        if (Tile_Sort.TileBase != eTileBase.NULL)   //Base가 비어있지 않을때
        {
            if (MapManager.Is_Block_Object(Tile_Sort))   //벽오브젝트가 있으면
            {
                Wall_Object.SetActive(true);

                int Sprite_Num = (int)Tile_Sort.TileObject - 1;

                rend = Wall_Object.GetComponent<MeshRenderer>();
                rend.material = MapManager.Get_TileObject_From_List(Sprite_Num);


                if (Tile_Sort.TileObject == eTileObject.DOOR)
                {
                    if(Tile.Tile_Actor != null)
                        z_axis = 1;
                }
                    
                //this.transform.position = new Vector3(Tile.x, Tile.y, -0.5f);


            }
            else                        //벽오브젝트가 아니면
            {

                Nomal_Object.SetActive(true);
                //

                int Sprite_Num = (int)Tile_Sort.TileBase - 1;
                rend = Nomal_Object.GetComponent<MeshRenderer>();
                rend.material.mainTexture = MapManager.Get_TileBase_From_List(Sprite_Num);

                if(Tile_Sort.TileObject == eTileObject.NULL)   //오브젝트가 없으면)
                {

                }
                    
            }

        }

        this.transform.position = new Vector3(Tile.x, Tile.y, z_axis);

    }
    private void Update_Sight_Sort(Sight_Sort Sight_Sort)
    {
        if(tile_Sort.TileBase != eTileBase.NULL)
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

    public MeshRenderer get_rend()
    {
        return rend;
    }



}
