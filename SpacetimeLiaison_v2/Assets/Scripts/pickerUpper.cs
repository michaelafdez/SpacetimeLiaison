using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickerUpper : MonoBehaviour
{
    public Rigidbody otherRigid;
    public bool onObject = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            otherRigid.isKinematic = true;
            other.transform.parent = this.transform;
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

            onObject = false;
        }
    }


}
