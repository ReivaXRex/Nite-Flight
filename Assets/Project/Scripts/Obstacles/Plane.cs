using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public int m_Speed = 5;
    
    private const float m_StartPos = -12.0f;
    private const float m_EndPos = 22.0f;
  
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponentInChildren<AudioSource>();
        m_AudioSource.clip = AudioManager.Instance.GetPropellerSound;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        PlayPropellerAudio();
        PausePropellerAudio();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
        if (transform.position.x > m_EndPos)
        {
            SpawnManager.Instance.m_PlaneCount--;
            Destroy(this.gameObject);
        }
    }

    public void PlayPropellerAudio()
    {
        if (transform.position.x < m_StartPos && GameManager.Instance.m_isPaused == false)
            m_AudioSource.Play();
    }

    public void PausePropellerAudio()
    {
        if (GameManager.Instance.m_isPaused == true)
            m_AudioSource.Pause();
    }
}
