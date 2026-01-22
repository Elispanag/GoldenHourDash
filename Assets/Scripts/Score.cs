using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   public Transform player;
   public Text scoreText;
   public Text highScoreText;

    void Start()
    {
        // Display the high score at the start
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        // Current score based on player's z position
        int currentScore = (int)player.position.z;
        // Check and update high score
        scoreText.text = "SCORE: " + currentScore.ToString();
        // Update high score if current score exceeds it
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            // Save new high score
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
            // Update high score display
            highScoreText.text = "HIGH SCORE: " + currentScore.ToString();
        }
    }
}
