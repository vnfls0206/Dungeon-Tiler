using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public bool OptionEnabled;
    public GameObject option;

    public void OnActive()
    {
        OptionEnabled = !OptionEnabled;
    }
    public void Update_UI()
    {
        if (OptionEnabled == true)
            option.SetActive(true);
        else
            option.SetActive(false);
    }
}
