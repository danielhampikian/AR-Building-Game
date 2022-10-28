using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
The main comment I have on this code as far as improving the archetecture is
To make a seperate class for Prompts that hold the narrative, the choices, and the
consequences for each meter.  This way you can auto generate prompts that requuire only 
a slight change in the wording to give the player more flexibilty and choice, and 
when future developers wnt to add to the game, they only have to fill out the 
prototype for a prompt class so the code will be easier to maintain and add to over time

Here's what I mean:

//First have a class that holds static getters and setters to the resources so the other classes 
//are forced to change data in a way that makes sense to update if you add another resource in 
// the future you can do so flexibly and easily and we force the intialization to hold both a name that won't be changed once intialize and a value amount that 
//


public static class Resource{

    public static string ResourceName;
    public static int ResourceAmt {get; set;} 

    public Resource(string resourceName, int resourceValue) {
        ResourceName = resourceName;
        ResourceAmt = resourceValue;
    }
}

public class Resources {
    public Resources resourcesSingleton;
    public int numOfResources;
    public int [] initialResourceVal;
    public string[] resourceNames;
    public static Resource[] resources {get; set;}
    public static Resources() {
            if (resourcesSingleton != null) {
                resorucesSingletone = null;
            }
            resourcesSingleton = this;

            //now we have a single instance of all our resource values
            //accessable from anywhere in our classes with getter sna setters

            //we initialize like this if we had one rosource, if we had more we can just add them to the array in teh editor
            numOfResources = 1; //for example if we only had one, this can change
            //assue the int and string array ar intiailzed to reflect this
            resources = new Resource[numOfResources];
            for (int i = 0; i < resource.Count; i ++) {
                resoruces[i].set(new Resource("Happiness" //which would be resourceNames[0] 
                ,0 //which would be intialResourceVal[0]
                //and so on for the full array of names and values which can now be set in the editor
                 ));
            }
    }
}
public class Prompt {

    public string promptText;
    public int numOfPossibleChoices;
    public Dictionary choiceAndConsequenceDict;
    public Dictionary consuenceTextAndResourceValues;

    public Prompt(string promptT, Dictionary choicCons<string s, Dictionary consToResource<string text, int[] resourceChangeValues>>) {
        //now when you make a prompt you create a dictionary of the choice to the choice textual consequemce, 
        // and use that text as a key for the second dictionary which will be from the text conseuquence to the 
        // int amount for each resource that you will change.

        //I think that setting up the data structues liek this so that you change the reosurces 
        //as a single peice of code that is accessed via the resourceSingleon with a structure like this:
        /*
            {choice text (the first key in the dictionary): 
                consequence of choice text (the first vale and the second key to the
                second dictionary that leads to the numerical changes) : 
                    int[] value changes to resources (the final value of the second layer of the dictionary) that would look like [1-,0,-10,0] for four resources 
            }

            //if you have any questions about how to implement let me know, I'l comment out the classes above so it doesn't break your code

    }


/*The advantage of doing it this way is not only does the structure of the code garuntee flexibility and standardzied ways of accessing
the resources and choices rather than indexing parrallel lists which is fragile for a larger game, but that now we can do ethings like put
variable string to string to numerical value conseuqences in the prompt class so that if we change the term "noun that is the thing we are to invest in or not invest in"
and the parrallel int [] values to draw from a randomized list, then we have actual variation in the path's the game can take that are potentially infite and repeating only 
after long gameplay times noticable to the player.  Invest in staduim or library becomes then invest in a randomized choice of ----> 
[array of words that you might invest in and coressponding int array of consewuences these terms have on resources]
    
}

*/

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

    public void NewPrompt()
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
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;

                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += -30;
                }
            }
            break;
        case 11:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 10) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += 10;

                    buildingManager.GetComponent<BuildingManager>().buildingX += .2f;
                    buildingManager.GetComponent<BuildingManager>().buildingZ += .2f;
                }
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            break;
        case 10:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += 30;

                    buildingManager.GetComponent<BuildingManager>().buildingX += .2f;
                    buildingManager.GetComponent<BuildingManager>().buildingZ += .2f;
                }
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            break;
        case 9:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);

                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;

                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += -30;
                }

            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 10) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += 10;
                    
                    buildingManager.GetComponent<BuildingManager>().buildingX += .2f;
                    buildingManager.GetComponent<BuildingManager>().buildingZ += .2f;
                }
            }
            break;
        case 8:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += 30;
                }
            }
            break;
        case 7:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += -30;
                }
            }
            break;
        case 6:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            break;
        case 5:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += -30;

                    buildingManager.GetComponent<BuildingManager>().buildingX += -.1f;
                    buildingManager.GetComponent<BuildingManager>().buildingZ += -.1f;
                }
            }
            break;
        case 4:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeFoodValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 10) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += 10;
                }
            }
            break;
        case 3:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
                buildingManager.GetComponent<BuildingManager>().buildingX += -.1f;
                buildingManager.GetComponent<BuildingManager>().buildingZ += -.1f;
            }
            break;
        case 2:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(-10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += -.4f;
                if (buildingManager.GetComponent<BuildingManager>().numOfBuildings >= 30) {
                    buildingManager.GetComponent<BuildingManager>().numOfBuildings += -30;
                    buildingManager.GetComponent<BuildingManager>().buildingX += -.1f;
                    buildingManager.GetComponent<BuildingManager>().buildingZ += -.1f;
                }
            }
            break;
        case 1:
            if (option == 1)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeHappinessValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
            }
            else if (option == 2)
            {
                resourceManager.GetComponent<ResourceManagerScript>().ChangeEnergyValue(-10);
                resourceManager.GetComponent<ResourceManagerScript>().ChangeSocietyValue(10);
                buildingManager.GetComponent<BuildingManager>().buildingHeight += 0.4f;
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
