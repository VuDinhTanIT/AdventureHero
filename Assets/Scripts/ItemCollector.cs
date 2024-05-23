using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int coins = 0;

    [SerializeField] private Text coinsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    internal void UpdateCoinsText()
    {
        coinsText.text = "Scores: " + coins;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start: " + coins + "LevelCompleted: " + GetComponent<SavingPlayerPrefabs>().GetLevelCompleted());
        if (GetComponent<SavingPlayerPrefabs>().GetLevelCompleted() == 1)
        {
            coins = GetComponent<SavingPlayerPrefabs>().GetCoins();
            UpdateCoinsText();
            GetComponent<SavingPlayerPrefabs>().setLevelCompleted(0);
            Debug.Log(" GetLevelCompleted done: " + GetComponent<SavingPlayerPrefabs>().GetLevelCompleted() + " coins: " + coins); ;
        }
        // UpdateCoinsText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            Debug.Log("coinsText: " + coins);
            UpdateCoinsText();
            // coinsText.text = "Scores: " + coins;
        }
    }

}
