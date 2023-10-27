using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    public static GameWinManager Instance { get; private set; }

    private bool isWin;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isWin = false;
    }

    public void TriggerWin()
    { 
        isWin = true;
        winPanel.SetActive(true);
    }

    private void Update()
    {
        OnWin();
    }

    private void OnWin()
    {
        if (isWin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
}