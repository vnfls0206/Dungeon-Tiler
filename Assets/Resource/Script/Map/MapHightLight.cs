using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHightLight : MonoBehaviour
{
    private MapManager MapManager;
    private Renderer rend;
    private Texture2D tex;

    private List<Tile> Set_Able_TIle_LIst;
    private List<Tile> Gert_Able_Tile_List;

    private int Scale;
    private float TF_Scale;

    private float Color_a;


    private bool hl_active;
    public bool HL_Active
    {
        get
        {
            return hl_active;
        }
        set
        {
            hl_active = value;
            if(value)
            {
                MapManager.Get_Gimmick_List().Add(this.gameObject);
            }
            else
            {
                MapManager.Get_Gimmick_List().Remove(this.gameObject);
            }
        }
    }
    

    public void Set_Map(MapManager mapmanager)
    {
        this.MapManager = mapmanager;
        Set_Able_TIle_LIst = new List<Tile>();
        Gert_Able_Tile_List = new List<Tile>();

        rend = GetComponent<Renderer>();        //할당
        tex = new Texture2D(0, 0);
        rend.material.shader = Shader.Find("Unlit/Transparent");        //Shader를 투명으로 바꿔준다.(그래야 안개 구연이 제대로됨)
        //rend.material.shader = Shader.Find("Particles/Alpha Blended");
        TF_Scale = 0f;

        hl_active = false;  //활성화의 초기 값 부여
        EventManager.TF_Event += HL_TF_Event;
    }

    public void Update_Map()
    {

    }

    public IEnumerator Set_Activate(Tile tile, int size)
    {
        Scale = size * 2 + 3;
        bool Active_Set = !this.gameObject.activeSelf;
        this.gameObject.SetActive(Active_Set);
        HL_Active = Active_Set;
        this.transform.position = new Vector3(tile.x, tile.y, -0.05f);

        if(Active_Set)
        {
            //EventManager.TF_Event += HL_TF_Event;
            

            if (tex.texelSize.x != size)
            {
                tex = new Texture2D(Scale, Scale);
                rend.material.mainTexture = tex;
                //transform.localScale = new Vector3(Scale, Scale);
                tex.filterMode = FilterMode.Point;
            }

            Light_Cast(size, new Array_Index(size, size), tile, true);

            Set_Able_TIle_LIst.Remove(tile);

            //if(!Set_Able_TIle_LIst.Contains(MapManager.Get_Map_target()))
            //{
            //    MapManager.Set_Map_Taget(Set_Able_TIle_LIst[Random.Range(0, Set_Able_TIle_LIst.Count)]);
            //}

            int x = -size - 1;
            int y = -size - 1;

            for (int i = 0; i < Scale; i++)
            {
                for (int j = 0; j < Scale; j++)
                {
                    if (Set_Able_TIle_LIst.Contains(MapManager.GetTile(tile.x + x, tile.y + y)))
                    {
                        tex.SetPixel(i, j, new Color(0f, 1f, 0f, 0.6f));
                    }
                    else
                    {
                        tex.SetPixel(i, j, Color.clear);
                    }
                    y++;
                }
                y = -size - 1;
                x++;


            }

            tex.Apply(false);
        }
        else
        {
            //EventManager.TF_Event -= HL_TF_Event;
            Set_Able_TIle_LIst.Clear();
        }
        yield return null;

    }

    private void Light_Cast(int move, Array_Index Index, Tile tile, bool isFirst)      //tile은 현재 선택된 타일, isFirst는 루프 횟수가 처음인가 판별
    {
        int tileX = tile.x; // 현재 타일의 가로축 인덱스
        int tileY = tile.y; // 현재 타일의 세로축 인덱스

        if (!Set_Able_TIle_LIst.Contains(tile) && isFirst == false)
        {
            Set_Able_TIle_LIst.Add(tile);
            //if(move)
            //tex.SetPixel(Index.x, Index.y, new Color(1f, 0f, 0f, 0.5f));
        }

        isFirst = false;

        if (move <= 0)      //move가 0이되면 탈출
            return;

        Tile upTile = MapManager.GetTile(tileX, tileY + 1);
        Tile downtile = MapManager.GetTile(tileX, tileY - 1);
        Tile leftTile = MapManager.GetTile(tileX - 1, tileY);
        Tile rightTile = MapManager.GetTile(tileX + 1, tileY);


        if (!MapManager.Is_Block_Object(upTile.Tile_Sort) && 
            upTile.Sight_Sort == Sight_Sort.White)
            Light_Cast(move - 1, new Array_Index(Index.x, Index.y + 1), upTile, isFirst);

        if (!MapManager.Is_Block_Object(downtile.Tile_Sort) &&
            downtile.Sight_Sort == Sight_Sort.White)
            Light_Cast(move - 1, new Array_Index(Index.x, Index.y - 1), downtile, isFirst);

        if (!MapManager.Is_Block_Object(leftTile.Tile_Sort) &&
            leftTile.Sight_Sort == Sight_Sort.White)
            Light_Cast(move - 1, new Array_Index(Index.x - 1, Index.y), leftTile, isFirst);

        if (!MapManager.Is_Block_Object(rightTile.Tile_Sort) &&
            rightTile.Sight_Sort == Sight_Sort.White)
            Light_Cast(move - 1, new Array_Index(Index.x + 1, Index.y),  rightTile, isFirst);
    }

    private void HL_TF_Event(bool TF)
    {
        if(TF)
        {
            TF_Scale += Time.deltaTime * 2;
        }
        else if(!TF)
        {
            TF_Scale -= Time.deltaTime * 2;
        }

        if(HL_Active)
        {
            this.transform.localScale = new Vector3(Scale + TF_Scale, Scale + TF_Scale, 1);
        }
    }

    public bool Is_HighLight_Tile(Tile tile)
    {
        return Set_Able_TIle_LIst.Contains(tile);
    }

}
