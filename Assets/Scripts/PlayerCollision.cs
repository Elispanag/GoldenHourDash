using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameManager gameManager;
    public float fallThreshold = -1f;
    void Update()
    {
        //Check if player has fallen below threshold
        if (transform.position.y < fallThreshold)
        {
           gameManager.EndGame();
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {   
            //Remove a life
            gameManager.LoseLife();

            //Destroy the obstacle
            Destroy(collisionInfo.collider.gameObject);

            //Check if lives are left
            if (gameManager.lives <= 0)
            {
                movement.enabled = false;
            }
        }
    }
}
