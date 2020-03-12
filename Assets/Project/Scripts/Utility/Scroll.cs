using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float m_ScrollSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * m_ScrollSpeed * Time.deltaTime);
    }
}
