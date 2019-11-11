using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[System.Serializable]
public class Tile
{
    public int x, y;
    public Vector3 Tile_Position;
    public Tile_Sort Tile_Sort;
    public Sight_Sort Sight_Sort;
    public BaseActor Tile_Actor;


    public Tile(int X, int Y, Vector3 tile_position, Tile_Sort Tile_sort, Sight_Sort sight_sort, BaseActor tile_actor)
    {
        this.x = X;
        this.y = Y;
        this.Tile_Position = tile_position;
        this.Tile_Sort = Tile_sort;
        this.Sight_Sort = sight_sort;
        this.Tile_Actor = tile_actor;
    }
}

[System.Serializable]
public class Tile_Sort
{
    public eTileBase TileBase;
    public eTileObject TileObject;

    public Tile_Sort(eTileBase tilebase, eTileObject tileobject)
    {
        this.TileBase = tilebase;
        this.TileObject = tileobject;
    }

}

[System.Serializable]
public class RoomData
{
    public int Sx, Sy, Ex, Ey;
    public List<Tile> None_TileObj_List;
    public RoomData(int sx, int sy, int ex, int ey, List<Tile> _list)
    {
        this.Sx = sx;
        this.Sy = sy;
        this.Ex = ex;
        this.Ey = ey;
        this.None_TileObj_List = _list;
    }
}

[System.Serializable]
public enum eTileBase
{
    NULL = 0,
    NOMAL,
    STONE,
    MOSS_OF_STONE,
    MMOSS_OF_STONE,
    COUNT
}

[System.Serializable]
public enum eTileObject
{
    NULL = 0,
    WALL,
    DOOR,

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
    [SerializeField] private Tile_Event Tile_Event;
    private A_Star A_Star;
    private ShadowCast ShadowCast;
    private MapPattern MapPattern;

    [Header("Object")]
    [SerializeField] private GameObject Tile_Objs;
    [SerializeField] private SpriteAtlas TileBase_SpriteAtlas;
    [SerializeField] private List<Texture2D> TileBase_Textures;
    [SerializeField] private List<Material> TileObject_Textures;

    [Header("ScriptableObject")]
    [SerializeField] private Stage_Data_Object Stage_Data;

    //public Event.Color_Set_Event_Handler HL_Event;


    private Tile[,] MapData { get; set; }
    private int Current_Stage { get; set; }
    public int MapSize { get; set; }
    private int VisualRange { get; set; }
    private int Pooling_Count { get; set; }

    private int roomMin;
    private int roomMax;

    private List<int> VisibleOctants;   //8방위 List
    private Tile_Obj[,] Tiles;              //오브젝트 풀링 Tile들
    private List<RoomData> RoomData_List;       //RoomData 저장 List
    private List<GameObject> Map_Gimmick_List;


    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        PlayerManager = GameManager.PlayerManager;  //게임 매니저로 부터 Manager를 받아온다
        CameraManager = GameManager.CameraManager;

        ShadowCast = new ShadowCast(this);  //전장의 안개
        A_Star = new A_Star(this);       //A*알고리즘
        MapPattern = new MapPattern(this);   //맵 패턴 함수
        MapHightLight.Set_Map(this);
        Tile_Event.Set_Map(this);

        VisibleOctants = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        Map_Gimmick_List = new List<GameObject>();
        Pooling_Count = 15;
        Tiles = new Tile_Obj[Pooling_Count, Pooling_Count];                                     
        MapSize = 64;
        VisualRange = 5;
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

        for (int i = 0; i < Pooling_Count; i++)                //풀링 Object 할당
        {
            for (int j = 0; j < Pooling_Count; j++)
            {
                Tiles[i, j] = Tile_Objs.transform.GetChild(Get_Array_Count(i, j)).GetComponent<Tile_Obj>();
                Tiles[i, j].Set_Tile(this, new Array_Index(i, j));
            }
            
        }

        //while(GetTile(6, 6).Tile_Sort.TileBase == eTileBase.NULL ||
        //    GetTile(57, 57).Tile_Sort.TileBase == eTileBase.NULL ||
        //    GetTile(6, 6).Tile_Sort.TileObject == eTileObject.WALL ||
        //    GetTile(57, 57).Tile_Sort.TileObject == eTileObject.WALL)
        //{
        //    MapData = new Tile[MapSize + 1, MapSize + 1];


        //    BuildMap();
        //}



        //Update_TT();
        Update_Sight();
        Update_Tiles();                   //맵 정보를 기반으로 Tile 업데이트
        MapTarget.Set_Map(this);
        //link();
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
        //플레이어가 시작할 방을 산출한다.

        Tile Player_Start_Tile = RoomData_List[StartRoom_Num].None_TileObj_List
            [Random.Range(0, RoomData_List[StartRoom_Num].None_TileObj_List.Count)];
        //방에서 플레이어의 시작위치를 구한다.

        RoomData_List[StartRoom_Num].None_TileObj_List.Remove(Player_Start_Tile);

       
        PlayerManager.SetPosition(new Vector3(Player_Start_Tile.x, Player_Start_Tile.y));

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

        Tile_Sort[,] pattern =
             MapPattern.Get_Room_Patterns(new Room_Size(width + 1, height + 1));

        if(is_width)        //가로        
        {
            if ((pattern[y - sy , x - sx - 1].TileObject != Get_Stage_Data().Wall ||
                pattern[y - sy , x - sx + 1].TileObject != Get_Stage_Data().Wall ||
                pattern[dy - sy, dx - sx].TileObject == Get_Stage_Data().Wall))
            {//이차원배열의 상하 반전 문제로 제대로 작동안함

                pattern = null;
            }
        }
        else if(!is_width)      //세로
        {
            if ((pattern[y - sy - 1, x - sx].TileObject != Get_Stage_Data().Wall ||
                 pattern[y - sy + 1, x - sx].TileObject != Get_Stage_Data().Wall ||
                 pattern[dy - sy, dx - sx].TileObject == Get_Stage_Data().Wall))
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
        if (GetTile(upDoorX, ey).Tile_Sort.TileObject == Get_Stage_Data().Wall)
        {
            if (BuildRoom(upDoorX, ey, eDirection.Up) == true)
            {
                SetTile(upDoorX, ey, 
                    new Tile_Sort(Get_Stage_Data().Nomal ,eTileObject.DOOR));
            }
        }

        int downDoorX = Random.Range(sx + 1, ex);
        if (GetTile(downDoorX, sy).Tile_Sort.TileObject == Get_Stage_Data().Wall)
        {
            if (BuildRoom(downDoorX, sy, eDirection.Down) == true)
            {
                SetTile(downDoorX, sy, 
                    new Tile_Sort(Get_Stage_Data().Nomal, eTileObject.DOOR));
            }
        }

        int leftDoorY = Random.Range(sy + 1, ey);
        if (GetTile(sx, leftDoorY).Tile_Sort.TileObject == Get_Stage_Data().Wall)
        {
            if (BuildRoom(sx, leftDoorY, eDirection.Left) == true)
            {
                SetTile(sx, leftDoorY, 
                    new Tile_Sort(Get_Stage_Data().Nomal, eTileObject.DOOR));
            }
        }

        int rightDoorY = Random.Range(sy + 1, ey);
        if (GetTile(ex, rightDoorY).Tile_Sort.TileObject == Get_Stage_Data().Wall)
        {
            if (BuildRoom(ex, rightDoorY, eDirection.Right) == true)
            {
                SetTile(ex, rightDoorY,
                    new Tile_Sort(Get_Stage_Data().Nomal, eTileObject.DOOR));
            }
        }
    }

    void DrawRoom(int sx, int sy, int ex, int ey, Tile_Sort[,] pattern)
    {
        RoomData_List.Add(new RoomData(sx + 1, sy + 1, ex - 1, ey - 1, new List<Tile>()));
        int List_Num = RoomData_List.Count - 1;

        if (pattern != null)     //맵패턴의 해당지점에 문이 있을경우
        {
            int i = 0;
            int j = 0;

            for (int y = ey; y >= sy; y--)
            {
                for (int x = sx; x <= ex; x++)
                {
                    if (pattern[i, j].TileObject == Get_Stage_Data().Wall)
                    {
                        FillWall(x, y);
                    }
                    else
                    {
                        if(GetTile(x, y).Tile_Sort.TileObject == eTileObject.NULL)
                        {
                            SetTile(x, y, pattern[i, j]);

                            if(GetTile(x, y).Tile_Sort.TileBase != eTileBase.NULL)
                            {
                                RoomData_List[List_Num].None_TileObj_List.Add(GetTile(x, y));
                                //Tile_Obj가 NULL인 타일들을 List에 넣어준다
                            }

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
                    SetTile(x, y,
                        new Tile_Sort(Get_Stage_Data().Nomal, eTileObject.NULL));

                    RoomData_List[List_Num].None_TileObj_List.Add(GetTile(x, y));
                    //Tile_Obj가 NULL인 타일들을 List에 넣어준다
                }
            }              
        }


        ExpandRoom(sx, sy, ex, ey);
    }

    void FillWall(int x, int y)
    {
        if (GetTile(x, y).Tile_Sort.TileObject == eTileObject.NULL)
        {
            SetTile(x, y,
                new Tile_Sort(Get_Stage_Data().Nomal, Get_Stage_Data().Wall));
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
                if (GetTile(x, y).Tile_Sort.TileBase != eTileBase.NULL)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void Set_Map_Pattern(int Start_Room_num)
    {
        eTileObject Wall = Get_Stage_Data().Wall;
        eTileBase Nomal = Get_Stage_Data().Nomal;



    }
    #endregion


    #region Map_Functions
    public void SetTile(int x, int y, Tile_Sort Tile_sort)
    {
        if (MapData[x, y] == null)
        {
            MapData[x, y] = 
                new Tile(x, y, new Vector3(x, y), Tile_sort, Sight_Sort.Black, null);
        }
        else
        {
            MapData[x, y].Tile_Sort = Tile_sort;
        }
    }

    public void SetTile(int x, int y, Sight_Sort sight_sort)
    {
        MapData[x, y].Sight_Sort = sight_sort;
    }

    public void SetTile(int x, int y, BaseActor tile_actor)
    {
        MapData[x, y].Tile_Actor = tile_actor;
    }

    public Tile GetTile(int x, int y)
    {
        if (Is_Map_Tile(x, y))       //해당 좌표에 타일이 있는가
        {
            if (MapData[x, y] == null)
                SetTile(x, y, new Tile_Sort(eTileBase.NULL, eTileObject.NULL));

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
                SetTile((int)Position.x, (int)Position.y,
                    new Tile_Sort(eTileBase.NULL, eTileObject.NULL));

            return MapData[(int)Position.x, (int)Position.y];
        }
        else                            //x, y 가 범위 밖이라면 null값을 리턴
            return null;
    }

    public Sight_Sort Get_Sight_Sort(int x, int y)
    {
        return MapData[x, y].Sight_Sort;
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
        return ((x * Pooling_Count + y));
    }

    public Stage_Data Get_Stage_Data()
    {
        return Stage_Data.stage_Data_List[Current_Stage - 1];
    }

    public bool Is_Move_Able_Tile(Tile_Sort Sort)
    {
        return (Sort.TileObject == eTileObject.NULL || Sort.TileObject == eTileObject.DOOR);
    }


    public Texture2D Get_TileBase_From_List(int Sprite_Num)
    {
        return TileBase_Textures[Sprite_Num];
    }

    public Material Get_TileObject_From_List(int Sprite_Num)
    {
        return TileObject_Textures[Sprite_Num];
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

    public bool In_Map_Target(Tile tile)
    {
        return MapTarget.Is_In_Target(tile);

    }

    public void Set_Map_Taget(Tile tile)
    {
        MapTarget.Target_Tile = tile;
    }

    public Tile Get_Map_target()
    {
        return MapTarget.Target_Tile;
    }

    public Tile_Obj Get_TileObj_By_Tile(Tile tile)
    {
        for(int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (tile == Tiles[i, j].Tile)
                {
                    return Tiles[i, j];
                }
            }
        }

        return null;
    }

    #endregion

    #region HighLight

    public bool Get_Gimmick_Active()
    {
        return (Map_Gimmick_List.Count != 0);
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

    public void Update_Tiles_By_Player()
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
                        SetTile(x, y, new Tile_Sort(eTileBase.NULL, eTileObject.NULL));


                    Tiles[i, j].Tile = GetTile(x, y);


                    //Tiles[i, j].Tile_Data = MapData[x, y];
                    //Tile_Objects[x, y] =  (int)MapData[x, y].Tile_Sort 
                }
                y++;
            }
            y = (int)Player_position.y - 6;
            x++;
        }
    }


    public void Update_TT()
    {
        for (int i = 0; i < 64; i++)
        {
            for (int j = 0; j < 64; j++)
            {
                //해당 좌표에 타일이 있는가

                if (MapData[i, j] == null)
                    SetTile(i, j, new Tile_Sort(eTileBase.NULL, eTileObject.NULL));

                MapData[i, j].Sight_Sort = Sight_Sort.White;

                Tiles[i, j].Tile = GetTile(i, j);



                if (Is_Move_Able_Tile(MapData[i, j].Tile_Sort))
                {
                    Tiles[i, j].transform.position = new Vector3(i, j);
                }
                else if (!Is_Move_Able_Tile(MapData[i, j].Tile_Sort))
                {
                    Tiles[i, j].transform.position = new Vector3(i, j, -0.5f);
                }

                //Tiles[i, j].Tile_Data = MapData[x, y];
                //Tile_Objects[x, y] =  (int)MapData[x, y].Tile_Sort 

            }

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
                        SetTile(x, y, new Tile_Sort(eTileBase.NULL, eTileObject.NULL));


                    Tiles[i, j].Tile = GetTile(x, y);


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

    public void HL_Active()
    {
        StartCoroutine(MapHightLight.Set_Activate(Get_PTile(), 3));
    }

    public bool Is_HL_Active()
    {
        return MapHightLight.HL_Active;
    }

    public bool Is_Block_Object(Tile_Sort tile_Sort)
    {
        bool temp = false;

        switch(tile_Sort.TileObject)
        {
            case eTileObject.WALL:
            case eTileObject.DOOR:
            {

                    temp = true;
                    break;
            }
        }
        return temp;
    }

    public List<GameObject> Get_Gimmick_List()
    {
        return Map_Gimmick_List;
    }

    private void link()
    {

        List<Tile> tiles = A_Star.A_star(GetTile(6, 6),
                                         GetTile(57, 57),
                                         MapData);
        foreach (Tile i in tiles)
        {
            Tiles[i.x, i.y].get_rend().material.color = Color.red;
        }


    }

    public void Set_Tile(Tile_Obj tile_obj, Tile_Sort tile_sort)
    {
        SetTile(tile_obj.Tile.x, tile_obj.Tile.y, tile_sort);
        //tile_obj.tile_Sort = tile_sort;
        StartCoroutine(Build_Anim(tile_obj.gameObject));
        Ready_To_Update_Sight();
        Update_Sight();

        //Set_Map_Taget(Get_Map_target());
    }


    private IEnumerator Build_Anim(GameObject obj)
    {
        float size = 0.6f;
        obj.transform.localScale = new Vector3(size, size, size);

        while (size < 1f)
        {
            size += 0.05f;
            obj.transform.localScale = new Vector3(size, size, size);
            yield return null;
        }

        yield return null;

    }

    #region TIle_Event

    public IEnumerator Step_Beggin_Event(BaseActor actor,Tile tile)
    {
        yield return Tile_Event.Step_Beggin_Event_By_Obj(actor, tile);
    }

    public IEnumerator Step_On_Event(BaseActor actor, Tile tile)
    {
        tile.Tile_Actor = actor;
        yield return Tile_Event.Step_on_Event_By_Obj(actor, tile);
    }

    public IEnumerator Step_End_Event(BaseActor actor, Tile tile)
    {
        tile.Tile_Actor = null;
        yield return Tile_Event.Step_End_Event_By_Obj(actor ,tile);
    }
    #endregion
}
