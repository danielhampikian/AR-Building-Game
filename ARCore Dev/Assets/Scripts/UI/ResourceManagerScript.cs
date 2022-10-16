using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResourceManagerScript : MonoBehaviour
{
    //Resources Start at 100 Note from Brendon: I've changed the resource values to be different than 100 so that it makes the gameplay more challenging
    //I am by no means good at this, but this is what I could come up with. There are undoubtedly more elegent soluions but this is what I have come up, by all means adjust to fit what should be done.
    int energy = 30;
    int happiness = 30;
    int food = 30;
    int society = 10;
    int turns = 0;
    float timer;

    public GameObject buildingManager;

    //originally I had a manager script and object for this but I do not remember how to properly send the timer value to that script. So I just moved everything over here
    //everything mean these objects, the stuff in start, update and the UIactive functions
    public GameObject promptBackground;
    public GameObject buttonBad;
    public GameObject buttonGood;
    public GameObject exclamation;

    void Start()
    {
        SetUIInactive();
        timer = 10f;
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SetUIActive();
        }
    }
    //on screen there is a left button and a right button, I am calling them good and bad respectively depending on which button they push the same process occurs but the "bad" button is negative
    //they also increment the turns value, progressing the player to the victory condition
    public void goodButton()
    {
        ChangeManager("positive");
        turns += 1;
        GameWinCheck(turns);
        timer = 20f;
        SetUIInactive();
    }
    public void badButton()
    {
        ChangeManager("negative");
        turns += 1;
        GameWinCheck(turns);
        timer = 20f;
        SetUIInactive();

    }
    public void ChangeManager(string goodBad)
    {
        //called by a player button press. Depending on the button pressed A value (in this case a random number in range 10, 50) passed through to each function handling the resource values
        //francis review, no likey negative integers, good/bad nomenclature
        if (goodBad == "negative")
        {
            int randomNumberValue = Random.Range(-30, -10);

            buildingManager.GetComponent<BuildingManager>().buildingHeight -= 1f;
            
            ChangeEnergyValue(randomNumberValue);
            ChangeHappinessValue(randomNumberValue);
            ChangeFoodValue(randomNumberValue);
            ChangeSocietyValue(randomNumberValue);
            
            Debug.Log("Random Value is" + randomNumberValue);
        }
        else
        {
            int randomNumberValue = Random.Range(10, 30);

            buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;

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
    public void GameWinCheck(int recievedTurnsValue)
    {
        if(recievedTurnsValue >= 10)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void SetUIInactive()
    {
        promptBackground.SetActive(false);
        buttonBad.SetActive(false);
        buttonGood.SetActive(false);
        exclamation.SetActive(false);
    }
    private void SetUIActive()
    {
        promptBackground.SetActive(true);
        buttonBad.SetActive(true);
        buttonGood.SetActive(true);
        exclamation.SetActive(true);
    }

}
