using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
