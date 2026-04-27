using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int deathCount = 0;
    public static float totalTime = 0f;
    public static int starsCollected = 0;
    public static int totalStars = 4; //1 per chamber + tutorial

    public static void ResetAll()
    {
        deathCount = 0;
        totalTime = 0f;
        starsCollected = 0;
    }
}