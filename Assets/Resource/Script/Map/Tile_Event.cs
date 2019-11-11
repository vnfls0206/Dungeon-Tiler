using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Event : MonoBehaviour
{
    private MapManager MapManager;

    private int Door_Move_Speed;

    public void Set_Map(MapManager mapmanager)
    {
        this.MapManager = mapmanager;
        this.Door_Move_Speed = 8;
    }

    public IEnumerator Step_Beggin_Event_By_Obj(BaseActor actor,Tile tile)
    {
        switch (tile.Tile_Sort.TileObject)
        {
            case eTileObject.DOOR:
                {
                    yield return StartCoroutine(Tile_Move_event((MapManager.Get_TileObj_By_Tile(tile)),
                        new Vector3(tile.x, tile.y, 1f)));



                    break;
                }
        }

        yield return null;
    }


    public IEnumerator Step_on_Event_By_Obj(BaseActor actor, Tile tile)
    {

        switch (tile.Tile_Sort.TileObject)
        {
            case eTileObject.DOOR:
                {
                    break;
                }
        }

        yield return null;
    }

    public IEnumerator Step_End_Event_By_Base(BaseActor actor, Tile tile)
    {

        switch (tile.Tile_Sort.TileObject)
        {
            case eTileObject.DOOR:
                {
                    break;
                }
        }

        yield return null;
    }

    public IEnumerator Step_End_Event_By_Obj(BaseActor actor,Tile tile)
    {
        switch (tile.Tile_Sort.TileObject)
        {
            case eTileObject.DOOR:
                {
                    yield return StartCoroutine(Tile_Move_event((MapManager.Get_TileObj_By_Tile(tile)),
                        new Vector3(tile.x, tile.y, 0f)));

                    break;
                }
        }

        yield return null;
    }

    public void Tile_Set_Event_By_Base(eTileBase etilebase)
    {
        switch(etilebase)
        {
            case eTileBase.MMOSS_OF_STONE:
                {
                    break;
                }
                

        }

    }

    public void Tile_Set_Event_By_Obj(eTileBase etilebase)
    {

    }


    public IEnumerator Tile_Move_event(Tile_Obj tile, Vector3 dex)
    {
        Vector3 Starting_Postionm = tile.transform.position;

        while (!(Mathf.Abs(tile.transform.position.z - dex.z) <= 0.05f))
        {
            tile.transform.position = Vector3.MoveTowards(tile.transform.position, dex,
            Door_Move_Speed * Time.deltaTime);

            yield return null;

        }


    }





}
