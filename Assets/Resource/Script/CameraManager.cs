using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private MapManager MapManager;
    private PlayerManager PlayerManager;
    private InputManager InputManager;

    private float dist = 8;       //카메라와의 거리
    private float Height = -3f;   //카메라와의 높이  o일땐 -2
    private float DampRotate = -3f;  //회전

    public Vector3 Position
    {
        get                                             
        {
            return this.transform.position;
        }
        set
        {
            Vector3 pre_Position = this.transform.position;
            this.transform.position = value;

            if (InputManager.Is_Dragging())
            {
                if(pre_Position != this.transform.position)
                {
                    MapManager.Update_Tiles();
                }
            }

        }
    }

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        MapManager = GameManager.MapManager;
        PlayerManager = GameManager.PlayerManager;
        InputManager = GameManager.InputManager;

    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {

    }

    public void Set_Camera_Target(Transform Target)
    {
        float Cur_Y_Angle = Mathf.LerpAngle(this.transform.eulerAngles.y, Target.eulerAngles.y, DampRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, Cur_Y_Angle, 0);

        Vector3 Target_Vector2 = new Vector3(Target.position.x, Target.position.y);

        this.transform.position = Target_Vector2 - (rot * Vector3.forward * dist) + (Vector3.up * Height);

        this.transform.LookAt(Target);
    }



    public GameObject Get_GameObject_By_Lay(Vector3 Position)
    {
        Ray ray = Camera.main.ScreenPointToRay(Position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }

        return null;
    }
}
