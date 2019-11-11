using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Model : MonoBehaviour
{
    private Modle_Holder Modle_Holder;
    private UIManager UIManager;
    private MapManager MapManager;

    [SerializeField] private MeshRenderer Block_rend;
    [SerializeField]private MeshRenderer Quad_rend;

    private GameObject Active_Model;

    private Item item;
    public Item Item
    {
        get
        {
            return item;
        }
        set
        {
            
            item = value;
            Modle_Holder.Update_Model_View(this ,value);

        }
    }



    public void Set_Model(Modle_Holder model_holder, UIManager uimanager, MapManager mapmanager)
    {
        this.Modle_Holder = model_holder;
        this.MapManager  = mapmanager;
        this.UIManager = uimanager;

        item = null;
        Active_Model = null;
    }

    public void Set_Block_Model(Material material)
    {
        Block_rend.gameObject.SetActive(true);
        Quad_rend.gameObject.SetActive(false);

        Block_rend.material = material;

    }

    public void Set_Quad_Model(Texture2D tex)
    {
        Quad_rend.gameObject.SetActive(true);
        Block_rend.gameObject.SetActive(false);

        Quad_rend.material.mainTexture = tex;

    }


    public void OnClick()
    {
        if(this.item != null)
        {
            if(MapManager.Is_HighLight_Tile(MapManager.Get_Map_target()))
            {
                UIManager.Pre_TIle_Set();

                MapManager.Set_Tile(MapManager.Get_TileObj_By_Tile(MapManager.Get_Map_target()),
                    UIManager.Get_Tile_By_Item(item));
            }

        }

    }



}
