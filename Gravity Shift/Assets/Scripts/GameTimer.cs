using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private static GameTimer instance;

    void Awake()
    {
        // This is so there arent multiple timers
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        GameData.totalTime += Time.deltaTime;
    }
}