using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Manager")]
    public MapManager MapManager;
    public UIManager UIManager;
    public PlayerManager PlayerManager;
    public InputManager InputManager;
    public CameraManager CameraManager;
    public EventManager EventManager;
    public EnemyManager EnemyManager;

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
        EventManager.Set_Manager(this);             
        //이벤트를 먼저 세팅해줄것(이벤트는 초기화가 필요)
        PlayerManager.Set_Manager(this);
        MapManager.Set_Manager(this);
        UIManager.Set_Manager(this);
        InputManager.Set_Manager(this);
        CameraManager.Set_Manager(this);
        EnemyManager.Set_Manager(this);
    }

    private void Update_Managers()
    {
        InputManager.Update_Manager();
        MapManager.Update_Manager();
        UIManager.Update_Manager();
        CameraManager.Update_Manager();
        EventManager.Update_Manager();
        EnemyManager.Update_Manager();
    }

    public GameData Get_GameData()
    {
        return this.gamedata;
    }
}

#region Struct
public struct Array_Index
{
    public int x, y;
    public Array_Index(int X, int Y)
    {
        this.x = X;
        this.y = Y;
    }
}
#endregion

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
