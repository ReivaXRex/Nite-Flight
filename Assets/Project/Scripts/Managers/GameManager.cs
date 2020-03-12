using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject m_PlayerPrefab;
    public Transform m_StartPos;

    public bool m_IsGameOver;
    public bool m_isPaused;
    // public bool m_ResumeAudio;
    public bool m_Muted;
   
    // public int m_Score;
    // public Text m_ScoreText;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        SpawnPlayer(m_PlayerPrefab, m_StartPos);
        _instance = this;
      //  DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //m_ResumeAudio = false;
        m_isPaused = false;
        m_IsGameOver = false;

        SpawnPlayer();
      //  SpawnPlayer(m_PlayerPrefab, m_StartPos);
            
        // Time.timeScale = 1.0f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnPlayer(m_PlayerPrefab, m_StartPos);
        }
    }

    public void PlayerDied()
    {
        m_IsGameOver = true;
        
    }

    public void GameOver()
    {
        UIManager.Instance.ToggleGameOverScreen(m_IsGameOver);
      // AudioListener.volume = 0.0f;
        // Time.timeScale = 0;
    }

    public void PauseGame()
    {
        m_isPaused = true;
        UIManager.Instance.TogglePauseScreen(m_isPaused);
        //  m_PauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //m_ResumeAudio = true;
        m_isPaused = false;
        UIManager.Instance.TogglePauseScreen(m_isPaused);
        // m_PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Mute()
    {
        m_Muted = true;
        AudioListener.volume = 0.0f;

    }

    public void UnMute()
    {
        m_Muted = false;
        AudioListener.volume = 1.0f;
    }

    public void RestartGame()
    {
        // AudioListener.volume = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void SpawnPlayer(GameObject playerPrefab, Transform startPosition)
    {
       Instantiate(playerPrefab, startPosition);
       
    }

    public void SpawnPlayer()
    {
        Instantiate(m_PlayerPrefab, m_StartPos.position, m_PlayerPrefab.transform.rotation);
    }

}
