using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAttempt : MonoBehaviour
{
    public Transform rim; // Reference to the basketball stanchion rim
    public float shootForce = 10f; // initial force to shoot the ball
    public float shootAngle = 45f; // angle of the shot arc
    private bool gameEnded = false;
    bool hasCollided = false;
    public UIManager uiManager; 


 void OnCollisionEnter(Collision collision)
    {
        // collision detection with the floor
        if (collision.collider.CompareTag("Floor") && !gameEnded)
        {
            // failed level
            string gameOverMessage = "Game Over - Ball hit the floor!";
            Debug.Log(gameOverMessage);
            gameEnded = true;
            // displays game over text on canvas
            uiManager.ShowGameOverText(gameOverMessage);
         
        }

        // collision detection with the rim
        else if (collision.collider.CompareTag("Rim") && !gameEnded)
        {
            // beat  level
            string levelCompleteMessage = "Level Completed - Ball touched the rim!";
            Debug.Log(levelCompleteMessage);
            gameEnded = true;
            // displays game over text on canvas
            uiManager.ShowGameOverText(levelCompleteMessage);

        }

        }
        void Update(){
        // checks for player input (mouse click)
        if (Input.GetMouseButtonDown(0) && !gameEnded)
        {
            // calculation of direction towards the rim
            Vector3 direction = (rim.position - transform.position).normalized;

            // calculation of initial velocity for the arc
            float horizontalVelocity = shootForce * Mathf.Cos(shootAngle * Mathf.Deg2Rad);
            float verticalVelocity = shootForce * Mathf.Sin(shootAngle * Mathf.Deg2Rad);

            Vector3 shootVelocity = new Vector3(direction.x * horizontalVelocity, verticalVelocity, direction.z * horizontalVelocity);

            // applies force to shoot the ball
            GetComponent<Rigidbody>().velocity = shootVelocity;
        }
        //displays no message on canvas if the ball has not collided with the rim or the floor during gameplay
        if (!hasCollided && !gameEnded)
            {
                string duringGamePlay = "";
                gameEnded = false;
                uiManager.ShowGameOverText(duringGamePlay);
            }
    }
}

    
