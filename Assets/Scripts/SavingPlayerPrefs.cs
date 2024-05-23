using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPlayerPrefabs : MonoBehaviour
{
    public const string ScoreKey = "Score";
    private const string HealthKey = "Health";

    public const string HighScoreKey = "HighScore";

    public const string LevelKey = "LevelCompleted";

    public int highScore = 0;

    private void Start()
    {
        // LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            int score = PlayerPrefs.GetInt(ScoreKey);
            // Gán score vào biến coins trong class ItemCollector
            ItemCollector itemCollector = GetComponent<ItemCollector>();
            itemCollector.coins = score;
            // Cập nhật text hiển thị score
            itemCollector.UpdateCoinsText();
        }
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey); // Tải giá trị điểm cao nhất từ PlayerPrefs
            Debug.Log("High Score: " + highScore);
            // Xử lý điểm cao nhất theo nhu cầu của bạn
        }

        // if (PlayerPrefs.HasKey(HealthKey))
        // {
        //     float health = PlayerPrefs.GetFloat(HealthKey);
        //     // Gán health vào currentHealth trong class Health
        //     Health healthComponent = GetComponent<Health>();
        //     healthComponent.currentHealth = health;
        // }
    }

    public void SaveData()
    {
        // Lưu score
        ItemCollector itemCollector = GetComponent<ItemCollector>();
        int score = itemCollector.coins;
        PlayerPrefs.SetInt(ScoreKey, score);
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = highScore > PlayerPrefs.GetInt(HighScoreKey) ? highScore : PlayerPrefs.GetInt(HighScoreKey);
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt(HighScoreKey, highScore); // Lưu giá trị điểm cao nhất vào PlayerPrefs
                Debug.Log("New High Score: " + highScore);
            }
        }

        // Lưu dữ liệu PlayerPrefs xuống ổ cứng
        // Lưu health
        Health healthComponent = GetComponent<Health>();
        float health = healthComponent.currentHealth;
        PlayerPrefs.SetFloat(HealthKey, health);

        // Lưu dữ liệu PlayerPrefs xuống ổ cứng
        PlayerPrefs.Save();
    }
    public void SaveHighScore(int score, int highScore)
    {
        // Lưu score
        // ItemCollector itemCollector = GetComponent<ItemCollector>();
        // int score = itemCollector.coins;
        // PlayerPrefs.SetInt(ScoreKey, score);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score); // Lưu giá trị điểm cao nhất vào PlayerPrefs
            Debug.Log("New High Score: " + score);
            PlayerPrefs.Save();
        }
    }
    public void SaveLevelCompleted()
    {
        PlayerPrefs.SetInt(LevelKey, 1);
    }
    public int GetLevelCompleted()
    {
        if (PlayerPrefs.HasKey(LevelKey))
        {

            return PlayerPrefs.GetInt(LevelKey);
        }
        else
        {
            return 0;
        }
    }


    internal void setLevelCompleted(int b){
        PlayerPrefs.SetInt(LevelKey, b);
    }
    internal int GetCoins()
    {
        Debug.Log("GetCoins: " + GetComponent<ItemCollector>().coins + "score: " + PlayerPrefs.GetInt(ScoreKey) );
        return PlayerPrefs.GetInt(ScoreKey);
    }
    internal float GetHealth()
    {
        return PlayerPrefs.GetFloat(HealthKey);
    }

    
}