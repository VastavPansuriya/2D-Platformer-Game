using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private int index = 0;

    public LevelStatus status;

    public void ChangeScene()
    {
        SceneManager.LoadScene(index);
    }
    private void Awake()
    {
        status = LevelManager.Instance.GetLevelStatus(index - 1);

        if (TryGetComponent(out Button button))
        {
            button.onClick.AddListener(() => ButtonChangeSceneUI());
        }
    }
    private void Start()
    {
    }

    private void ButtonChangeSceneUI()
    {
        status = LevelManager.Instance.GetLevelStatus(index - 1);
        switch (status)
        {
            case LevelStatus.Lock:
                Debug.Log("LevelIsLoacked");
                break;
            case LevelStatus.Unloack:
                SceneManager.LoadScene(index);
                break;
            case LevelStatus.Complete:
                SceneManager.LoadScene(index);
                break;
        }
    }

    public void ChangeSceneDoor()
    {
        LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().buildIndex, LevelStatus.Complete);

        LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().buildIndex + 1, LevelStatus.Unloack);

        GameWinManager.Instance.TriggerWin();
    }
}
