using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip m_propellerSound;
    public AudioClip GetPropellerSound { get => m_propellerSound; }

    [SerializeField] AudioClip m_breakdownSound;
    public AudioClip GetBreakdownSound { get => m_breakdownSound; }

    [SerializeField] AudioClip m_crashSound;
    public AudioClip GetCrashSound { get => m_crashSound; }

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("Audio Manager is NULL");

            return _instance;
            
        }
    }
    // Start is called before the first frame update

    private void Awake()
    {
        _instance = this;
         DontDestroyOnLoad(this.gameObject);
    } 

}
