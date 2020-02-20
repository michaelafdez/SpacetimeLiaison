using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{

    //dialogue stuff
    public string[] dLines;
    public int currentLine;
    public Text dText, buttonText;
    public float lineTime;
    public Button TalkButton;
    public Slider responseTimer;
    public bool hasReplied;
    public float timer;

    //food stuff
    public bool isChowing;

    // Start is called before the first frame update
    void Start()
    {
        currentLine = -1;

        hasReplied = true;

        isChowing = false;

        TalkButton.gameObject.SetActive(false);
        responseTimer.gameObject.SetActive(false);

        StartCoroutine("TextProgress");
    }

    // Update is called once per frame
    void Update()
    {
        if (responseTimer.isActiveAndEnabled)
        {
            timer -= Time.deltaTime;
            responseTimer.value = timer / lineTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DateReaction();
            }
        }

    }

    private IEnumerator TextProgress()
    {
        while (currentLine < dLines.Length)
        {

            if (currentLine == 23 || currentLine == 25 || currentLine == 26)
            {
                break;
            }

            //checks hasReplied, adds to dialogue
            if (hasReplied)
                currentLine++;
            else if (!hasReplied)
            {
                //skips dialogue if hasReplied is false
                switch (currentLine)
                {
                    case 1:
                    case 5:
                        currentLine = 10;
                        break;
                    case 11:
                    case 15:
                        currentLine = 23;
                        break;
                }
            }

            //text is set to currentLine text, date progress is tracked
                dText.text = dLines[currentLine];

            //sets button to true, hasReplied to false during questions
            Reply();

            //repeats coroutine after lineTime seconds
            yield return new WaitForSeconds(lineTime);
        }


    }

    void Reply()
    {
        switch (currentLine)
        {
            case 1:
                buttonText.text = "That's quite an entry";
                break;
            case 5:
                buttonText.text = "Yikes, that sounds annoying.";
                break;
            case 11:
                buttonText.text = "Tell me about yourself. ";
                break;
            case 15:
                buttonText.text = "I’m sure you go through a lot of stress.";
                break;
        }

        switch (currentLine)
        {
            case 1:
            case 5:
            case 11:
            case 15:
                TalkButton.gameObject.SetActive(true);
                responseTimer.gameObject.SetActive(true);
                responseTimer.value = 1;
                timer = lineTime;
                hasReplied = false;
                break;
            default:
                TalkButton.gameObject.SetActive(false);
                responseTimer.gameObject.SetActive(false);
                hasReplied = true;
                break;
        }
    }

    public void DateReaction()
    {
        hasReplied = true;

        //lose state
        if (isChowing)
            currentLine = 24;

        StopCoroutine("TextProgress");
        StartCoroutine("TextProgress");
    }

    public void Chewing()
    {
        isChowing = true;
    }

    public void StopChewing()
    {
        isChowing = false;
    }

    /*
    public void StartGame()
    {
        StartCoroutine("TextProgress");
        StartButton.gameObject.SetActive(false);
    }
    */

}
