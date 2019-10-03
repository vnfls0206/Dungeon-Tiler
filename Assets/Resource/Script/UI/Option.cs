using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour, UIManager.IUI
{
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
    public void Update_UI()
    {

    }

    public void Set_Activate()
    {
        Object_Enabled = !Object_Enabled;
    }

}
