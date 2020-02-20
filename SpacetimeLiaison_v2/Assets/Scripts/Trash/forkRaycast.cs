using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkRaycast : MonoBehaviour
{
    public Transform handSpot;
    GameObject player;
    Rigidbody myRigid;
    public Vector3 myRotate;
	

    // Start is called before the first frame update
    void Start()
    {
		
        myRotate = new Vector3 (myRotate.x, myRotate.y, myRotate.z);
        player = GameObject.Find("Player");
        myRigid = GetComponent<Rigidbody>();
        handSpot = player.transform.Find("PlayerCamera").transform.Find("PickUpPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
		

    }

    void OnMouseDown()
    {
        myRigid.useGravity = false;
        myRigid.isKinematic = true;
        //this.transform.position = handSpot.transform.position;
        //handSpot.transform.eulerAngles = myRotate;
        this.transform.eulerAngles = myRotate;
        handSpot.transform.rotation = this.transform.rotation;  
        this.transform.parent = player.transform.Find("PlayerCamera").transform.Find("PickUpPoint").transform;
		


    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        myRigid.useGravity = true;
        myRigid.isKinematic = false;
		
    }




}
