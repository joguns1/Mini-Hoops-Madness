using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanchionMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f; // Speed of the horizontal movement
    [SerializeField] float minZ = -5f; // Minimum z position
    [SerializeField] float maxZ = 5f; // Maximum z position
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    private bool movingForward = true; // Flag to track direction of movement

    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement direction based on the current direction
        Vector3 movementDirection = movingForward ? Vector3.forward : Vector3.back;

        // Move the stanchion horizontally
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        // Check if the stanchion has reached the minimum or maximum z position
        if (transform.position.z <= minZ)
        {
            movingForward = true; // Change direction to forward
        }
        else if (transform.position.z >= maxZ)
        {
            movingForward = false; // Change direction to back
        }

        // Move the stanchion vertically in a sine wave pattern
        Vector3 v = startingPosition;
        v.x += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
