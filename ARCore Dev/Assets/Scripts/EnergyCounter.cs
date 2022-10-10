using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCounter : MonoBehaviour
{
    //This is what I know works for displaying values accurately on the screen. There are probably several other ways to do this, each one more efficient/elegant than mine. by all means replace or alter my work
    //each counter script is set up in an indentical manner, each attached to its respective resource. Their purpose is to be fed values from the ResourceManagerScript and display them
    Text energyText;
    public static int energyAmount = 100;
    void Start()
    {
        energyText = GetComponent<Text>();

        //this was an idea I had to take the values straight from the ResourceManagerScript but I could not figure out how to do it good enough to actually use it
        //energyText.text = ResourceManagerScript.energy.ToString();
        //Debug.Log(ResourceManagerScript.energy);
    }

    void Update()
    {
        energyText.text = energyAmount.ToString();

    }
}
