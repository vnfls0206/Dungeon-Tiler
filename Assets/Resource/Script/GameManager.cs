using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Manager")]
    public MapManager MapManager;
    public PlayerManager PlayerManager;
    public InputManager InputManager;





    //시작 작업
    void Awake()
    {
        Set_Managers();


    }

    //프레임마다 갱신작업
    void Update()
    {
        Update_Managers();
    }

    private void Set_Managers()
    {
        PlayerManager.Set_Manager(null);
        MapManager.Set_Manager(null);
        InputManager.Set_Manager(null);
    }

    private void Update_Managers()
    {
        InputManager.Update_Manager();
    }
}

#region Manager_Interface
public interface IManager
{

    void Set_Manager(GameData gamedata);
    void Update_Manager();

}
#endregion

#region GameData
public class GameData
{

}
#endregion
