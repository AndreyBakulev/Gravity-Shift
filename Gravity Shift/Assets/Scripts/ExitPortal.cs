using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.portalClip);
            FadeManager.Instance.FadeToScene(nextSceneName);
        }
    }
}