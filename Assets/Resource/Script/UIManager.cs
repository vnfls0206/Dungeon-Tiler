﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private List<IUI> Active_UI_List;


    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        Active_UI_List = new List<IUI>();

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

    public bool Is_UI_Active()
    {
        return Active_UI_List.Count != 0;   //하나라도 활성화 되어있는 UI가 있다면 True를 반환
    }

    #region UI_Interface
    public interface IUI
    {



    }
    #endregion
}
