using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    void Start()
    {
        int minutes = Mathf.FloorToInt(GameData.totalTime / 60);
        int seconds = Mathf.FloorToInt(GameData.totalTime % 60);

        statsText.text = "<color=#FFFFFF>Time: " + minutes + "m " + seconds + "s</color>\n" +
                 "<color=#FF4444>Deaths: " + GameData.deathCount + "</color>\n" +
                 "<color=#FFD700>Stars: " + GameData.starsCollected + 
                 "/" + GameData.totalStars + "</color>";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameData.ResetAll();
            SceneManager.LoadScene("TitleScreen");
        }
    }
}