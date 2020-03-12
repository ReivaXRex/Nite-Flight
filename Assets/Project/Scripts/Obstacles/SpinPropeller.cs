using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.forward * Time.deltaTime * 800);
    }
}
