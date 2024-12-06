using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InactivityDetector : MonoBehaviour
{
    public GameObject textBox;
    private float inactivityTimer = 0f;
    private float inactivityThreshold = 10f;

    void Start()
    {
        if (textBox != null)
        {
            textBox.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            inactivityTimer = 0f;
            if (textBox != null)
            {
                textBox.SetActive(false); 
            }
        }
        else
        {
            inactivityTimer += Time.deltaTime; 

            if (inactivityTimer >= inactivityThreshold && textBox != null && !textBox.activeSelf)
            {
                textBox.SetActive(true); 
            }
        }
    }
}