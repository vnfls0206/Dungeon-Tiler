using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TIle_Data
{
    public Vector3 Tile_Position;
    public eTile Tile_Sort;

    public TIle_Data(Vector3 tile_position ,eTile tile_sort)
    {
        this.Tile_Position = tile_position;
        this.Tile_Sort = tile_sort;
    }
}


public enum eTile
{
    NULL = 0,
    NOMAL,
    WALL,
    DOOR,
    COUNT
}

public enum eDirection
{
    Up = 0,
    Down,
    Left,
    Right,
    Count
}


public class MapManager : MonoBehaviour, IManager
{
    [SerializeField] private GameManager GameManager;
    private PlayerManager PlayerManager;

    [SerializeField] private List<Tile> Tiles;
    private TIle_Data[,] MapData { get; set; }
    private int MapSize { get; set; }

    int roomMin = 6;
    int roomMax = 14;


    public void Set_Manager(GameData gamedata)  //Awake에 해당한다. 시작시 호출
    {
        PlayerManager = GameManager.PlayerManager;  //게임 매니저로 부터 Manager를 받아온다

        MapSize = 64;
        MapData = new TIle_Data[64 + 1, 64 + 1];

        if (gamedata != null)    //게임 데이터가 있을때 Load 해준다
        {

        }
        else                    //게임 데이터가 없을때 시작
        {
            BuildMap();
        }

        Update_Tiles();
    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {
        
    }

    public void SetTile(int x, int y, eTile tile_sort)
    {
        if (MapData[x, y] == null)
        {
            MapData[x, y] = new TIle_Data(new Vector3(x, y) , tile_sort);
        }
        else
        {
            MapData[x, y].Tile_Sort = tile_sort;
        }
    }

    public TIle_Data GetTile(int x, int y)
    {
        if (MapData[x, y] == null)
            SetTile(x, y, eTile.NULL);

        return MapData[x, y];
    }

    private void BuildMap()
    {
        //DrawRoom(0, 0, 64, 64);


        int x = Mathf.RoundToInt(Random.Range(0.3f, 0.7f) * MapSize);
        int y = Mathf.RoundToInt(Random.Range(0.3f, 0.7f) * MapSize);

        PlayerManager.SetPlayerPosition(new Vector3(x, y));
        BuildRoom(x, y, GetRandomDirection());
        //map.Build(tk2dTileMap.BuildFlags.Default);
    }

    eDirection GetRandomDirection()
    {
        int res = Random.Range(0, (int)eDirection.Count);
        return (eDirection)res;
    }

    bool BuildRoom(int x, int y, eDirection direction)
    {
        int sx = 0;
        int sy = 0;
        int ex = 0;
        int ey = 0;
        bool found = false;

        for (int attempt = 0; attempt < 5; attempt++)
        {
            int width = Random.Range(roomMin, roomMax);
            width = width % 2 == 0 ? width : width + 1;
            int height = Random.Range(roomMin, roomMax);
            height = height % 2 == 0 ? height : height + 1;


            switch (direction)
            {
                case eDirection.Up:
                    sx = x - width / 2;
                    sy = y;
                    break;
                case eDirection.Down:
                    sx = x - width / 2;
                    sy = y - height;
                    break;
                case eDirection.Left:
                    sx = x - width;
                    sy = y - height / 2;
                    break;
                case eDirection.Right:
                    sx = x;
                    sy = y - height / 2;
                    break;
            }

            ex = sx + width;
            ey = sy + height;
            if (IsClear(sx, sy, ex, ey) == true)
            {
                found = true;
                break;
            }
        }

        if (found == false)
        {
            return false;
        }

        DrawRoom(sx, sy, ex, ey);
        ExpandRoom(sx, sy, ex, ey);
        return true;
    }

    void ExpandRoom(int sx, int sy, int ex, int ey)
    {
        int upDoorX = Random.Range(sx + 1, ex);
        if (GetTile(upDoorX, ey).Tile_Sort == eTile.WALL)
        {
            if (BuildRoom(upDoorX, ey, eDirection.Up) == true)
            {
                SetTile(upDoorX, ey, eTile.DOOR);
            }
        }

        int downDoorX = Random.Range(sx + 1, ex);
        if (GetTile(downDoorX, sy).Tile_Sort == eTile.WALL)
        {
            if (BuildRoom(downDoorX, sy, eDirection.Down) == true)
            {
                SetTile(downDoorX, sy, eTile.DOOR);
            }
        }

        int leftDoorY = Random.Range(sy + 1, ey);
        if (GetTile(sx, leftDoorY).Tile_Sort == eTile.WALL)
        {
            if (BuildRoom(sx, leftDoorY, eDirection.Left) == true)
            {
                SetTile(sx, leftDoorY, eTile.DOOR);
            }
        }

        int rightDoorY = Random.Range(sy + 1, ey);
        if (GetTile(ex, rightDoorY).Tile_Sort == eTile.WALL)
        {
            if (BuildRoom(ex, rightDoorY, eDirection.Right) == true)
            {
                SetTile(ex, rightDoorY, eTile.DOOR);
            }
        }
    }

    void DrawRoom(int sx, int sy, int ex, int ey)
    {
        Debug.Log(sx);
        Debug.Log(ex);
        Debug.Log(sy);
        Debug.Log(ey);

        for (int x = sx; x <= ex; x++)
        {
            FillWall(x, sy);
            FillWall(x, ey);
        }

        for (int y = sy; y <= ey; y++)
        {
            FillWall(sx, y);
            FillWall(ex, y);
        }

        for (int y = sy + 1; y <= ey - 1; y++)
        {
            for (int x = sx + 1; x <= ex - 1; x++)
            {
                SetTile(x, y, eTile.NOMAL);
            }
        }
    }

    void FillWall(int x, int y)
    {
        if (GetTile(x, y).Tile_Sort == eTile.NULL)
        {
            SetTile(x, y, eTile.WALL);
        }
    }

    bool IsClear(int sx, int sy, int ex, int ey)
    {
        if (sx <= 0 || ex > MapSize || sy <= 0 || ey > MapSize)
        {
            return false;
        }

        for (int y = sy + 1; y <= ey - 1; y++)
        {
            for (int x = sx + 1; x <= ex - 1; x++)
            {
                if (GetTile(x, y).Tile_Sort != eTile.NULL)
                {
                    return false;
                }
            }
        }

        return true;
    }


    public void Update_Tiles()
    {
        Vector3 Player_Position = PlayerManager.GetPlayerPosition();

        int x = (int)Player_Position.x - 5;
        int y = (int)Player_Position.y - 5;


        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                if(x >= 0 && x <= MapSize 
                && y >= 0 && y <= MapSize)       //해당 좌표에 타일이 있는가
                {
                    if (MapData[x, y] == null)
                        SetTile(x, y, eTile.NULL);


                    Tiles[Get_Array_Count(i, j)].Tile_Data = MapData[x, y];
                    Tiles[Get_Array_Count(i, j)].transform.position = new Vector3(x, y);

                    //Tiles[i, j].Tile_Data = MapData[x, y];
                    //Tile_Objects[x, y] =  (int)MapData[x, y].Tile_Sort 

                }

                y++;

            }
            y = (int)Player_Position.y - 5;
            x++;
        }


    }

    private int Get_Array_Count(int x, int y)
    {
        return ((x + y * 10));
    }


}
