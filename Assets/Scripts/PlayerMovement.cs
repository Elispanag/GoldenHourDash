using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public GameObject speedMessageUI;
    private float nextDifficultyMilestone = 300f;

    // Jump
    public float jumpForce = 7f;
    private bool isGrounded = true;

    void Update()
    {
        // Jumping mechanic 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Player is now in the air
        }
    }

    void FixedUpdate()
    {   
        // Add a forward force
         rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime); 

         if (transform.position.z > nextDifficultyMilestone)
         {
            IncreaseDifficulty();
         }
         
        // Movement to the right
        if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }
        // Movement to the left
        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Death condition
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    void IncreaseDifficulty()
    {
       forwardForce += 200f; // Increase forward force
       nextDifficultyMilestone += 300f; // Set next milestone  

       StartCoroutine(ShowMessage());
    }

    IEnumerator ShowMessage()
    {
        speedMessageUI.SetActive(true);
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        speedMessageUI.SetActive(false);
    }

    // Detect when the player lands back on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true; // Player has landed
        }
    }
}
