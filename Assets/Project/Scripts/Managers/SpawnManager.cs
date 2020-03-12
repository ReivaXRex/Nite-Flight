using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public GameObject m_PlanePrefab;
    public Transform[] m_SpawnPoints;
    public GameObject m_PlanePrefab;
    public int m_PlaneCount;
    public float m_SpawnTime = 3f;
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Spawn Manager is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlane", 0, m_SpawnTime);
    }

    public void SpawnPlane()
    {
        if (GameManager.Instance.m_IsGameOver == false && m_PlaneCount <= 3)
        {
            int randomNumber = Random.Range(0, 3);
            Instantiate(m_PlanePrefab, m_SpawnPoints[randomNumber].position, m_PlanePrefab.transform.rotation);
            m_PlaneCount++;
        }
    }

}
