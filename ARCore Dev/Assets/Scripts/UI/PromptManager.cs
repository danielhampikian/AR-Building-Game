using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PromptManager : MonoBehaviour


{
    public GameObject buildingManager;
    public GameObject resourceManager;
    public List<string> storyPrompts; 
    public TMP_Text prompt;
    private Text choice1;
    private Text choice2;
    public GameObject buttonText1;
    public GameObject buttonText2;
    private int promptIndex;

    // Start is called before the first frame update
    void Start()
    {
       
        storyPrompts.Add("prompt"); //prompt 1
        storyPrompts.Add("prompt2"); //prompt 2
        NewPrompt();
        
    }

    void NewPrompt()
    {
        Debug.Log(storyPrompts[0]);   
        Debug.Log(storyPrompts[1]);
        promptIndex = Random.Range(0, storyPrompts.Count);
        Debug.Log(promptIndex);
        prompt = prompt.GetComponent<TMP_Text>();
        prompt.text = storyPrompts[promptIndex];
        storyPrompts.Remove(storyPrompts[promptIndex]);
        UpdateButtons();
    }

    void UpdateButtons ()
    {
        promptIndex += 1;

        switch (promptIndex)
        {
        case 2:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Fix It (Energy Decrease)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "We Dont Have Enough Resources (Society Meter Goes Down)";
            break;
        case 1:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Fix Pipes (Happiness Increase)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Overhaul Water Infrastructure (Energy Decrease, Society Meter Goes Up)";
            break;
        default:
           choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "WHHHHHHHYYYYY";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "PLEASE GOD NO";
            break;
        }
    } 
    public void Consequenses (int option)
    {
        promptIndex += 1;

        switch (promptIndex)
        {
        case 2:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        case 1:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        default:
           choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "WHHHHHHHYYYYY";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "PLEASE GOD NO";
            break;
        }
    } 
}
