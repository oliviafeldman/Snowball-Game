using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }

    // Update is called once per frame
    void LoadScene()
    {
        SceneManager.LoadScene("Levels Page");
    }
}
