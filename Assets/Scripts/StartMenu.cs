using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Startbtn()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Debug.Log("Will quit");
        Application.Quit();
    }
}
