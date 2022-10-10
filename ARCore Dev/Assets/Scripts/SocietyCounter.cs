using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SocietyCounter : MonoBehaviour
{
    Text societyText;
    public static int societyAmount = 100;
    void Start()
    {
        societyText = GetComponent<Text>();
    }

    void Update()
    {
        societyText.text = societyAmount.ToString();

    }
}
