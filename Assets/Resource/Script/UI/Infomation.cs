using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infomation : MonoBehaviour, UIManager.IUI
{
    public Text Level;
    public Text Exp;
    public Text Stat;
    public Text Gold;

    private UIManager UIManager;

    [SerializeField] private GameObject Option_Obj;   // 객체

    private bool object_enabled;
    public bool Object_Enabled
    {
        get
        {
            return object_enabled;
        }
        set
        {
            object_enabled = value;
            Option_Obj.SetActive(value);
            if (value)
            {
                UIManager.Active_UI = this;
            }
        }
    }

    public void Set_UI(UIManager uimanager)
    {
        this.UIManager = uimanager;

        object_enabled = false;
    }
    public void Set_Stat()
    {
        //Level.text = "Level "+BasePlayer.State_Level();
        //Exp.text = "Exp "+ BasePlayer.State_Exp()+"/"+ BasePlayer.State_TotalExp();
        //Stat.text = "STR  "+Stat.Strength()+
        //            "\nINT  "+ Stat.Intellect()+
        //            "\nDEX  "+ Stat.Dexterity()+
        //            "\nAGI  "+ Stat.Agility()+
        //            "\nSTAMINA  "+Stat.Stamina();
        //Gold.text = "Gold   "+ BasePlayer.State_Gold();


        Level.text = "Level 2";
        Exp.text = "Exp 7/15";
        Stat.text = "STR  7\nINT  5\nDEX  6\nAGI  5\nSTAMINA  15";
        Gold.text = "Gold   101";
    }
    public void Update_UI()
    {

    }

    public void Set_Activate()
    {
        Object_Enabled = !Object_Enabled;
        Set_Stat();
    }

}
