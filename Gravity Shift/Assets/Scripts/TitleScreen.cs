using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject settingsPanel;

    public void PlayGame()
    {
        GameData.ResetAll();
        SceneManager.LoadScene("Chamber1");
    }

    public void GoToTutorial()
    {
        GameData.ResetAll();
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void HideHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void HideSettings()
    {
        settingsPanel.SetActive(false);
    }
}