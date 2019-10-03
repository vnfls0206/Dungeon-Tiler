using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private PlayerManager PlayerManager;
    private MapManager MapManager;
    private UIManager UIManager;
    private CameraManager CameraManager;
    //0929 지운
    private EnemyManager EnemyManager;

    private Tile Target;
    private Vector3 prePos;
    private bool Is_PointerDown;

    private float dragThresholdCM;
    private float inchToCm;

    Dictionary<KeyCode, Action> First_key_Check_Dictionary;         //입력키와 호출되는 함수들을 저장하자
    Dictionary<KeyCode, Action> Continuous_key_Check_Dictionary;     //(나중에 설정으로 키가 바뀔 수 도 있으니)

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        PlayerManager = GameManager.PlayerManager;  //게임 매니저로 부터 Manager를 받아온다
        UIManager = GameManager.UIManager;
        MapManager = GameManager.MapManager;
        CameraManager = GameManager.CameraManager;

        Is_PointerDown = false;

        dragThresholdCM = 0.5f;
        inchToCm = 2.54f;
        EventSystem.current.pixelDragThreshold = (int)(dragThresholdCM * Screen.dpi / inchToCm);

        First_key_Check_Dictionary = new Dictionary<KeyCode, Action>     //지속적인 입력을 감지하는 KeyCode들
        {
            //{ KeyCode.Mouse0, OnPointerDown}
            //,{ KeyCode.W, () => MapManager.SetTile(1, 2, eTile.WALL, Sight_Sort.Black)}       //참고용을 붙여놓음
        };      //나중에는 데이터가 있으면 키설정을 불러오고 없으면 이대로 초기화하도록 수정하자

    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {

        if (Input.anyKeyDown)       //첫번째 입력만을 감지
        {
            if(First_key_Check_Dictionary.Count != 0)
            {
                foreach (KeyValuePair<KeyCode, Action> dic in First_key_Check_Dictionary)     //First_key_Check_Dictionary에 등록된 KeyCode가 입력되면
                {
                    if (Input.GetKeyDown(dic.Key))
                    {
                        dic.Value();            //해당되는 함수를 호출한다.
                    }
                }
            }
        }

#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                OnPointerDown(touch.position);
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 nowPos = touch.position - touch.deltaPosition;
                Vector3 movePos = (Vector3)(prePos - nowPos) * 0.05f;
                CameraManager.Position = CameraManager.Position + movePos;
                prePos = touch.position - touch.deltaPosition;

                Target = null;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                OnPointerUp();
            }
        }

#else
        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDown(Input.mousePosition);
            prePos = Input.mousePosition;
        }

        // 마우스가 떼짐
        if (Input.GetMouseButtonUp(0))
        {
            OnPointerUp();

        }

        if (Is_PointerDown)
        {
            Vector3 nowPos = Input.mousePosition;

            if(!UIManager.Is_UI_Active())
            {
                if (nowPos != prePos)
                {
                    Vector3 movePos = (Vector3)(prePos - nowPos) * 0.05f;

                    CameraManager.Position = CameraManager.Position + movePos;
                    prePos = Input.mousePosition;

                    Target = null;
                }
            }

        }
#endif

        //if (Input.anyKey)   //지속적인 입력을 감지
        //{
        //    foreach (var dic in Continuous_key_Check_Dictionary)     //Continuous_key_Check_Dictionary에 등록된 KeyCode가 입력되면
        //    {
        //        if (Input.GetKey(dic.Key))
        //        {
        //            dic.Value();        //해당되는 함수를 호출한다.
        //        }

        //    }
        //}
    }


    private void OnPointerDown(Vector3 touch_position)
    {
        Target = MapManager.Tile_Touch(touch_position);
        if (Target != null)
        {
            //MapManager.Tile_Target(Target);
        }
        Is_PointerDown = true;
    }

    private void OnPointerUp()
    {
        //(마우스 클릭 설계)
        //1) UI가 활성화 되어있는가
        // -> UI 클릭만을 받아야 되므로 다른 클릭을 받지않는다.

        //  2) Tile Hight가 활성화 되어 있는가
        //      2-1) 클릭한것이 Tile인가
        //      2-2) Tile이라면 HightLight가 활성화 되어있는가

        //  3) Tile Hight가 활성화 되어 잇지 않은가
        //      3-1) 클릭한것이 Tile 인가
        //      3-2) Tile이라면 그 시야값은 Black이 아닌것인가?



        Is_PointerDown = false;

        if(!UIManager.Is_UI_Active())       //활성화 되어있는 UI가 없을때
        {
            if (Target != null)  //Target 오브젝트가 null이 아닐때
            {
                if(Target.Sight_Sort != Sight_Sort.Black)   //Target이 검은 시야상태가 아닐때
                {
                    if(!MapManager.Get_HightLight_Active())  // 보통 상태일때
                    {
                        if (MapManager.Set_Map_Target(Target))
                        {
                            if (MapManager.Is_Move_Able_Tile(Target.Tile_Sort))  //클릭한 타일이 이동가능 타일일 경우
                            {
                                StartCoroutine(PlayerManager.Move_To_Dex(Target));
                            }
                        }
                    }
                    else            //HightLight가 켜져있을때
                    {
                        if(MapManager.Is_HighLight_Tile(Target))
                        {
                            if (MapManager.Set_Map_Target(Target))
                            {

                            }
                        }

                    }
                }

            }
        }

        Target = null;
    }

    public bool Is_Dragging()
    {
        return Is_PointerDown;
    }



}
