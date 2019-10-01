using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTarget : MonoBehaviour
{
    private MapManager MapManager;

    private Tile target_tile;
    private Tile Target_Tile
    {
        get
        {
            return target_tile;
        }
        set
        {
            target_tile = value;
            if(target_tile != null)
            {
                if(MapManager.Is_Move_Able_Tile(target_tile.Tile_Sort))
                {
                    this.transform.position = Target_Tile.Tile_Position + new Vector3(0f, 0f, -0.05f);
                }
                else
                {
                    this.transform.position = Target_Tile.Tile_Position + new Vector3(0f, 0f, -1.05f);
                }

                
            }
            
        }
    }

    private bool set_activate;
    public bool Set_Activate
    {
        get
        {
            return set_activate;
        }
        set
        {
            set_activate = value;
            this.gameObject.SetActive(value);

            if(set_activate)
            {
                this.Target_Tile = MapManager.Get_PTile();
                EventManager.TF_Event += Target_Event;
            }
            else
            {
                EventManager.TF_Event -= Target_Event;
            }

        }
    }

    private float T_Scale; 

    public void Set_Map(MapManager mapmanager)
    {
        this.MapManager = mapmanager;

        Set_Activate = true;
        T_Scale = 0f;        
    }

    public void Update_Map()
    {

    }

    public bool Is_In_Target(Tile tile)
    {
        bool temp = true;

        if(Target_Tile == tile)
        {
            temp = true;
        }
        else
        {
            Target_Tile = tile;
            return false;
        }

        return temp;
    }

    private void Target_Event(bool TF)
    {
        if (TF)
        {
            T_Scale += Time.deltaTime;
        }
        else if (!TF)
        {
            T_Scale -= Time.deltaTime;
        }

        this.transform.localScale = new Vector3(1 + T_Scale, 1 + T_Scale, 1);
    }


    public Tile Get_Target_Tile()
    {
        Tile temp = this.Target_Tile;
        return temp;
    }
}
