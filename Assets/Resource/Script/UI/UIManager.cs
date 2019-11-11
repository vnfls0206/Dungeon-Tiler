using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IManager
{
    private GameManager GameManager;
    private ItemManager ItemManager;
    private MapManager MapManager;
    private PlayerManager PlayerManager;

    [SerializeField] private Inventory Inventory;
    [SerializeField] private Option Option;
    [SerializeField] private GameObject UI_BackGround;
    [SerializeField] private Modle_Holder Modle_Holder;
    [SerializeField] private UI_Button UI_Button;

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
        this.ItemManager = GameManager.ItemManager;
        this.MapManager = GameManager.MapManager;
        this.PlayerManager = GameManager.PlayerManager;

        active_ui = new Stack<IUI>();

        if (GameManager.Get_GameData() != null)    //게임 데이터가 있을때 Load 해준다
        {

        }
        else                    //게임 데이터가 없을때 시작
        {
            
        }

        Inventory.Set_UI(this);
        Inventory.Set_Item(this.ItemManager);

        Modle_Holder.Set_Holder(this, this.MapManager);

        UI_Button.Set_UI(this);
        UI_Button.Set_Map(this.MapManager);
        UI_Button.Set_Player(this.PlayerManager);

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

    public Tile_No Get_Tile_No(int Tile_No)
    {
        return new Tile_No(Tile_No / 100, Tile_No % 100);
    }

    public void Active_Model_View(bool Button_Active)
    {
        if(Button_Active != Modle_Holder.Render_Camera_Active)
        {
            Modle_Holder.Render_Camera_Active = Button_Active;
        }
    }

    public void Pre_TIle_Set()
    {
        if (MapManager.Get_Map_target() != null)
        {
            PlayerManager.Set_Camera_To_Player();

            MapManager.HL_Active();

            Active_Model_View(MapManager.Is_HL_Active());
        }
    }


    public Tile_Sort Get_Tile_By_Item(Item item)
    {
        Tile_No no = Get_Tile_No(item.Item_No);

        return new Tile_Sort((eTileBase)no.Base_No, (eTileObject)no.Object_No);
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
