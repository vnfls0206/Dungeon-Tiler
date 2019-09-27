using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explain_Window : MonoBehaviour
{
    public bool WindowsEnable;

    public Image Explain_image;
    public Text  Item_name;
    public Text  item_desc;

    public GameObject Window;

    void Update()
    {
        if (WindowsEnable == true)
            Window.SetActive(true);
        else
            Window.SetActive(false);
    }
    public void OnWindow()
    {
        WindowsEnable = !WindowsEnable;
    }

}
