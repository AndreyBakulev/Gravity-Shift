using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown
            && !Input.GetKeyDown(KeyCode.Escape)
            && !Input.GetKeyDown(KeyCode.F1)
            && !Input.GetKeyDown(KeyCode.F4)
            && !Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}