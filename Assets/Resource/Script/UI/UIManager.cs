using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private ItemManager ItemManager;

    [SerializeField] private Inventory Inventory;
    [SerializeField] private Option Option;
    [SerializeField] private GameObject UI_BackGround;

    private Stack<IUI> active_ui;
    public IUI Active_UI
    {
        get
        {
            return active_ui.Peek();
        }
        set
        {
            if(value != null)
            {
                if (active_ui.Count == 0)
                {
                    UI_BackGround.SetActive(true);
                }
                active_ui.Push(value);
            }
            else
            {
                active_ui.Peek().Object_Enabled = false;
                active_ui.Pop();

                if (active_ui.Count == 0)
                    UI_BackGround.SetActive(false);
            }

        }
    }

    public void Set_Manager(GameManager gamemanager)  //Awake에 해당한다. 시작시 호출
    {
        this.GameManager = gamemanager;
        ItemManager = GameManager.ItemManager;

        active_ui = new Stack<IUI>();

        if (GameManager.Get_GameData() != null)    //게임 데이터가 있을때 Load 해준다
        {

        }
        else                    //게임 데이터가 없을때 시작
        {
            
        }

        Inventory.Set_UI(this);
        Inventory.Set_Item(ItemManager);

        Option.Set_UI(this);


    }

    public void Update_Manager()    //Update에 해당, 매 프레임마다 갱신
    {

    }

    public bool Is_UI_Active()
    {
        return (active_ui.Count != 0);   //하나라도 활성화 되어있는 UI가 있다면 True를 반환
    }

    public Inventory Get_Inventory_Function()
    {
        return this.Inventory;
    }

    public Option Get_Option_Function()
    {
        return this.Option;
    }

    public void UI_Disabled()
    {
        Active_UI = null;

        
    }

    #region UI_Interface
    public interface IUI
    {

        void Set_UI(UIManager uImanager);
        void Update_UI();
        bool Object_Enabled
        {
            get;
            set;
        }

    }
    #endregion
}
