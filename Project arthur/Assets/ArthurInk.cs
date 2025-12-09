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
    public AudioClip[] bgm;
    public AudioSource source;
    private AudioClip currentMusicClip; // Track the current music clip



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

        // Update music based on Ink variables
        UpdateMusic();

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

    //Update Music based on Ink variables
    void UpdateMusic() {

        bool sword = (bool)story.variablesState["sword"];
        bool tavern = (bool)story.variablesState["tavern"];
        bool grounds = (bool)story.variablesState["grounds"];
        bool road = (bool)story.variablesState["road"];
        bool hearth = (bool)story.variablesState["hearth"];
        bool field = (bool)story.variablesState["field"];

        AudioClip newClip = null;
        float newVolume = 1f;

        if (sword) {
            newClip = bgm[3];
            newVolume = 1f;
        }
        else if (tavern) {
            newClip = bgm[2];
            newVolume = .25f;
        }
        else if (grounds) {
            newClip = bgm[2];
            newVolume = 1f;
        }
        else if (road) {
            newClip = bgm[1];
            newVolume = 1f;
        }
        else if (hearth) {
            newClip = bgm[1];
            newVolume = 1f;
        }
        else if (field) {
            newClip = bgm[0];
            newVolume = 1f;
        }

        // Only change the clip if it's different from the current one
        if (newClip != null && newClip != currentMusicClip) {
            currentMusicClip = newClip;
            source.clip = newClip;
            source.volume = newVolume;
            source.Play();
        }
        else if (newClip != null && source.volume != newVolume) {
            // Update volume if clip is same but volume changed
            source.volume = newVolume;
        }
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
