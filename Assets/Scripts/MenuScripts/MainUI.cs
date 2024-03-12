using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private PlayerController playerControllerScript;
    public GameObject gameOverText;
    
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
       
    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(1);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
}
