using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modle_Holder : MonoBehaviour
{
    private UIManager UIManager;
    private MapManager MapManager;

    public List<Model> Models = new List<Model>();

    private float Width;
    private RectTransform rect;

    [SerializeField] Camera Render_Camera;

    public bool Render_Camera_Active
    {
        get
        {
            return Render_Camera.gameObject.activeSelf;
        }
        set
        {
            Render_Camera.gameObject.SetActive(value);
            StartCoroutine(Active_Model_View(value));
        }
    }


    private int view_count;
    private int View_Count
    {
        get
        {
            return view_count;
        }
        set
        {
            view_count = value;

        }
    }


    public void Set_Holder(UIManager uimanager, MapManager mapmanager)
    {
        this.UIManager = uimanager;
        this.MapManager = mapmanager; 
        View_Count = 1;

        rect = this.GetComponent<RectTransform>();
        Width = rect.sizeDelta.x;

        Render_Camera.gameObject.SetActive(false);

        foreach (Model i in Models)
        {
            i.Set_Model(this, UIManager, mapmanager);
        }
    }

    public IEnumerator Active_Model_View(bool Activate)
    {
        Vector2 Dex_Position = new Vector2();

        if(Activate)
        {
            Dex_Position =
                new Vector2(0, rect.anchoredPosition.y);

            View_Count = 1;

            Activate = true;

            List<Item> Tile_List = UIManager.Get_Inventory_Function().Get_Item_List(ItemType.Tile);

            int i = 0;

            foreach (Model model in Models)
            {
                if (Tile_List.Count - 1 >= i * View_Count)
                {
                    model.Item = Tile_List[i];
                }
                else
                {
                    model.Item = null;
                }
                i++;
            }
        }
        else if(!Activate)
        {
            Dex_Position =
                new Vector2(Width, rect.anchoredPosition.y);


            Activate = false;
        }

        //Render_Camera.gameObject.SetActive(Activate);
        yield return StartCoroutine(Holder_Move(Dex_Position));
    }

    public void Update_Model_View(Model model,Item item)
    {

        if(item == null)
        {

        }
        else
        {
            Tile_No temp = UIManager.Get_Tile_No(item.Item_No);

            if (temp.Object_No != 0)            //오브젝트가 Null이 아닌경우
            {
                model.Set_Block_Model(MapManager.Get_TileObject_From_List(temp.Object_No - 1));
            }
            else
            {
                model.Set_Quad_Model(MapManager.Get_TileBase_From_List(temp.Base_No - 1));
            }
        }

    }


    private IEnumerator Holder_Move(Vector2 Dex_Position)
    {
        float speed = 1000;

        Vector2 Starting_Position = rect.anchoredPosition;

        while (!(Vector2.Distance(rect.anchoredPosition, Dex_Position) <= 2f))
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, Dex_Position,
            speed * Time.deltaTime);

            yield return null;

        }
    }


}
