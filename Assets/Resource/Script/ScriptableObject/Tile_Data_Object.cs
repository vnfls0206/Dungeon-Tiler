using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile_Data", menuName = "ScriptableObject/Tile_Data")]
public class Tile_Data_Object : ScriptableObject
{
    public List<Tile_Data> Tile_Data_List;
}

[System.Serializable]
public class Tile_Data
{
    public string Tile_Nume;
    public string Tile_Des;

}
