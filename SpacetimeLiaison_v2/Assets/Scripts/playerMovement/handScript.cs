using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScript : MonoBehaviour
{

    private Rigidbody thisRigid;

    public float mouseX, mouseY;
    public string mouseXInput, mouseYInput;

    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        thisRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseX = Input.GetAxis(mouseXInput) * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInput) * sensitivity * Time.deltaTime;

        thisRigid.velocity = new Vector3(mouseX, thisRigid.velocity.y, mouseY);
    }
}
