using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] Text coinsText;
    [SerializeField] AudioSource collectionSound;

    public int GetCoins()
    {
        return coins;
    }

    public void ResetCoins() //Reset number of coins
    {
        coins = 0;
    }

    private void OnTriggerEnter(Collider other) //To count the coins and show on screen.
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            collectionSound.Play();
        }
    }
}
