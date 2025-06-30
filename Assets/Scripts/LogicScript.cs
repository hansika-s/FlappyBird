using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    private AudioSource scoreSFx;
    private int highScore;

    void Start()
    {
        scoreSFx = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void addScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
        scoreSFx.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        PlayerPrefs.Save();

        gameOverScreen.SetActive(true);
        playerScore = 0;
    }
}
