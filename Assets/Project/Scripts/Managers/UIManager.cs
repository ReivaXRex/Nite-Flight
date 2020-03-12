using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text m_PlayerScoreText;
    [SerializeField] private Text m_HighScoreText;
    [SerializeField] private GameObject m_MuteButton;
    [SerializeField] private GameObject m_UnmuteButton;
    [SerializeField] GameObject m_PauseScreen;
    [SerializeField] GameObject m_GameOverScreen;
    public int m_Score;
    private float timer;
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager is NULL");
            return _instance;
            
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        m_HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.m_IsGameOver == false)
        {
            UpdateScore();
            UpdateScoreText();
            UpdateHighScore(UpdateScore());
        }
        
    }

    public int UpdateScore()
    {
        int delayAmount = 1;
        timer += Time.deltaTime;

        if (timer >= delayAmount)
        {
            timer = 0f;
            m_Score++;

        }

        return m_Score;

    }

    public void UpdateHighScore(int score)
    {
        score = UpdateScore();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            m_HighScoreText.text = "HighScore :" + score;
        }
    }

    public void UpdateScoreText()
    {
        if (GameManager.Instance.m_IsGameOver == false)
        {
            m_PlayerScoreText.text = "Score: " + UpdateScore();
        }
      
    }

    public void ToggleMuteButton()
    {
        if (GameManager.Instance.m_Muted == true)
        {
            m_MuteButton.SetActive(false);
            m_UnmuteButton.SetActive(true);
        }
        else
        {
            m_MuteButton.SetActive(true);
            m_UnmuteButton.SetActive(false);
        } 
       
    }

    public void TogglePauseScreen(bool isGamePaused)
    {
        isGamePaused = GameManager.Instance.m_isPaused;
        if (isGamePaused == true)
        {
            m_PauseScreen.SetActive(true);
        }
        else
        {
            m_PauseScreen.SetActive(false);
        }
        
    }

    

    public void ToggleGameOverScreen(bool isGameOver)
    {
        isGameOver = GameManager.Instance.m_IsGameOver;
        if (isGameOver == true)
        {
            m_GameOverScreen.SetActive(true);
        }
     
    }

}
