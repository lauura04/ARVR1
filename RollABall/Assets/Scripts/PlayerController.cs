using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] PumpkingCounter pumpkingCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Read keyboard input using the modern Input System
        if (Keyboard.current != null)
        {
            // Left/right movement 
            if (Keyboard.current.rightArrowKey.isPressed)
                moveX = -1f;
            else if (Keyboard.current.leftArrowKey.isPressed)
                moveX = 1f;

            // Forward/backward movement
            if (Keyboard.current.upArrowKey.isPressed)
                moveZ = -1f;
            else if (Keyboard.current.downArrowKey.isPressed)
                moveZ = 1f;

        }
        // Create the movement vector
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado: " + other.name);
        if (other.CompareTag("PickUp"))
        {
            sfxSource.PlayOneShot(coinSound);
            pumpkingCounter.OnTriggerEvent();
            other.gameObject.SetActive(false);
        }
    }
}
