using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[System.Serializable]
public class Tile
{
    public int x, y;
    public Vector3 Tile_Position;
    public eTile Tile_Sort;
    public Sight_Sort Sight_Sort;


    public Tile(int X, int Y, Vector3 tile_position, eTile Tile_sort, Sight_Sort sight_sort)
    {
        this.x = X;
        this.y = Y;
        this.Tile_Position = tile_position;
        this.Tile_Sort = Tile_sort;
        this.Sight_Sort = sight_sort;
    }
}


[System.Serializable]
public class RoomData
{
    public int Sx, Sy, Ex, Ey;
    public RoomData(int sx, int sy, int ex, int ey)
    {
        this.Sx = sx;
        this.Sy = sy;
        this.Ex = ex;
        this.Ey = ey;
    }
}

[System.Serializable]
public enum eTile
{
    NULL = 0,
    NOMAL,
    WALL,
    DOOR,
    COUNT
}

public enum Sight_Sort                 //시야값
{
    Black = 0,
    White,
    Deep_Gray,
    Gray

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
    private GameManager GameManager;
    private PlayerManager PlayerManager;
    private CameraManager CameraManager;

    [Header("Component")]
    [SerializeField] private MapHightLight MapHightLight;
    [SerializeField] private MapTarget MapTarget;
    private A_Star A_Star;
    private ShadowCast ShadowCast;
    private MapPattern MapPattern;

    [Header("Object")]
    [SerializeField] private GameObject Tile_Objs;
    [SerializeField] private SpriteAtlas Tile_SpriteAtlas;
    [SerializeField] private List<Texture2D> Tile_Textures;

    [Header("ScriptableObject")]
    [SerializeField] private Stage_Data_Object Stage_Data;

    //public Event.Color_Set_Event_Handler HL_Event;


    private Tile[,] MapData { get; set; }
    private int Current_Stage { get; set; }
    public int MapSize { get; set; }
    private int VisualRange { get; set; }

    private int roomMin;
    private int roomMax;

    private List<int> VisibleOctants;   //8방위 List
    private Tile_Obj[,] Tiles;              //오브젝트 풀링 Tile들
    private List<RoomData> RoomData_List;       //RoomData 저장 List


    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        PlayerManager = GameManager.PlayerManager;  //게임 매니저로 부터 Manager를 받아온다
        CameraManager = GameManager.CameraManager;

        ShadowCast = new ShadowCast(this);  //전장의 안개
        A_Star = new A_Star(this);       //A*알고리즘
        MapPattern = new MapPattern(this);   //맵 패턴 함수
        MapHightLight.Set_Map(this);

        VisibleOctants = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        Tiles = new Tile_Obj[15, 15];                                     
        MapSize = 64;
        VisualRange = 8;
        roomMin = 6;
        roomMax = 13;

        if (GameManager.Get_GameData() != null)    //게임 데이터가 있을때 Load 해준다
        {

        }
        else                    //게임 데이터가 없을때 시작
        {
            Current_Stage = 1;
            MapData = new Tile[MapSize + 1, MapSize + 1];
            RoomData_List = new List<RoomData>();

            BuildMap();                     //맵 정보 생성
        }

        for (int i = 0; i < 15; i++)                //풀링 Object 할당
        {
            for (int j = 0; j < 15; j++)
            {
                Tiles[i, j] = Tile_Objs.transform.GetChild(Get_Array_Count(i, j)).GetComponent<Tile_Obj>();
                Tiles[i, j].Set_Tile(this, new Array_Index(i, j));
            }
            
        }
        Update_Sight();
        Update_Tiles();                   //맵 정보를 기반으로 Tile 업데이트
        MapTarget.Set_Map(this);
    }

    private Vector3 pre_C_postion;
    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {
        //MapHightLight.Update_Map();
    }


    #region BuildMap

    private void BuildMap()
    {
        int x = Mathf.RoundToInt(Random.Range(0.3f, 0.7f) * MapSize);        
        int y = Mathf.RoundToInt(Random.Range(0.3f, 0.7f) * MapSize);

        //PlayerManager.SetPlayerPosition(new Vector3(x, y));
        BuildRoom(x, y, GetRandomDirection());

        int StartRoom_Num = Random.Range(0, RoomData_List.Count);

        PlayerManager.SetPosition(new Vector3
            (Random.Range(RoomData_List[StartRoom_Num].Sx, RoomData_List[StartRoom_Num].Ex),
             Random.Range(RoomData_List[StartRoom_Num].Sy, RoomData_List[StartRoom_Num].Ey)));

        Set_Map_Pattern(StartRoom_Num);
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

        int width = 0;
        int height = 0;

        int dx = 0;
        int dy = 0;

        bool is_width = true;
        bool found = false;

        for (int attempt = 0; attempt < 5; attempt++)
        {
            width = Random.Range(roomMin, roomMax);
            width = width % 2 == 0 ? width : width + 1;

            height = Random.Range(roomMin, roomMax);
            height = height % 2 == 0 ? height : height + 1;



            switch (direction)
            {
                case eDirection.Up:
                    sx = x - width / 2;
                    sy = y;
                    dx = x;
                    dy = y + 1;
                    is_width = true;
                    break;
                case eDirection.Down:
                    sx = x - width / 2;
                    sy = y - height;
                    dx = x;
                    dy = y - 1;
                    is_width = true;
                    break;
                case eDirection.Left:
                    sx = x - width;
                    sy = y - height / 2;
                    dx = x - 1;
                    dy = y;
                    is_width = false;
                    break;
                case eDirection.Right:
                    sx = x;
                    sy = y - height / 2;
                    dx = x + 1;
                    dy = y;
                    is_width = false;
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

        eTile[,] pattern =
             MapPattern.Get_Room_Patterns(new Room_Size(width + 1, height + 1));

        if(is_width)
        {
            if ((pattern[y - sy , x - sx - 1] != Get_Stage_Data().Wall ||
                pattern[y - sy , x - sx + 1] != Get_Stage_Data().Wall ||
                pattern[dy - sy, dx - sx] == Get_Stage_Data().Wall))
            {
                pattern = null;
            }
        }
        else if(!is_width)
        {
            if ((pattern[y - sy - 1, x - sx] != Get_Stage_Data().Wall ||
                 pattern[y - sy + 1, x - sx] != Get_Stage_Data().Wall ||
                 pattern[dy - sy, dx - sx] == Get_Stage_Data().Wall))
            {
                pattern = null;
            }
        }










        DrawRoom(sx, sy, ex, ey, pattern);
        return true;
    }

    void ExpandRoom(int sx, int sy, int ex, int ey)
    {
        int upDoorX = Random.Range(sx + 1, ex);
        if (GetTile(upDoorX, ey).Tile_Sort == Get_Stage_Data().Wall)
        {
            if (BuildRoom(upDoorX, ey, eDirection.Up) == true)
            {
                SetTile(upDoorX, ey, eTile.DOOR, Sight_Sort.Black);
            }
        }

        int downDoorX = Random.Range(sx + 1, ex);
        if (GetTile(downDoorX, sy).Tile_Sort == Get_Stage_Data().Wall)
        {
            if (BuildRoom(downDoorX, sy, eDirection.Down) == true)
            {
                SetTile(downDoorX, sy, eTile.DOOR, Sight_Sort.Black);
            }
        }

        int leftDoorY = Random.Range(sy + 1, ey);
        if (GetTile(sx, leftDoorY).Tile_Sort == Get_Stage_Data().Wall)
        {
            if (BuildRoom(sx, leftDoorY, eDirection.Left) == true)
            {
                SetTile(sx, leftDoorY, eTile.DOOR, Sight_Sort.Black);
            }
        }

        int rightDoorY = Random.Range(sy + 1, ey);
        if (GetTile(ex, rightDoorY).Tile_Sort == Get_Stage_Data().Wall)
        {
            if (BuildRoom(ex, rightDoorY, eDirection.Right) == true)
            {
                SetTile(ex, rightDoorY, eTile.DOOR, Sight_Sort.Black);
            }
        }
    }

    void DrawRoom(int sx, int sy, int ex, int ey, eTile[,] pattern)
    {
        RoomData_List.Add(new RoomData(sx + 1, sy + 1, ex - 1, ey - 1));


        if(pattern != null)     //맵패턴의 해당지점에 문이 있을경우
        {
            int i = 0;
            int j = 0;

            for (int y = sy; y <= ey; y++)
            {
                for (int x = sx; x <= ex; x++)
                {
                    if (pattern[i, j] == Get_Stage_Data().Wall)
                    {
                        FillWall(x, y);
                    }
                    else
                    {
                        if(GetTile(x, y).Tile_Sort == eTile.NULL)
                        {
                            SetTile(x, y, pattern[i, j], Sight_Sort.Black);
                        }
                    }
                    j++;
                }
                i++;
                j = 0;
            }
        }
        else        //받아온 맵패턴에 문이 없는 경우
        {
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
                    SetTile(x, y, Get_Stage_Data().Nomal, Sight_Sort.Black);
                }
            }              
        }


        ExpandRoom(sx, sy, ex, ey);
    }

    void FillWall(int x, int y)
    {
        if (GetTile(x, y).Tile_Sort == eTile.NULL)
        {
            SetTile(x, y, Get_Stage_Data().Wall, Sight_Sort.Black);
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

    private void Set_Map_Pattern(int Start_Room_num)
    {
        eTile Wall = Get_Stage_Data().Wall;
        eTile Nomal = Get_Stage_Data().Nomal;



    }
    #endregion


    #region Map_Functions
    public void SetTile(int x, int y, eTile Tile_sort, Sight_Sort sight_sort)
    {
        if (MapData[x, y] == null)
        {
            MapData[x, y] = new Tile(x, y, new Vector3(x, y), Tile_sort, sight_sort);
        }
        else
        {
            MapData[x, y].Tile_Sort = Tile_sort;
        }
    }

    public Tile GetTile(int x, int y)
    {
        if (Is_Map_Tile(x, y))       //해당 좌표에 타일이 있는가
        {
            if (MapData[x, y] == null)
                SetTile(x, y, eTile.NULL, Sight_Sort.Black);

            return MapData[x, y];
        }
        else                            //x, y 가 범위 밖이라면 null값을 리턴
            return null;

    }

    public Tile Get_Tile_By_Vector3(Vector3 Position)
    {
        if (Position.x >= 0 && Position.y <= MapSize &&
            Position.x >= 0 && Position.y <= MapSize)       //해당 좌표에 타일이 있는가
        {
            if (MapData[(int)Position.x, (int)Position.y] == null)
                SetTile((int)Position.x, (int)Position.y, eTile.NULL, Sight_Sort.Black);

            return MapData[(int)Position.x, (int)Position.y];
        }
        else                            //x, y 가 범위 밖이라면 null값을 리턴
            return null;

    }

    public bool Is_Map_Tile(int x, int y)
    {
        if (x >= 0 && x <= MapSize && y >= 0 && y <= MapSize)       //해당 좌표에 타일이 있는가
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int Get_Array_Count(int x, int y)
    {
        return ((x * 15 + y));
    }

    public Stage_Data Get_Stage_Data()
    {
        return Stage_Data.stage_Data_List[Current_Stage - 1];
    }

    public bool Is_Move_Able_Tile(eTile Sort)
    {
        bool temp = true;

        switch (Sort)
        {
            case eTile.NOMAL:
            case eTile.DOOR:
                {
                    temp = true;
                    break;
                }
            case eTile.WALL:
            case eTile.NULL:
                {
                    temp = false;
                    break;
                }

        }
        return temp;
    }

    public Texture2D Get_Tile_From_Atlas(int Sprite_Num)
    {
        return Tile_Textures[Sprite_Num];
    }

    public Tile_Obj Get_TileObj(int x, int y)
    {
        return Tiles[x, y];
    }

    public Tile Get_PTile()
    {
        return Get_Tile_By_Vector3(PlayerManager.GetPosition());
    }


    #endregion

    #region Target

    public bool Set_Map_Target(Tile tile)
    {
        return MapTarget.Is_In_Target(tile);

    }

    #endregion

    #region HighLight

    public bool Get_HightLight_Active()
    {
        return MapHightLight.HL_Active;
    }

    public bool Is_HighLight_Tile(Tile tile)
    {
        return MapHightLight.Is_HighLight_Tile(tile);
    }

    #endregion

    public void Ready_To_Update_Sight()
    {
        Vector3 Player_Position = PlayerManager.GetPosition();

        for (int i = (int)Player_Position.x - VisualRange; i <= (int)Player_Position.x + VisualRange; i++)
        {
            for (int j = (int)Player_Position.y - VisualRange; j <= (int)Player_Position.y + VisualRange; j++)
            {
                if (Is_Map_Tile(i, j))
                {
                    if (GetTile(i, j).Sight_Sort == Sight_Sort.White)
                    {
                        MapData[i, j].Sight_Sort = Sight_Sort.Deep_Gray;
                    }
                }
            }

        }
    }

    public void Update_Sight()
    {
        Vector3 Player_position = PlayerManager.GetPosition();
        MapData[(int)Player_position.x, (int)Player_position.y].Sight_Sort = Sight_Sort.White;

        foreach (int i in VisibleOctants)                       //Shadow Cast호출
            ShadowCast.ScanOctant(VisualRange, Player_position, Sight_Sort.White, MapData, 1, i, 1.0, 0.0);

        Update_Tiles();
    }

    public void Update_Tiles_In_Move()
    {
        Vector3 Player_position = PlayerManager.GetPosition();

        int x = (int)Player_position.x - 7;
        int y = (int)Player_position.y - 6;


        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (Is_Map_Tile(x, y))       //해당 좌표에 타일이 있는가
                {
                    if (MapData[x, y] == null)
                        SetTile(x, y, eTile.NULL, Sight_Sort.Black);


                    Tiles[i, j].Tile = GetTile(x, y);

                    if (Is_Move_Able_Tile(MapData[x, y].Tile_Sort))
                    {
                        Tiles[i, j].transform.position = new Vector3(x, y);
                    }
                    else if (!Is_Move_Able_Tile(MapData[x, y].Tile_Sort))
                    {
                        Tiles[i, j].transform.position = new Vector3(x, y, -0.5f);
                    }

                    //Tiles[i, j].Tile_Data = MapData[x, y];
                    //Tile_Objects[x, y] =  (int)MapData[x, y].Tile_Sort 
                }
                y++;
            }
            y = (int)Player_position.y - 6;
            x++;
        }
    }

    public void Update_Tiles()
    {
        Vector3 Camera_Position = CameraManager.Position - new Vector3(0, -3);

        int x = (int)Camera_Position.x - 7;
        int y = (int)Camera_Position.y - 6;


        for (int i = 0; i < 15; i++)
        {
            for(int j = 0; j < 15; j++)
            {
                if(Is_Map_Tile(x, y))       //해당 좌표에 타일이 있는가
                {
                    if (MapData[x, y] == null)
                        SetTile(x, y, eTile.NULL, Sight_Sort.Black);


                    Tiles[i, j].Tile = GetTile(x, y);

                    if(Is_Move_Able_Tile(MapData[x, y].Tile_Sort))
                    {
                        Tiles[i, j].transform.position = new Vector3(x, y);
                    }
                    else if(!Is_Move_Able_Tile(MapData[x, y].Tile_Sort))
                    {
                        Tiles[i, j].transform.position = new Vector3(x, y, -0.5f);
                    }

                    //Tiles[i, j].Tile_Data = MapData[x, y];
                    //Tile_Objects[x, y] =  (int)MapData[x, y].Tile_Sort 
                }
                y++;
            }
            y = (int)Camera_Position.y - 6;
            x++;
        }

    }


    public Tile Tile_Touch(Vector3 touch_position)
    {
        if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GameObject Touched_Object = CameraManager.Get_GameObject_By_Lay(touch_position);

            if (Touched_Object != null) //터치한 지점에 오브젝트가 있다면
            {
                int x = (int)Touched_Object.transform.position.x;
                int y = (int)Touched_Object.transform.position.y;

                Tile Touched_Tile = GetTile(x, y);

                if (Touched_Tile != null)   //해당 오브젝트가 타일일 경우
                {
                    return Touched_Tile;

                }
            }
        }


        return null;
    }


    
    public List<Tile> A_Star_PathFinding(Tile Start_Position, Tile Dex_Position)
    {
        return A_Star.A_star(Start_Position, Dex_Position, MapData);
    }

    public void HL()
    {
        MapHightLight.Set_Activate(Get_PTile(), 3);

    }

}
