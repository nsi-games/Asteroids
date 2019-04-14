using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public GameObject[] asteroidPieces;
    public int spawnAmount = 4;
    public float maxVelocity = 3f;
    
    // Spawns a random asteroid in a random direction
    void Spawn()
    {
        // Generate random index into asteroid pieces array
        int randomIndex = Random.Range(0, asteroidPieces.Length);

        // Select random asteroid piece
        GameObject asteroidPiece = asteroidPieces[randomIndex];

        // Ask the Asteroid Manager to spawn a new asteroid piece at a position
        AsteroidManager.Spawn(asteroidPiece, transform.position);
    }

    // Spawns Asteroid pieces when Asteroid get destroyed
    public void Destroy()
    {
        // Destroy self
        Destroy(gameObject);

        // If there are assigned asteroid pieces
        if (asteroidPieces.Length > 0)
        {
            // Loop through the specified spawn amount
            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawn an asteroid
                Spawn();
            }
        }
    }
}
