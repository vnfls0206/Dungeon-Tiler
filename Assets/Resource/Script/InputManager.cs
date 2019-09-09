using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private PlayerManager PlayerManager;


    Dictionary<KeyCode, Action> First_key_Check_Dictionary;         //입력키와 호출되는 함수들을 저장하자
    Dictionary<KeyCode, Action> Continuous_key_Check_Dictionary;     //(나중에 설정으로 키가 바뀔 수 도 있으니)

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        PlayerManager = GameManager.PlayerManager;  //게임 매니저로 부터 Manager를 받아온다


        First_key_Check_Dictionary = new Dictionary<KeyCode, Action>     //지속적인 입력을 감지하는 KeyCode들
        {
            { KeyCode.UpArrow, () => PlayerManager.Move_Player(eDirection.Up) },
            { KeyCode.LeftArrow, () => PlayerManager.Move_Player(eDirection.Left) },
            { KeyCode.DownArrow, () => PlayerManager.Move_Player(eDirection.Down) },
            { KeyCode.RightArrow, () => PlayerManager.Move_Player(eDirection.Right) }
        };      //나중에는 데이터가 있으면 키설정을 불러오고 없으면 이대로 초기화하도록 수정하자

    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {

        if (Input.anyKeyDown)       //첫번째 입력만을 감지
        {
            foreach (KeyValuePair<KeyCode, Action> dic in First_key_Check_Dictionary)     //First_key_Check_Dictionary에 등록된 KeyCode가 입력되면
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    dic.Value();            //해당되는 함수를 호출한다.
                }
            }
        }

        //if (Input.anyKey)   //지속적인 입력을 감지
        //{
        //    foreach (var dic in Continuous_key_Check_Dictionary)     //Continuous_key_Check_Dictionary에 등록된 KeyCode가 입력되면
        //    {
        //        if (Input.GetKey(dic.Key))
        //        {
        //            dic.Value();        //해당되는 함수를 호출한다.
        //        }

        //    }
        //}
    }





}
