using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PromptManager : MonoBehaviour


{

    public List<string> storyPrompts; 
    public TMP_Text prompt;
    private Text choice1;
    private Text choice2;
    public GameObject buttonText1;
    public GameObject buttonText2;

    // Start is called before the first frame update
    void Start()
    {
       
        storyPrompts[0] = "prompt";
        storyPrompts[1] = "prompt2";
        NewPrompt();
        
    }

    void NewPrompt()
    {
        // choice = HpText.GetComponent<Text>();
        // choice.text = PlayerStats.PlayerHealth + "/hp";
        
        int promptIndex = Random.Range(0, storyPrompts.Count - 1);
        prompt = GetComponent<TMP_Text>();
        prompt.text = storyPrompts[promptIndex];
        storyPrompts.Remove(storyPrompts[promptIndex]);
        UpdateButtons(promptIndex);
    }

    void UpdateButtons (int promptIndex)
    {
        promptIndex += 1;

        switch (promptIndex)
        {
        case 2:
            choice1 = buttonText1.GetComponent<Text>();
            choice1.text = "Fix It (Significant Energy Decrease)";
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
    }
