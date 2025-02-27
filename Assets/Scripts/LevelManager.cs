using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2025
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)


// "SceneManager" is an existing class in Unity, and it is part of the UnityEngine.SceneManagement namespace.
// you cannot give a class that name as it will cause a conflict.

public class LevelManager : MonoBehaviour
{
    private string spawnPointName; // Store the spawn point name for use after the scene loads


    public void LoadSceneWithSpawnPoint(string sceneName, string spawnPoint)
    {
        //Debug.Log($"Loading level: {sceneName}, with spawn point: {spawnPoint}");

        // Store the spawn point name for use after the scene loads
        spawnPointName = spawnPoint;

        // Load the scene
        SceneManager.LoadScene(sceneName);

        


        // Subscribe to the sceneLoaded callback
        SceneManager.sceneLoaded += OnSceneLoaded;


    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log($"Scene {scene.name} loaded. Setting player position to spawn point: {spawnPointName}");

        // Set the player's position to the spawn point
        SetPlayerToSpawn(spawnPointName);

        // Unsubscribe from the callback to avoid repeated triggers
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetPlayerToSpawn(string spawnPointName)
    {
        // Find the spawn point by name
        GameObject spawnPointObject = GameObject.Find(spawnPointName);
        if (spawnPointObject != null)
        {
            // Set the player's position to the spawn point
            Transform spawnPointTransform = spawnPointObject.transform;            
            GameManager.Instance.player.transform.position = spawnPointTransform.position;
        }
        else
        {
            Debug.LogError($"Spawn point with name '{spawnPointName}' not found in the scene!");
        }
    }



}
