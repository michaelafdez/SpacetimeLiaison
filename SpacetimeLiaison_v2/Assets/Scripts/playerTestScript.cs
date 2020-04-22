using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTestScript : MonoBehaviour
{

    public Fungus.Flowchart mainFlow, subFlow;

    public List<Fungus.Block> currentLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentLine = mainFlow.GetExecutingBlocks();

            //keep working here
        }
    }
}
