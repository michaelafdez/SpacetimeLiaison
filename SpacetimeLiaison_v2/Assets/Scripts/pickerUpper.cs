using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickerUpper : MonoBehaviour
{
    public Rigidbody otherRigid;
    public bool onObject = false;

    private FixedJoint theJoint;

    // Start is called before the first frame update
    void Start()
    {
        theJoint = gameObject.GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && !onObject)
        {
            otherRigid = other.gameObject.GetComponent<Rigidbody>();

            otherRigid.useGravity = false;
            //otherRigid.isKinematic = true;
            other.transform.parent = this.transform;

            theJoint.connectedBody = otherRigid;

            onObject = true;
        }

    }

    public void Release()
    {
        if (otherRigid != null && onObject)
        {
            otherRigid.useGravity = true;
            otherRigid.isKinematic = false;
            otherRigid.transform.parent = null;

            theJoint.connectedBody = null;

            onObject = false;
        }
    }


}