using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public enum Stat_type //스텟
    {
        STAT_STR,
        STAT_INT,
        STAT_DEX,
        STAT_AGI,
        STAT_STAMINA,
        NUM_STATS,
        STAT_ALL,
        STAT_RANDOM,
    };

    public Stat_type stat_type;

    public float baseATK;
    public float currentATK;
    public float baseDEF;
    public float currentDEF;

    private int strength;
    private int intellect;
    private int dexterity;
    private int agility;
    private int stamina;

    public int Strength() { return strength; }
    public int Intellect() { return intellect; }
    public int Dexterity() { return dexterity; }
    public int Agility() { return agility; }
    public int Stamina() { return stamina; }


}
