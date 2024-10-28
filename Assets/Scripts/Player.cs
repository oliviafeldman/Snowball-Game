using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Calculate movement direction based on WASD input
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow Keys
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow Keys

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the object in the calculated direction, scaled by speed and deltaTime
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}