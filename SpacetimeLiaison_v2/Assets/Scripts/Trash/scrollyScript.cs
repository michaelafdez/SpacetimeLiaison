using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollyScript : MonoBehaviour
{
    public float scrollDirection;
    public int outerEdge;
    public int innerEdge;
    public Transform handPosition;
    public GameObject mainCam;
    public bool canScroll;
    public Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
       mainCam =  GameObject.Find("PlayerCamera");
        //thisPosition = GetComponent<forkRaycast>().handSpot.transform.position;
        
    }

    // Update is called once per frame
    private void Update()
    {
        camTransform = mainCam.transform;
        if (canScroll == true)
        {
            ScrollItem();
        }
        scrollDirection = Input.GetAxis("Mouse ScrollWheel");
    }
    void OnMouseDown()
    {
        canScroll = true;
    }
    private void OnMouseUp()
    {
        canScroll = false;
    }

    void ScrollItem()
    {
        
        if (scrollDirection > 0f && this.transform.position.z < outerEdge)
        {
            Debug.Log("scrolling activate");
            //this.transform.position += camTransform.position.z += 0.5;
        }
        if (scrollDirection < 0f && this.transform.position.z > innerEdge)
        {
            
            this.transform.position += (mainCam.transform.position += Vector3.back/2);
          
        }
    }
}
