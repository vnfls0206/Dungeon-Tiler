using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private PlayerManager PlayerManager;
    private Transform Target { get; set; }
    private Transform Camera_Tr { get; set; }

    private float dist = 8;       //카메라와의 거리
    private float Height = -2f;   //카메라와의 높이  o일땐 -2
    private float DampRotate = -5f;  //회전

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        PlayerManager = GameManager.PlayerManager;

        Target = PlayerManager.transform;
        Camera_Tr = this.transform;
       
    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {

        float Cur_Y_Angle = Mathf.LerpAngle(Camera_Tr.eulerAngles.y, Target.eulerAngles.y, DampRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, Cur_Y_Angle, 0);

        Camera_Tr.position = Target.position - (rot * Vector3.forward * dist) + (Vector3.up * Height);

        //tr.position = tr.position.x > GameData.Instance.Map_Size - 5 ? 

        Camera_Tr.LookAt(Target);
    }

    public GameObject Get_GameObject_By_Lay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }

        return null;
    }
}
