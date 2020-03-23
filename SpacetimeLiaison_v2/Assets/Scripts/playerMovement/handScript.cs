using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScript : MonoBehaviour
{

    private Rigidbody thisRigid;

    public float mouseX, mouseY;
    public string mouseXInput, mouseYInput;

    public float sensitivity, smoothing;

    Vector3 smoother;

    private RaycastHit hit;

    int layerMask = 1 << 8;

    float rayDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        thisRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandMovement();

        Debug.DrawRay(transform.position, -transform.up, Color.magenta);

        if (Physics.Raycast(transform.position, -transform.up, out hit, rayDistance, layerMask))
        {
            Debug.Log("hit");
        }
    }

    //moves hand according to mouse movement
    void HandMovement()
    {
        mouseX = Input.GetAxis(mouseXInput) * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInput) * sensitivity * Time.deltaTime;

        smoother.x = Mathf.Lerp(smoother.x, mouseX, 1f / smoothing);
        smoother.z = Mathf.Lerp(smoother.z, mouseY, 1f / smoothing);
        smoother.y = thisRigid.velocity.y;

        thisRigid.velocity = smoother;
    }
}
