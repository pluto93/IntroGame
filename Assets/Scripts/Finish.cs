using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    public int requiredCoins = 5; // Set the number of coins required to finish the level
    
    public Text collectMoreCoinsText; // Reference to the UI text element

    void Start()
    {
        collectMoreCoinsText.gameObject.SetActive(false); // Initially hide the message
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
        
            ItemCollector itemCollector = FindObjectOfType<ItemCollector>();
            if (itemCollector != null && itemCollector.GetCoins() >= requiredCoins)
            {
                UnlockNewLevel();
                Debug.Log("Player entered the finish zone.");
                Debug.Log("Current Level Index: " + SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                collectMoreCoinsText.gameObject.SetActive(false);
            }
            else
            {
                // Display a text message if the player fails to collect enough coins
                if (collectMoreCoinsText != null)
                {
                    collectMoreCoinsText.gameObject.SetActive(true); // Show the message
                }
            }
        }
    }

void UnlockNewLevel()
{
    // Get the index of the current scene.
    int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    
    // Retrieve the highest level index reached by the player.
    int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0); // Default to 0 if not set.

    // Check if the current level index is greater than the reached index.
    if (currentLevelIndex > reachedIndex)
    {
        // Update the reached index to the current level index.
        PlayerPrefs.SetInt("ReachedIndex", currentLevelIndex);
    }
    
    // Retrieve the number of unlocked levels.
    int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Default to 1 if not set.

    if (currentLevelIndex == unlockedLevel)
    {
        PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
        Debug.Log("Unlocked Levels after update: " + (unlockedLevel + 1));
    }

    ItemCollector itemCollector = FindObjectOfType<ItemCollector>();
    if (itemCollector != null)
    {
        itemCollector.ResetCoins();
    }

    // Save the changes to PlayerPrefs.
    PlayerPrefs.Save();

    // Log the new values.
    Debug.Log("New Reached Index: " + PlayerPrefs.GetInt("ReachedIndex"));
    Debug.Log("New Unlocked Level: " + PlayerPrefs.GetInt("UnlockedLevel"));

}

}

