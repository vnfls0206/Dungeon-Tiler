using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour, IManager
{
    private GameManager GameManager;

    public static Event.True_False_Event_Handler TF_Event = null;

    private bool TF;
    private float TF_Timer;

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;

        TF = false;      //초기값은 false;
        TF_Timer = 0f;

    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {
        Update_TrueFalse_Event();
    }

    private void Update_TrueFalse_Event()
    {
        if (TF_Event != null)
        {
            TF_Timer -= Time.deltaTime;
            if (TF_Timer <= 0)
            {
                TF_Timer = 0.3f;
                TF = !TF;
            }
            TF_Event(TF);
        }
    }
}
