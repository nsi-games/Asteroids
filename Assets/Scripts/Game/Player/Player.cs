using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab to spawn when shooting

    public float movementSpeed = 10f; // Movement in units (force to apply)
    public float rotationSpeed = 360f; // Rotation in degrees (per second)
    private Rigidbody2D rigid; // Reference to rigidbody

    // Use this for initialization
    void Start()
    {
        // Get reference to rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }

    // Control is a custom made function to handle movement + rotation
    void Control()
    {
        // If player hits Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Shoot a projectile
            Shoot();
        }

        // If the Up key is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Add a force up
            rigid.AddForce(transform.up * movementSpeed);
        }

        // If the Down key is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Add a force up
            rigid.AddForce(-transform.up * movementSpeed);
        }

        // If the Left key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate counter-clockwise per second
            rigid.rotation += rotationSpeed * Time.deltaTime;
        }

        // If the Right key is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate counter-clockwise per second
            rigid.rotation -= rotationSpeed * Time.deltaTime;
        }
    }

    void Shoot()
    {
        // Spawn projectile at position and rotation of Player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Get Rigidbody2D from projectile
        Projectile bullet = projectile.GetComponent<Projectile>();
        bullet.Fire(transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }
}
