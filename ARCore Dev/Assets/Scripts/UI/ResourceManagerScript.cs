using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResourceManagerScript : MonoBehaviour
{
    //Resources Start at 100 Note from Brendon: I've changed the resource values to be different than 100 so that it makes the gameplay more challenging
    //I am by no means good at this, but this is what I could come up with. There are undoubtedly more elegent soluions but this is what I have come up, by all means adjust to fit what should be done.
    int energy = 50;
    int happiness = 50;
    int food = 50;
    int society = 50;
    int turns;
    float timer;

    public GameObject buildingManager;
    public GameObject light1;
    public GameObject light2;

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

        GatorChange();
    }

    //------------------------------------------------------------------------
    //Change Resource Value 
    public void ChangeEnergyValue(int promptConsequense)
    {
        //the decided value is taken and modified(or not) and sent to the various counter scripts managing the on screen display.
        EnergyCounter.energyAmount += promptConsequense;
        energy += promptConsequense;
        //after the numbers are changed, their values are passed to the GameLossCheck function, which will determine if they are below zero, prompting a change in scene if they have lost
        GameLossCheck(EnergyCounter.energyAmount);
    }
    public void ChangeHappinessValue(int promptConsequense)
    {
        HappinessCounter.happinessAmount += promptConsequense;
        happiness += promptConsequense;
        GameLossCheck(HappinessCounter.happinessAmount);
    }
    public void ChangeFoodValue(int promptConsequense)
    {
        FoodCounter.foodAmount += promptConsequense;
        food += promptConsequense;
        GameLossCheck(FoodCounter.foodAmount);
    }
    public void ChangeSocietyValue(int promptConsequense)
    {
        SocietyCounter.societyAmount += promptConsequense;
        society += promptConsequense;
        GameLossCheck(SocietyCounter.societyAmount);
    }
    //------------------------------------------------------------------------



    //------------------------------------------------------------------------
    //Check for win or
    public void GameLossCheck(int recievedValue)
    {
        if (recievedValue <= 0)
        {
            SceneManager.LoadScene("GameOver");
        } else {
            timer += 3f;
            turns += 1;

            SetUIInactive();
            GameWinCheck(turns);
            promptManager.GetComponent<PromptManager>().NewPrompt();
        }
    }

    public void GameWinCheck(int recievedTurnsValue)
    {
        if(recievedTurnsValue >= 10)
        {
            SceneManager.LoadScene("Win");
        }
    }


    //------------------------------------------------------------------------
    //Change Gator Model
    public void GatorChange()
    {
        if(HappinessCounter.happinessAmount <= 30 && EnergyCounter.energyAmount >= 10)
        {
            gator1.SetActive(false);
            gator2.SetActive(true);
            gator3.SetActive(false);
        } else {
            gator1.SetActive(true);
            gator2.SetActive(false);
            gator3.SetActive(false);
        }


        if (EnergyCounter.energyAmount <= 10)
        {
            gator1.SetActive(false);
            gator2.SetActive(false);
            gator3.SetActive(true);
            light1.SetActive(false);
            light2.SetActive(false);
        } else {
            gator1.SetActive(true);
            gator2.SetActive(false);
            gator3.SetActive(false);
            light1.SetActive(true);
            light2.SetActive(true);
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












    //Unused code placed at bottom to be out of the way


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