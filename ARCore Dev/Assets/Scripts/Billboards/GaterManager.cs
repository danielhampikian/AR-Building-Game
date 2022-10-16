using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaterManager : MonoBehaviour
{

    public bool happy, scared, angry;
    public GameObject gator1, gator2, gator3;


    // Start is called before the first frame update
    void Start()
    {
        gator1 = FindObjectOfType<GameObject>();
        gator2 = FindObjectOfType<GameObject>();
        gator3 = FindObjectOfType<GameObject>();


        if (happy = true)
        {
            gator1.gameObject.SetActive(true);
            gator2.gameObject.SetActive(false);
            gator3.gameObject.SetActive(false);
            scared = false;
            angry = false;
        }

        if (scared = true)
        {
            gator1.gameObject.SetActive(false);
            gator2.gameObject.SetActive(true);
            gator3.gameObject.SetActive(false);
            happy = false;
            angry = false;
        }

        if (angry = true)
        {
            gator1.gameObject.SetActive(false);
            gator2.gameObject.SetActive(false);
            gator3.gameObject.SetActive(true);
            happy = false;
            scared = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
