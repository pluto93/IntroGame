using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    public int requiredCoins = 5; // Set the number of coins required to finish the level
    //private int collectedCoins = 0;
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
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (collectedCoins >= requiredCoins)
            {
                UnlockNewLevel();
                Debug.Log("Player entered the finish zone.");
                Debug.Log("Current Level Index: " + SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                // Display a text message if the player fails to collect enough coins
                if (collectMoreCoinsText != null)
                {
                    collectMoreCoinsText.text = "Collect more coins to finish the level!";
                }
            }
    
        }

    }*/

    /*public void CollectCoin()
    {
        collectedCoins++;
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            Debug.Log("Unlocked Levels after update: " + PlayerPrefs.GetInt("UnlockedLevel"));
            PlayerPrefs.Save();
            Debug.Log("New Reached Index: " + PlayerPrefs.GetInt("ReachedIndex"));
            Debug.Log("New Unlocked Level: " + PlayerPrefs.GetInt("UnlockedLevel"));
        }
    }*/

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

    // Update the number of unlocked levels if necessary.
    // This assumes you want to unlock the next level only if the current level is the last unlocked level.
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

