using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class napkinClean : MonoBehaviour
{
    public cameraController camControl;
    public grabbyFork forkScript;

    public GameObject crumbFace;
    public bool withPoint;

    public handScript handScript;
    // Start is called before the first frame update
    void Start()
    {
        crumbFace.GetComponent<Image>().color = new Color (255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.gameObject.transform.position == camControl.pickUpPoint.transform.position)
        /*
        if (this.gameObject.transform.position == handScript.pickUpPoint.transform.position)
        {
            withPoint = true;
        } else
        {
            withPoint = false;
        }
        */
        if (withPoint == true && handScript.atFace == true && Input.GetMouseButtonDown(1))
        {
            forkScript.isDirty = false;
        }
        

        if (forkScript.isDirty == true)
        {
            crumbFace.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            
        } else
        {
            crumbFace.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            withPoint = true;
        } else
        {
            withPoint = false;
        }
    }
}
