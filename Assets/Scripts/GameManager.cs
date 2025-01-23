using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2025
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameManager : MonoBehaviour
{
    // Static instance property to provide global access
    public static GameManager Instance { get; private set; }

    // References should be private with SerializeField to follow encapsulation
    public LevelManager levelManager;
    public Player player;

    private void Awake()
    {
        #region Singleton Pattern

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        #endregion

        ReferenceCheck();
    }

    private void ReferenceCheck()
    {
        // Check if levelManager reference is empty
        if (levelManager == null)
        {
            Debug.LogWarning("SceneManager reference is empty, attempting to find in children!");

            // Attempt to find component in children
            levelManager = GetComponentInChildren<LevelManager>();
            
            // Check to see if it's still empty
            if (levelManager == null)
            {
                Debug.LogError("SceneManager reference is missing in GameManager and its children!");
            }
        }

        // Check if player reference is empty
        if (player == null)
        {
            Debug.LogWarning("Player reference is empty, attempting to find in children!");

            // Attempt to find component in children
            player = GetComponentInChildren <Player>();

            // Check to see if it's still empty
            if (player == null)
            {
                Debug.LogError("Player reference is missing in GameManager and its children!");
            }
        }

    }
}
