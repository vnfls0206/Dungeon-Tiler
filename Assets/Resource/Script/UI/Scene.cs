using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Change_MainGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Change_Menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit_Game()
    {
       
    }
}
