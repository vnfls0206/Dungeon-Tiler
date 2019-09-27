using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Manager")]
    public MapManager MapManager;
    public PlayerManager PlayerManager;
    public InputManager InputManager;
    public CameraManager CameraManager;


    private GameData gamedata = null;

    //시작 작업
    void Awake()
    {
        Screen.SetResolution(1280, 720, true);
        Set_Managers();

    }

    //프레임마다 갱신작업
    void Update()
    {
        Update_Managers();
    }

    private void Set_Managers()
    {
        PlayerManager.Set_Manager(this);
        MapManager.Set_Manager(this);
        InputManager.Set_Manager(this);
        CameraManager.Set_Manager(this);
    }

    private void Update_Managers()
    {
        InputManager.Update_Manager();
        MapManager.Update_Manager();
        CameraManager.Update_Manager();
    }

    public GameData Get_GameData()
    {
        return this.gamedata;
    }
}

#region Manager_Interface
public interface IManager
{

    void Set_Manager(GameManager gamemanager);
    void Update_Manager();

}
#endregion

#region GameData
public class GameData
{

}
#endregion
