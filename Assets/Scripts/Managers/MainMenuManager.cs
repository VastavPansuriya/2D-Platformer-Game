using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        AudioManager.Instace.PlayEffect(SoundType.UIInteractSound);

        SceneManager.LoadScene("LevelSelect");
    }

    public void Quit()
    {
        AudioManager.Instace.PlayEffect(SoundType.UIInteractSound);

        Application.Quit();
    }
}
