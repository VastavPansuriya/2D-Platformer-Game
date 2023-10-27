using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockUnlockVisual : MonoBehaviour
{
    private Image levelButtonImage;
    private SceneLoadManager loadManager;
    private void Awake()
    {
        levelButtonImage = GetComponent<Image>();
    }

    private void Start()
    {
        loadManager = GetComponent<SceneLoadManager>();
        SetUI();
    }

    private void SetUI()
    {
        levelButtonImage.color = loadManager.status == LevelStatus.Unloack ? Color.grey: Color.black;
    }
}
