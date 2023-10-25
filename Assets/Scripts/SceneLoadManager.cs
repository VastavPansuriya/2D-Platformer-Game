using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private int index = 0;
    private void Start()
    {
        if (TryGetComponent(out Button button))
        {
            button.onClick.AddListener(() => SceneManager.LoadScene(button.gameObject.name));
        }
    }

    public void ChangeScene()
    {
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;

        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextBuildIndex);

        if (nextScene != null)
        {
            SceneManager.LoadScene(nextBuildIndex);
        }
    }
}
