using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private MapManager MapManager;
    private CameraManager CameraManager;


    private Vector3 player_position;
    private Vector3 Player_Position
    {
        get
        {
            return player_position;
        }
        set
        {
            player_position = value;
            this.transform.position = player_position;
        }
    }

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        MapManager = GameManager.MapManager;
        CameraManager = GameManager.CameraManager;

        if (GameManager.Get_GameData() != null)    //게임 데이터가 있을때 Load 해준다
        {


        }
        else                    //게임 데이터가 없을때 시작
        {

        }
    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {

    }

    public Vector3 GetPosition()
    {
        return Player_Position;
    }

    public void SetPosition(Vector3 Position)
    {
        Player_Position = Position;
        CameraManager.Set_Camera_Target(this.transform);
    }

    public IEnumerator Move_To_Dex(TIle_Data Dex_position)
    {
        CameraManager.Set_Camera_Target(this.transform);
        MapManager.Update_Sight();

        TIle_Data StartPosition = MapManager.Get_Tile_By_Vector3(Player_Position);
        List<TIle_Data> Path =
            MapManager.A_Star_PathFinding(
                StartPosition,                                      //현재 플레이어 위치
                Dex_position);                                       //도착위치


        foreach (TIle_Data i in Path)
        {
            MapManager.Ready_To_Update_Sight();      //Player Position 변경전에 호출한다.
            yield return Move_Player(i);
            MapManager.Update_Sight();              //Player Position 변경후에 호출한다.
        }

        yield return null;
    }

    private IEnumerator Move_Player(TIle_Data temp)
    {

        Vector3 curvePoint;
        float speed = 4;

        float t = 0f;

        curvePoint = new Vector3((Player_Position.x + temp.Tile_Position.x) / 2f,
        (Player_Position.y + temp.Tile_Position.y) / 2f, -0.7f);


        Vector3 Starting_Postionm = Player_Position;

        while (!(Vector3.Distance(Player_Position, temp.Tile_Position) <= 0.05f))
        {
            SetPosition(Bezier(Starting_Postionm, curvePoint, temp.Tile_Position, t));

            t = Mathf.Min(1, t + Time.deltaTime * speed);
            yield return null;

        }
        SetPosition(temp.Tile_Position);
    }

    Vector3 Bezier(Vector3 a, Vector3 b, Vector3 c, float t)            //베지어 곡선
    {
        var omt = 1f - t;
        return a * omt * omt + 2f * b * omt * t + c * t * t;
    }

}
