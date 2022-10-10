using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResourceManagerScript : MonoBehaviour
{
    //Resources Start at 100
    //I am by no means good at this, but this is what I could come up with. There are undoubtedly more elegent soluions but this is what I have come up, by all means adjust to fit what should be done.
    int energy = 100;
    int happiness = 100;
    int food = 100;
    int society = 100;
    void Start()
    {

    }

    void Update()
    {
        
    }
    //on screen there is a left button and a right button, I am calling them good and bad respectively depending on which button they push the same process occurs but the "bad" button is negative
    public void goodButton()
    {
        ChangeManager("positive");
    }
    public void badButton()
    {
        ChangeManager("negative");
    }
    public void ChangeManager(string goodBad)
    {
        //called by a player button press. Depending on the button pressed A value (in this case a random number in range 10, 50) passed through to each function handling the resource values
        //francis review, no likey negative integers, good/bad nomenclature
        if (goodBad == "negative")
        {
            int randomNumberValue = Random.Range(-30, -10);

            ChangeEnergyValue(randomNumberValue);
            ChangeHappinessValue(randomNumberValue);
            ChangeFoodValue(randomNumberValue);
            ChangeSocietyValue(randomNumberValue);

            Debug.Log("Random Value is" + randomNumberValue);
        }
        else
        {
            int randomNumberValue = Random.Range(10, 30);

            ChangeEnergyValue(randomNumberValue);
            ChangeHappinessValue(randomNumberValue);
            ChangeFoodValue(randomNumberValue);
            ChangeSocietyValue(randomNumberValue);

            Debug.Log("Random Value is" + randomNumberValue);
        }
    }
    public void ChangeEnergyValue(int randomNumberValue)
    {
        //the decided value is taken and modified(or not) and sent to the various counter scripts managing the on screen display.
        EnergyCounter.energyAmount -= randomNumberValue;
        energy -= randomNumberValue;

        //after the numbers are changed, their values are passed to the GameLossCheck function, which will determine if they are below zero, prompting a change in scene if they have lost
        GameLossCheck(energy);
    }
    public void ChangeHappinessValue(int randomNumberValue)
    {
        HappinessCounter.happinessAmount -= randomNumberValue + 5;
        happiness -= randomNumberValue + 5;
        GameLossCheck(happiness);
    }
    public void ChangeFoodValue(int randomNumberValue)
    {
        FoodCounter.foodAmount -= randomNumberValue / 2;
        food -= randomNumberValue / 2;
        GameLossCheck(food);
    }
    public void ChangeSocietyValue(int randomNumberValue)
    {
        SocietyCounter.societyAmount -= randomNumberValue + 1;
        society -= randomNumberValue + 1;
        GameLossCheck(society);
    }
    public void GameLossCheck(int recievedValue)
    {
        if (recievedValue <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
