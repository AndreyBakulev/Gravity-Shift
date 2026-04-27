using UnityEngine;

public class Star : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.starsCollected++;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.starCollectClip);
            Destroy(gameObject);
        }
    }
}