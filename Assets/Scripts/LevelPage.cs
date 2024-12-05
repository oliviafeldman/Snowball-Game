using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }
    void LoadScene()
    {
        if (SceneManager.GetActiveScene().name == "FrostyFrolic")
        {
            SceneManager.LoadScene("MerryMaze");
        }

        if (SceneManager.GetActiveScene().name == "MerryMaze")
        {
            SceneManager.LoadScene("PolarPlatforms");
        }

        if (SceneManager.GetActiveScene().name == "PolarPlatforms")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
