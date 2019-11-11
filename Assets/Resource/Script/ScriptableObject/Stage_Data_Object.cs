using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage_Data", menuName = "ScriptableObject/Stage_Data")]
public class Stage_Data_Object : ScriptableObject
{
    public List<Stage_Data> stage_Data_List;

}




[System.Serializable]
public class Stage_Data
{
    public int Stage_Num;
    public eTileBase Nomal;
    public eTileObject Wall;
    public eTileBase Concept_Tile_1;
    public eTileBase Concept_Tile_2;

}
