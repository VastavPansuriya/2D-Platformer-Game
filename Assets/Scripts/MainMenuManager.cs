using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private const string LEVEL_SELECT = "LevelSelect";
    public void Play()
    {
        SceneManager.LoadScene(LEVEL_SELECT);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
