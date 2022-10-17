using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessCounter : MonoBehaviour
{
    Text happinessText;
    public static int happinessAmount = 30;
    void Start()
    {
        happinessText = GetComponent<Text>();
    }

    void Update()
    {
        happinessText.text = happinessAmount.ToString();

    }
}
