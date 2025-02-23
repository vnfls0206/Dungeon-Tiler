﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseActor, IManager
{
    private GameManager GameManager;
    private MapManager MapManager;
    private CameraManager CameraManager;

    private SpriteRenderer SpriteRenderer;

    private float Player_Move_Speed;


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

        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        Player_Move_Speed = 6f;

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
        Player_Position = Position + new Vector3(0, 0, -0.1f);
        CameraManager.Set_Camera_Target(this.transform);
    }

    public IEnumerator Move_To_Dex(Tile Dex_position)
    {
        CameraManager.Set_Camera_Target(this.transform);
        MapManager.Update_Sight();              //다른 시점의 장소에서 이동할때 화면 갱신

        Tile StartPosition = MapManager.Get_Tile_By_Vector3(Player_Position);
        List<Tile> Path =
            MapManager.A_Star_PathFinding(
                StartPosition,                                      //현재 플레이어 위치
                Dex_position);                                       //도착위치


        foreach (Tile i in Path)
        {
            Tile pre_tile = MapManager.Get_PTile();

            // 이동 전
            MapManager.Ready_To_Update_Sight();      //Player Position 변경전에 호출한다.
            yield return MapManager.Step_Beggin_Event(this ,i);
            

            // 이동
            yield return MapManager.Step_On_Event(this, i);
            yield return Move_Player(i);
            MapManager.Update_Sight();              //Player Position 변경후에 호출한다.

            // 이동 후
            yield return MapManager.Step_End_Event(this, pre_tile);
        }

        yield return null;
    }

    private IEnumerator Move_Player(Tile temp)
    {

        if (temp.x < Player_Position.x)
            SpriteRenderer.flipX = true;
        else if(temp.x > Player_Position.x)
            SpriteRenderer.flipX = false;

        Vector3 curvePoint;

        float t = 0f;

        curvePoint = new Vector3((Player_Position.x + temp.x) / 2f,
        (Player_Position.y + temp.y) / 2f, -1f);


        Vector3 Starting_Postionm = Player_Position;

        while (!(Vector3.Distance(Player_Position, temp.Tile_Position) <= 0.15f))
        {
            SetPosition(Bezier(Starting_Postionm, curvePoint, temp.Tile_Position, t));

            t = Mathf.Min(1, t + Time.deltaTime * Player_Move_Speed);
            yield return null;

        }
        SetPosition(temp.Tile_Position);
    }

    Vector3 Bezier(Vector3 a, Vector3 b, Vector3 c, float t)            //베지어 곡선
    {
        var omt = 1f - t;
        return a * omt * omt + 2f * b * omt * t + c * t * t;
    }

    public void Set_Camera_To_Player()
    {
        CameraManager.Set_Camera_Target(this.transform);
        MapManager.Update_Sight();
    }

}
