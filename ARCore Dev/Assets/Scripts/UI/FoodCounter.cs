using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodCounter : MonoBehaviour
{
    Text foodText;
    public static int foodAmount = 100;
    void Start()
    {
        foodText = GetComponent<Text>();
    }

    void Update()
    {
        foodText.text = foodAmount.ToString();

    }
}
