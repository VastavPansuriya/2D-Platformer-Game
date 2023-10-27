using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLossManager : MonoBehaviour
{
    private int sceneIndex = 0;

    [Header("UI Settings")]
    [SerializeField] private GameObject lossPanel;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameLossData.isLoss = false;
    }

    private void Update()
    {
        if (!GameLossData.isLoss)
        {
            return;
        }
        else
        {
            lossPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameLossData.isLoss = false;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

public static class GameLossData
{
    public static bool isLoss = false;
}

