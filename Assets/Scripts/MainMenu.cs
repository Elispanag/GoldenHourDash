using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject highScorePanel;
    public TextMeshProUGUI highScoreValueText;

    // Start the game
   public void PlayGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }
    public void CloseControls()
    {
        controlsPanel.SetActive(false);
    }

    public void OpenHighScore()
    {
        highScorePanel.SetActive(true);
        int savedScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreValueText.text = savedScore.ToString();
    }
    public void CloseHighScore()
    {
        highScorePanel.SetActive(false);
    }
     // Quit the game 
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }


}

