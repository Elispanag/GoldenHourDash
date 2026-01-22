using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3; // Player starts with 3 lives
    private int maxLives = 3;

    public Image heartFillImage;

    public GameObject gameOverScreen;

    public Transform player;
    public TextMeshProUGUI finalScoreText;


    void Start()
    {
        maxLives = lives;
        UpdateHeartsUI();
        // Ensure the game is running
        Time.timeScale = 1f; 
    }
    public void LoseLife()
    {
        lives--;
        UpdateHeartsUI();

        if (lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
        if (player !=null && finalScoreText !=null)
        {
            float score = player.position.z;
            finalScoreText.text = "Final Score: " + score.ToString("F0"); // FO means no decimal places
        }
        Time.timeScale = 0f; // Pause the game
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void UpdateHeartsUI()
    {
       if (heartFillImage != null)
       {
           heartFillImage.fillAmount = (float)lives / maxLives;
       }
    }
}
