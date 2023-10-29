using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private const string fisrtLevel = "Level1";

    [SerializeField] private string[] levels = new string[6];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LevelStatus firstLevelStatus = GetLevelStatus(0);
        Debug.Log(firstLevelStatus.ToString());
        SetLevelStatus(0, firstLevelStatus == LevelStatus.Lock ? LevelStatus.Unloack : firstLevelStatus); 
    }

    public LevelStatus GetLevelStatus(int index)
    {
        Debug.Log(index);
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(levels[index], 0);
        return levelStatus;
    }

    public void SetLevelStatus(int index, LevelStatus status)
    {
        if (index >= levels.Length)
        {
            Debug.Log("Last Level Cross");
            return;
        }
        PlayerPrefs.SetInt(levels[index], (int)status);
    }
}
