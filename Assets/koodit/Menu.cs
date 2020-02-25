using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string level1;
    public string level2;
    public string level3;

    public void StartLevel1()
    {
        SceneManager.LoadScene(level1);
    }
    public void StarLevel2()
    {
        SceneManager.LoadScene(level2);
    }
    public void StarLevel3()
    {
        SceneManager.LoadScene(level3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
