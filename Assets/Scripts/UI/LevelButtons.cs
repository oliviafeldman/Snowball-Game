using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("TempMenu");
    }
    
    public void LoadTutorial()
    {
        SceneManager.LoadScene("DylanScene 1");
    }

    public void LoadMaze()
    {
        SceneManager.LoadScene("ClaireScene2");
    }

    public void LoadPlats()
    {
        SceneManager.LoadScene("OliviaScene1");
    }
    
}
