using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transform m_Destination;
    public GameObject m_playerIntroPrefab;
    bool isFlying;

    Animator m_playerAnimator;
    Transform m_playerTransform;
     
    public void Start()
    {
        m_playerAnimator = m_playerIntroPrefab.GetComponent<Animator>();
        m_playerTransform = m_playerIntroPrefab.GetComponent<Transform>();
    }

    private void Update()
    {
        if (isFlying == true)
        {
            m_playerTransform.Translate(Vector3.up * 2 * Time.deltaTime);
        }
    }

    public void PlayGame()
    {
        m_playerAnimator.SetTrigger("Fly");
        isFlying = true;
        Invoke("LoadLevel", 3);

    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}

