using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Reference rigidbody so that we can update its movement 
    private Rigidbody rb;
    // Public variables can be set from the Unity editor
    public float speed;
    // Number of objects we've collected
    private int count;

    public Text countText;
    public Text winText;

    // Get the rigidbody at the start of the program
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    // For physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    // Called when the object touches a trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false); // Deactivate game object
            count += 1; // Increment count
            setCountText();
        }
    }

    // Update countText
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        // Set win text
        if (count >= 12)
        {
            winText.text = "You win!";
        }
    }
}
