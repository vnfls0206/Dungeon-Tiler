using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Log : MonoBehaviour
{
    public Text log;
    public List<string> texts; 

    public void show_Log(string str)
    {
        if (texts.Count >= 7)
            texts.Remove(texts[0]);

        texts.Add(str);
        log.text = "";

        for(int i=0; i<texts.Count;i++)
        {
            log.text += texts[i] + ".\n";
        }
    }
}
