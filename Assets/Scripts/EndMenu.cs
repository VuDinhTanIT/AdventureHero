using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text TextScoreCompleted;
    [SerializeField] private Text TextHighScore;
    int highScore = 0;
    private void Start()
    {
        // TextScoreCompleted.text = "Scores: " + 20;

        Debug.Log("EndMenu: ---------------" );
       
        if (PlayerPrefs.HasKey(SavingPlayerPrefabs.ScoreKey))
        {

            int score = PlayerPrefs.GetInt(SavingPlayerPrefabs.ScoreKey);
            TextScoreCompleted.text = "Scores: " + score;
            // GetComponent<SavingPlayerPrefabs>().SaveHighScore(score, highScore);
            Debug.Log("EndMenu - Score: " + score);
            // Gán score vào biến coins trong class ItemCollector
            // ItemCollector itemCollector = GetComponent<ItemCollector>();
            // itemCollector.coins = score;
            // // Cập nhật text hiển thị score
            // itemCollector.UpdateCoinsText();
        }
         if(PlayerPrefs.HasKey(SavingPlayerPrefabs.HighScoreKey)){
            Debug.Log("EndMenu - get High Score: " + SavingPlayerPrefabs.HighScoreKey);
            highScore = PlayerPrefs.GetInt(SavingPlayerPrefabs.HighScoreKey);
            TextHighScore.text = "High Score: " + highScore;
            Debug.Log("EndMenu - High Score: " + highScore);
        }
        // else
        //     TextScoreCompleted.text = "Scores: " + 20;
    }


    private void Update()
    {
        // Debug.Log("EndMenu -Update" );
        // TextScoreCompleted.text = "Score: " + 20;

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Debug.Log("New Game");
        SceneManager.LoadScene("Level 1");
    }

}
