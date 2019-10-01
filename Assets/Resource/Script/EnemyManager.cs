using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private MapManager MapManager;
    private CameraManager CameraManager;
    [Header("TestPosition")]
    [SerializeField]
    private Vector3 enemy_position;
    private Vector3 Enemy_Position
    {
        get
        {
            return enemy_position;
        }
        set
        {
            enemy_position = value;
            this.transform.position = enemy_position;
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
}
