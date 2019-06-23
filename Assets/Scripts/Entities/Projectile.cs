using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rigid;

    void Awake()
    {
        // Get reference to Rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }
    
    // Fire's this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        // Add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid asteroid = collision.GetComponent<Asteroid>();
        if (asteroid)
        {
            asteroid.Destroy();
            Destroy(gameObject);
        }
    }
}
