using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2025
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)
public class Trigger_SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneName;       // The name of the scene to load
    [SerializeField] private string spawnPoint;      // The name of the spawn point to position the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure the trigger is activated only by the player
        if (other.CompareTag("Player"))
        {
            // Trigger the scene change via LevelManager, passing the scene name and spawn point
            GameManager.Instance.levelManager.LoadSceneWithSpawnPoint(sceneName, spawnPoint);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a wireframe cube matching the BoxCollider2D size
        Gizmos.color = new Color(0,255,255, 0.75f); // Set Gizmo color to cyan

        // Get the BoxCollider2D component
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        
        if (boxCollider != null)
        {
            // Calculate the center position and size of the WireCube
            Vector3 center = transform.position + (Vector3)boxCollider.offset;
            Vector3 size = new Vector3(boxCollider.size.x, boxCollider.size.y, 0);

            // Draw the WireCube
            Gizmos.DrawCube(center, size);
        }
        else
        {
            Debug.LogWarning("BoxCollider2D component not found on the GameObject.");
        }
    }




}
