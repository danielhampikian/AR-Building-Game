using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera m_Camera;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
        // The next three lines make this work only on the horizontal axis
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = 0;
        transform.eulerAngles = eulerAngles;
    }
}