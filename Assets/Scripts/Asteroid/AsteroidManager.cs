using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    #region Singleton
    public static AsteroidManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject[] asteroidPrefabs; // Array of prefabs to spawn
    public float maxVelocity = 3f;
    public float spawnRate = 1f; // Rate of spawn
    public float spawnPadding = 2f; // Padding to spawn

    [Header("Debugging")]
    public Color debugColor = Color.cyan;
    void OnDrawGizmosSelected()
    {
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }
    
    // Use this for initialization
    void Start()
    {
        // Invoke a function repeatedly with given rate
        InvokeRepeating("SpawnLoop", 0, spawnRate);
    }
    
    // Spawns a random asteroid in the array at a random position + rotation
    void SpawnLoop()
    {
        // Get camera's bounds using Extension Method
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);

        // Randomize a position within a circle
        Vector2 randomPos = camBounds.GetRandomPosOnBounds();

        // Generate random index into asteroid prefabs array
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);

        // Get random asteroid prefab from array using index
        GameObject randomAsteroid = asteroidPrefabs[randomIndex];

        // Spawn using random pos
        Spawn(randomAsteroid, randomPos);
    }

    public void Spawn(GameObject prefab, Vector3 position)
    {
        // Randomize a rotation for the asteroid
        Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Spawn random asteroid at random position and default Quaternion rotation
        GameObject clone = Instantiate(prefab, position, randomRot, transform);

        // Get Asteroid component from clone
        Asteroid asteroid = clone.GetComponent<Asteroid>();

        // Generate Asteroid name from random index (there are two types of each asteroid prefab)
        string asteroidName = prefab.name + Random.Range(0, 2).ToString();
        string path = "Sprites/Asteroids/" + asteroidName;
        asteroid.Sprite = Resources.Load<Sprite>(path);
    }
}
