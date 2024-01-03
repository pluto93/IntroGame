using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            UnlockNewLevel();
            Debug.Log("Player entered the finish zone.");
            Debug.Log("Current Level Index: " + SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    /*void UnlockNewLevel()
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

    // Save the changes to PlayerPrefs.
    PlayerPrefs.Save();

    // Log the new values.
    Debug.Log("New Reached Index: " + PlayerPrefs.GetInt("ReachedIndex"));
    Debug.Log("New Unlocked Level: " + PlayerPrefs.GetInt("UnlockedLevel"));
}

}

