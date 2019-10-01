using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BaseEnemy : BaseActor
{
    Enemy_enum enemy_Enum;

    public string enemy_name;

    public int max_HP;
    public int current_HP;

    public int max_MP;
    public int current_MP;

    public int speed;
    public int speed_increment;


}
