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
<<<<<<< Updated upstream
    public EventManager EventManager;
=======
    //0929 지운
    public EnemyManager EnemyManager;
>>>>>>> Stashed changes

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
        UIManager.Set_Manager(this);
        InputManager.Set_Manager(this);
        CameraManager.Set_Manager(this);
<<<<<<< Updated upstream
        EventManager.Set_Manager(this);
=======
        //0929 지운
        EnemyManager.Set_Manager(this);
>>>>>>> Stashed changes
    }

    private void Update_Managers()
    {
        InputManager.Update_Manager();
        MapManager.Update_Manager();
        UIManager.Update_Manager();
        CameraManager.Update_Manager();
<<<<<<< Updated upstream
        EventManager.Update_Manager();
=======
        //0929 지운
        EnemyManager.Update_Manager();
>>>>>>> Stashed changes
    }

    public GameData Get_GameData()
    {
        return this.gamedata;
    }
}

#region Class
public class Array_Index
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
