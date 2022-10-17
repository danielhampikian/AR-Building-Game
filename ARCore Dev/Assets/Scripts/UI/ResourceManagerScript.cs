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
    int turns;
    float timer;

    public GameObject buildingManager;

    //originally I had a manager script and object for this but I do not remember how to properly send the timer value to that script. So I just moved everything over here
    //everything mean these objects, the stuff in start, update and the UIactive functions
    public GameObject promptBackground;
    public GameObject buttonBad;
    public GameObject buttonGood;
    public GameObject exclamation;
    public GameObject promptManager;
    public GameObject gator1, gator2, gator3;
    void Start()
    {
        SetUIInactive();
        turns = 0;
        timer = 2f;

        promptManager.GetComponent<PromptManager>();
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
    //public void goodButton()
    //{
    //    //ChangeManager("positive");
    //    turns += 1;
    //    GameWinCheck(turns);
    //    timer = 10f;
    //    Debug.Log("turns " +turns);
    //    SetUIInactive();
    //}
    //public void badButton()
    //{
    //    //ChangeManager("negative");
    //    turns += 1;
    //    GameWinCheck(turns);
    //    timer = 10f;
    //    Debug.Log("turns " + turns);
    //    SetUIInactive();

    //}
    //public void ChangeManager(string goodBad)
    //{
    //    //called by a player button press. Depending on the button pressed A value (in this case a random number in range 10, 50) passed through to each function handling the resource values
    //    if (goodBad == "negative")
    //    {
    //        int randomNumberValue = Random.Range(-30, -10);

    //        buildingManager.GetComponent<BuildingManager>().buildingHeight -= 1f;

    //        ChangeEnergyValue(randomNumberValue);
    //        ChangeHappinessValue(randomNumberValue);
    //        ChangeFoodValue(randomNumberValue);
    //        ChangeSocietyValue(randomNumberValue);

    //        Debug.Log("Random Value is" + randomNumberValue);
    //    }
    //    else
    //    {
    //        int randomNumberValue = Random.Range(10, 30);

    //        buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;

    //        ChangeEnergyValue(randomNumberValue);
    //        ChangeHappinessValue(randomNumberValue);
    //        ChangeFoodValue(randomNumberValue);
    //        ChangeSocietyValue(randomNumberValue);

    //        Debug.Log("Random Value is" + randomNumberValue);
    //    }
    //}
    public void ChangeEnergyValue(int randomNumberValue)
    {
        //the decided value is taken and modified(or not) and sent to the various counter scripts managing the on screen display.
        EnergyCounter.energyAmount += randomNumberValue;
        energy += randomNumberValue;
        Debug.Log("Energy: " + energy);
        //after the numbers are changed, their values are passed to the GameLossCheck function, which will determine if they are below zero, prompting a change in scene if they have lost
        GameLossCheck(energy);
    }
    public void ChangeHappinessValue(int randomNumberValue)
    {
        HappinessCounter.happinessAmount += randomNumberValue;
        happiness += randomNumberValue;
        Debug.Log("Happiness: " + happiness);
        GameLossCheck(happiness);
    }
    public void ChangeFoodValue(int randomNumberValue)
    {
        FoodCounter.foodAmount += randomNumberValue;
        food += randomNumberValue;
        Debug.Log("Food: " + food);
        GameLossCheck(food);
    }
    public void ChangeSocietyValue(int randomNumberValue)
    {
        SocietyCounter.societyAmount += randomNumberValue;
        society += randomNumberValue;
        Debug.Log("Society: " + society);
        GameLossCheck(society);
    }
    public void GameLossCheck(int recievedValue)
    {
        timer += 3f;
        turns += 1;

        SetUIInactive();
        GameWinCheck(turns);
        promptManager.GetComponent<PromptManager>().NewPrompt();
        Debug.Log("New Prompt Called");
        
        if (recievedValue <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void GameWinCheck(int recievedTurnsValue)
    {
        Debug.Log("turns" + turns);
        if(recievedTurnsValue >= 10)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void GaterChange()
    {
        if(happiness >= 21 & energy >= 21 & food >= 21 & society >= 21 )
        {
            gator1.SetActive(true);
            gator2.SetActive(false);
            gator3.SetActive(false);
        }

        if (happiness >= 11 & energy >= 11 & food >= 11 & society >= 11)
        {
            gator1.SetActive(false);
            gator2.SetActive(true);
            gator3.SetActive(false);
        }

        if (happiness <= 10 & energy <= 10 & food <= 10 & society <= 10)
        {
            gator1.SetActive(false);
            gator2.SetActive(false);
            gator3.SetActive(true);
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
