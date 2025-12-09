using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class ArthurInk : MonoBehaviour
{
    public TextAsset inkJSONAsset;
    private Story story;
    public Button buttonPrefab;
    public GameObject textPrefab;
    private bool canClickMouse = true;
    public GameObject[] bgs;



    // Start is called before the first frame update
    void Start()
    {

        // Load the next story block
        story = new Story(inkJSONAsset.text);

        refresh();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClickMouse)
        {
            ContinueStory();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ContinueStory()
    {
        if (story.currentChoices.Count == 0)
        {
            refresh();
        }
    }

    void refresh()
    {
        // Clear the UI
        clearUI();

        // Update background based on Ink variables
        UpdateBackground();

        // Instantiate a new text display
        GameObject storyTextObj = Instantiate(textPrefab) as GameObject;
        storyTextObj.transform.SetParent(this.transform, false);
        
        // Get the TextMeshProUGUI component (check children if not directly on this GameObject)
        TextMeshProUGUI textComponent = storyTextObj.GetComponent<TextMeshProUGUI>();
        textComponent.text = getNextStoryBlock();

        // Only show buttons if there are choices available
        if (story.currentChoices.Count > 0)
        {
            canClickMouse = false; // Disable mouse clicks when choices are available
            foreach (Choice choice in story.currentChoices)
            {
                Button choiceButton = Instantiate(buttonPrefab) as Button;
                choiceButton.transform.SetParent(this.transform, false);

                // Gets the text from the button prefab
                TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
                choiceText.text = choice.text;

                // Set listener
                choiceButton.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            canClickMouse = true; // Enable mouse clicks when no choices available
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }

    // Clear out all of the UI, calling Destory() in reverse
    void clearUI()
    {
        int childCount = this.transform.childCount;
        for (int i = childCount - 1; i >= 0; -- i)
        {
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        }
    }


    // Load and potentially return the next story block
    string getNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;
    }

    // Update background based on Ink variables
    void UpdateBackground()
    {
        

        bool sword = (bool)story.variablesState["sword"];
        bool tavern = (bool)story.variablesState["tavern"];
        bool grounds = (bool)story.variablesState["grounds"];
        bool road = (bool)story.variablesState["road"];
        bool hearth = (bool)story.variablesState["hearth"];
        bool field = (bool)story.variablesState["field"];

        GameObject swordbg = bgs[0];
        GameObject tavernbg = bgs[1];
        GameObject groundsbg = bgs[2];
        GameObject roadbg = bgs[3];
        GameObject hearthbg = bgs[4];
        GameObject fieldbg = bgs[5];
        // Deactivate all backgrounds first
        swordbg.SetActive(false);
        tavernbg.SetActive(false);
        groundsbg.SetActive(false);
        roadbg.SetActive(false);
        hearthbg.SetActive(false);
        fieldbg.SetActive(false);

        // Activate only the current background
        if (sword)
            swordbg.SetActive(true);
        else if (tavern)
            tavernbg.SetActive(true);
        else if (grounds)
            groundsbg.SetActive(true);
        else if (road)
            roadbg.SetActive(true);
        else if (hearth)
            hearthbg.SetActive(true);
        else if (field)
            fieldbg.SetActive(true);
    }
}
