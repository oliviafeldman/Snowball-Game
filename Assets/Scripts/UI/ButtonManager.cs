using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Controls;
    private bool IsShowingControls = false; 
    public void LoadFrostyFrolic()
    {
        SceneManager.LoadScene("FrostyFrolic");
    }

    public void ToggleControls()
    {
        IsShowingControls = !IsShowingControls;  
        Controls.SetActive(IsShowingControls); 
    }

    void Start()
    {
        Controls.SetActive(false);
    }

    void Update()
    {
        if (IsShowingControls && Input.GetKeyDown(KeyCode.E))
        {
            ToggleControls(); 
        }
    }
}
