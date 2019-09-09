using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, IManager
{
    private GameManager GameManager;

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;

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
