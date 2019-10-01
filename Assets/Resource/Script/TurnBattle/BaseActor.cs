using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseActor : MonoBehaviour
{

    public string name;

    
    int State_maxhp() { return 0; }
    int State_currenthp() { return 0; }
    
    public bool Is_player() { return true; }
    public bool Is_enemy() { return !Is_player(); }
    //public bool Attack()
    //{
    //    if( Hit)
    //    Debug.Log("dd");
    //    return true;
    //}

    //public bool Hit(BaseActor attacker, BaseActor defender)
    //{
    //    float accumulateRoll = Random.Range(0.0f, 4.0f);
    //}

    public int attackSkill(BaseActor target)
    {
        return 0;
    }

    public int defenseSkill(BaseActor enemy)
    {
        return 0;
    }
    // public abstract void GetName();
}

public interface IBaseActor
{

    int State_maxhp();
    int State_currenthp();

    //bool Is_player();
    //bool Is_enemy();
    //int attackSkill(BaseActor target);
    //int defenseSkill(BaseActor enemy);
}