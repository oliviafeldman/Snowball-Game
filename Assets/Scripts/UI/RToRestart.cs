using UnityEngine;
using UnityEngine.SceneManagement;

public class RToRestart : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
