using UnityEngine;
using System.Collections;

public class DestroyOutOfBorder : MonoBehaviour
{
    public float padding = 10f;
    public Color debugColor = Color.red;

    void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        // If position is out of bounds
        if (!camBounds.Contains(transform.position))
        {
            // Destroy it
            Destroy(gameObject);
        }
    }
}
