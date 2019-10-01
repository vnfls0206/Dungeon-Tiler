using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BasePlayer : BaseActor
{
    Stat stat;
    
    public int max_HP;
    public int current_HP;

    public int max_MP;
    public int current_MP;

    int hit_points_regeneration;
    int magic_points_regeneration;

    int max_level;
    int experience;
    int total_experience;
    int gold;
    //int equip[4]; //장비 구현은 무엇으로?
    //int last_unequip;

    int lives;
    int deaths;
    int kills;

    // skill; 
    //skill_menu_state skill_menu_do;
    //skill_menu_state skill_menu_view;

    int depth; // 던전 깊이

    int normal_vision;       //평소 시야
    int current_vision;       



    

    public int State_maxhp() { return max_HP; }
    public int State_currenthp() { return current_HP; }
   
}
