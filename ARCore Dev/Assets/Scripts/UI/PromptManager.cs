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
       
        storyPrompts.Add("Water pipelines across the city have burst under the pressure of the growth and development of Greentide. The people are demanding a quick fix to the flooding. However, the flooding will continue to occur unless there is an infrastructure overhaul to the pipelines. The updates to the infrastructure will take longer than fixing the pipes."); //prompt 1
        storyPrompts.Add("The main power plant has failed. Currently, many citizens are without power. Fixing it will take time and be expensive. "); //prompt 2
        storyPrompts.Add("With all the new people moving into the city housing prices have skyrocketed. Citizens are demanding intervention."); //prompt 3
        storyPrompts.Add("The city is looking for new ways to bring in more food to feed the people. The forests on the island outside of the city would be good land for agriculture. However, the Greentide would lose some of its natural splendor."); //prompt 4
        storyPrompts.Add("The city is currently overfishing in the waters off the island of Greentide. If this continues the local ecosystem will be damaged but it may be more difficult to feed the people of Greentide."); //prompt 5
        storyPrompts.Add("The city is affected by famine. Farmers surrounding the city had a poor harvest and were unable to supply enough food to feed the people. Rationing food will be necessary to support the population but it will be unpopular and take energy."); //prompt 6
        storyPrompts.Add("The labor force in Greentide is on strike and demanding the local government step in and legislate more protections for workers. More protections would benefit the city and its people but it would require energy to implement the new policies."); //prompt 7
        storyPrompts.Add("The city desires new entertainment venues. It would make the population happy to build a stadium and concert venue but it would be costly."); //prompt 8
        storyPrompts.Add("Greentide is spending too many resources on programs and initiatives. Cutting back would return some resources but it would come at the expense of the city."); //prompt 9
        storyPrompts.Add("The line at the DMV is crazy long and the citizens are not happy!"); //prompt 10
        storyPrompts.Add("The homeless population of Greentide dont have enough resources and are unable to feed themselves. It will be costly to open kitchens to feed them but it will improve their lives and in turn the city."); //prompt 11
        storyPrompts.Add("The city desires more public spaces. It would make the population happy to build new parks but it would be costly."); //prompt 12
        NewPrompt();
        
    }

    void NewPrompt()
    {
        promptIndex = Random.Range(0, storyPrompts.Count);
        prompt = prompt.GetComponent<TMP_Text>();
        prompt.text = storyPrompts[promptIndex];
        storyPrompts.Remove(storyPrompts[promptIndex]);
        promptIndex += 1;
        UpdateButtons();
    }

    void UpdateButtons ()
    {
        switch (promptIndex)
        {
        case 12:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "We Dont Have Enough Resources (Happiness Decreases)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Build Parks (Happiness Increases, Energy Decreases, Society Meter Goes Up)";
            break;
        case 11:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Open Kitchens to Feed Homeless (Food and Energy Decreases, Society Meter Goes Up)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Make No Change (Happiness Goes Down)";
            break;
        case 10:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Improve System and Training to Make Wait Time Shorter (Energy Decreases, Society Meter Goes Up)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Make No Change (Society Meter Goes Down)";
            break;
        case 9:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Cut Back Expenses (Food and Energy Increases, Society Meter Goes Down)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Make No Change (Society Meter Goes Up)";
            break;
        case 8:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "We Dont Have Enough Resources (Happiness Decreases)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Build Stadium and Concert Arena (Happiness Increases, Energy Decreases, Society Meter Goes Up)";
            break;
        case 7:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Legislate More Worker Protections (Energy Decrease, Society Meter Goes Up)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Make No Change (Society Meter Goes Down)";
            break;
        case 6:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Make No Change (Society Meter Goes Down)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Ration Food Supply (Happiness and Energy Decrease)";
            break;
        case 5:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Make No Change (Happiness Decreases)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Implement New Fishing Policies (Food Decreases, Society Meter Goes Up)";
            break;
        case 4:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Cut Forests Down For New Agriculture (Food and Energy Increases)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Leave Forests (Society Meter Goes Up)";
            break;
        case 3:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Implement Rent Control and Housing Subsidies (Energy Decrease, Society Meter Goes Up)";
            choice2 = buttonText2.GetComponent<Text>();
            choice2.text = "Leave Market Alone (Society Meter Goes Down)";
            break;
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
        switch (promptIndex)
        {
        case 12:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        case 11:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            break;
        case 10:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            break;
        case 9:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        case 8:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        case 7:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            break;
        case 6:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            break;
        case 5:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        case 4:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            break;
        case 3:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            break;
        case 2:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -1f;
            }
            break;
        case 1:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 1f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
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
