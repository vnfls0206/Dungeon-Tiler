using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    public void SetValue(int cur, int max)
    {
        slider.value = (float)cur / max;
    }
}
