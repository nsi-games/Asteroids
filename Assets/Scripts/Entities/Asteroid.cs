using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroidPiece;
    public int scoreValue = 1;
    public int spawnAmount = 4;
    public float maxVelocity = 3f;

    private Rigidbody2D rigid;
    private SpriteRenderer rend;

    public Sprite Sprite
    {
        get { return rend.sprite; }
        set { rend.sprite = value; }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    public void Fire(Vector3 force)
    {
        // Apply random force to rigidbody
        rigid.AddForce(force, ForceMode2D.Impulse);
    }

    // Spawns Asteroid pieces when Asteroid get destroyed
    public void Destroy()
    {
        // Destroy self
        Destroy(gameObject);

        // If an asteroid piece is assigned
        if (asteroidPiece)
        {
            // Loop through spawn amount
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawn that piece
                AsteroidManager.Instance.Spawn(asteroidPiece, transform.position);
            }
        }
        else
        {
            // Add score to GameManager
            GameManager.Instance.AddScore(scoreValue);
        }
    }
}
