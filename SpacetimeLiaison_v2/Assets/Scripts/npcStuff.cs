using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcStuff : MonoBehaviour
{
    int theNumber;
    Animator theMator;
    // Start is called before the first frame update
    void Start()
    {
        theMator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void TalkAgain()
    {
        theNumber = Random.Range(1, 5);
        if (theNumber == 3)
        {
            theMator.SetBool("canTalk",true);
        }
    }
    public void TalkReset()
    {
        theMator.SetBool("canTalk", false);
    }
}
