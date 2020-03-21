using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{

    textParser parser;

    public string dialogue, characterName;
    public int lineNum;
    string[] options;
    public bool playerTalking;
    //List<Button> buttons = new List<Button> ();

    public Text dialogueBox;
    public Text nameBox;
    public GameObject choiceBox;


    // Start is called before the first frame update
    void Start()
    {
        dialogue = "";
        characterName = "";
        parser = GameObject.Find("DialogueParser").GetComponent<textParser>();
        lineNum = 0;
        playerTalking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
        lineNum++;
        UpdateUI();
    }

   public void ShowDialogue()
    {
        ParseLine();
    }

    void ParseLine()
    {
        if (parser.GetName (lineNum) != "Player")
        {
            playerTalking = false;
            characterName = parser.GetName(lineNum);
            dialogue = parser.GetContent(lineNum);
        } else
        {
            playerTalking = true;
            options = parser.GetOptions(lineNum);
            CreateButtons();
        }
    }

    void CreateButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //GameObject button = (GameObject)Instantiate(choiceBox);
            // Button b = button.GetComponent<Button>();
            //ChoiceButton cb = button.GetComponent<ChoiceButton>();

        }
    }

    void UpdateUI()
    {

    }

    void ClearButtons()
    {

    }

}
