using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IManager
{
    [SerializeField] private GameManager GameManager;
    private MapManager MapManager;


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

    public void Set_Manager(GameData gamedata)  //Awake에 해당한다. 시작시 호출
    {
        MapManager = GameManager.MapManager;

        if (gamedata != null)    //게임 데이터가 있을때 Load 해준다
        {


        }
        else                    //게임 데이터가 없을때 시작
        {

        }
    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {


    }

    public Vector3 GetPlayerPosition()
    {
        return Player_Position;
    }

    public void SetPlayerPosition(Vector3 Position)
    {
        Player_Position = Position;
    }


    public void Move_Player(eDirection Move_Driection)
    {
        switch(Move_Driection)
        {
            case eDirection.Up:
                SetPlayerPosition(new Vector3(GetPlayerPosition().x, GetPlayerPosition().y + 1));
                break;

            case eDirection.Down:
                SetPlayerPosition(new Vector3(GetPlayerPosition().x, GetPlayerPosition().y - 1));
                break;

            case eDirection.Left:
                SetPlayerPosition(new Vector3(GetPlayerPosition().x - 1, GetPlayerPosition().y));
                break;

            case eDirection.Right:
                SetPlayerPosition(new Vector3(GetPlayerPosition().x + 1, GetPlayerPosition().y));
                break;
        }

        MapManager.Update_Tiles();

    }

}
