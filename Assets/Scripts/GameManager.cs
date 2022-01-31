using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }

    public static void Reload()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
}
