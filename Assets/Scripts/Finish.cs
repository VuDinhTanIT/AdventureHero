using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            // Debug.Log("Finish lv: " + collision.gameObject.name);
            finishSound.Play();
            // levelCompleted = true;
            // GetComponent<PlayerLife>().Win();
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Level Completed ");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
