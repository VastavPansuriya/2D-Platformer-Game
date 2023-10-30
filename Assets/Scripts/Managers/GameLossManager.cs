using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLossManager : MonoBehaviour
{
    private int sceneIndex = 0;

    [Header("UI Settings")]
    [SerializeField] private GameObject lossPanel;

    bool isLossPlayed = false;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (!GameLossData.isLoss)
        {
            return;
        }
        else
        {
            if (!isLossPlayed)
            {
                AudioManager.Instance.PlayEffect(SoundType.Die);
                isLossPlayed = true;
            }
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

