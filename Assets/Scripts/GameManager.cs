#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
#if !UNITY_EDITOR
            Application.Quit();
#else
            EditorApplication.ExitPlaymode();
#endif
        }
    }

    public static void Reload()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
}
