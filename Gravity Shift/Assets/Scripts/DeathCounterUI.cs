using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathCounterUI : MonoBehaviour
{
    public TextMeshProUGUI deathText;
    private static DeathCounterUI instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Hide text on title and win screen, show during gameplay
        bool isGameScene = scene.name != "TitleScreen" && scene.name != "WinScreen";
        deathText.gameObject.SetActive(isGameScene);
    }

    void Update()
    {
        deathText.text = "Deaths: " + GameData.deathCount;
    }
}