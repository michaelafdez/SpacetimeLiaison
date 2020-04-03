using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handScript : MonoBehaviour
{

    private Rigidbody thisRigid;

    public float mouseX, mouseY;
    public string mouseXInput, mouseYInput;

    public float sensitivity, smoothing, innerEdge;

    Vector3 smoother;

    private RaycastHit hit;

    int layerMask = 1 << 8;

    float rayDistance = 5;

    public bool isHolding, atFace, holdingFork, isRotating;

    public GameObject pickUpPoint;

    public pickerUpper pickerUpper;

    public Image theReticle;

    // Start is called before the first frame update
    void Start()
    {
        thisRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        mouseX = Input.GetAxis(mouseXInput) * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInput) * sensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.R))
            isRotating = true;
        else
            isRotating = false;

            Debug.DrawRay(transform.position, -transform.up, Color.magenta);

       

        if (Physics.Raycast(transform.position, -transform.up, out hit, rayDistance, layerMask))
        {
            if (Input.GetMouseButtonDown(0) && isHolding == false)
            {
                hit.transform.position = pickUpPoint.transform.position;
                isHolding = true;

            }
            else if (Input.GetMouseButtonDown(0) && isHolding == true)
            {
                //atFace = false;
                pickerUpper.Release();
                // StopCoroutine("NowHolding");
                //canScroll = false;
                isHolding = false;
                //pickUpPoint.transform.localPosition = Vector3.forward;
                //isRotating = false;
            }

            if (!atFace)
            {
                theReticle.color = new Color(180, 170, 0, 100);
            }
            else
            {
                theReticle.color = new Color(0, 50, 220, 100);
            }

            if (isHolding && hit.transform.CompareTag("Fork"))
                holdingFork = true;
            else
                holdingFork = false;
        }

        if (transform.localPosition.z <= 1.75f)
            atFace = true;
        else
        {
            atFace = false;
            //theReticle.color = new Color(0, 0, 0, 100);
        }
    }

    private void FixedUpdate()
    {
        if (isRotating)
            ObjectRotation();
        else
            HandMovement();
    }

    //moves hand according to mouse movement
    void HandMovement()
    {

        smoother.x = Mathf.Lerp(smoother.x, mouseX, 1f / smoothing);
        smoother.z = Mathf.Lerp(smoother.z, mouseY, 1f / smoothing);
        smoother.y = thisRigid.velocity.y;

        thisRigid.velocity = smoother;
    }

    void ObjectRotation()
    {

        //thisRigid.velocity = Vector3.zero;

        if (isHolding)
        {
            //hit.transform.Rotate(Vector3.up * mouseX);
            //hit.transform.Rotate(Vector3.left * mouseY);
            pickUpPoint.transform.Rotate(Vector3.up * mouseY);
            pickUpPoint.transform.Rotate(Vector3.right * mouseX);
        }

    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Face"))
            atFace = true;
        else
        {
            atFace = false;
            theReticle.color = new Color(0, 0, 0, 100);
        }
    }
    */
}
