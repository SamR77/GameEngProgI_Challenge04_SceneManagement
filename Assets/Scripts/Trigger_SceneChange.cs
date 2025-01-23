using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2025
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)
public class Trigger_SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoadName; // The name of the scene to load
    [SerializeField] private string spawnPoint;      // The name of the spawn point to position the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure the trigger is activated only by the player
        if (other.CompareTag("Player"))
        {
            // Trigger the scene change via LevelManager, passing the scene name and spawn point
            GameManager.Instance.levelManager.LoadLevelWithSpawnPoint(sceneToLoadName, spawnPoint);
        }
    }
}
