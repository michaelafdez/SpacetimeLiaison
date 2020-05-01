using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class cameraController : MonoBehaviour
{


    GameObject character;
    public GameObject pickUpPoint;

    Vector3 pickUpPos;

    public string mouseXInput, mouseYInput;
    public float sensitivity;

    //keeps record of amount of rotation applied to camera
    private float xAxisClamp;
    private float mouseX, mouseY;

    //variables for alternate method

    //keeps track of how much movement camera has made in total
    //Vector2 mouseLook;
    //smooths movement of camera
    //Vector2 smoothV;
    //public float smoothing;

    //raycast stuff
    public float rayDistance;
    RaycastHit boxHit;
    public RaycastHit hit;
    string hitTag;

    public float outerEdge, innerEdge;
    public float scrollDirection;

    public bool isHolding;
    public bool canScroll;
    public bool isRotating;

    MeshRenderer pickUpMesh;

    public bool atFace;

    public bool boxCasting;
    public Vector3 boxSize;

    int layerMask = 1 << 8;

    public GameObject[] waterDrops;
    public float fastMouse;
    public bool holdingGlass, hasWater, holdingFork;

    public Image theReticle;

    public pickerUpper pickerUpper;

    public static int strikes;

    private bool isPaused;

    public Slider mySlider;
    public Fungus.Flowchart myFlowchart, angryFlowchart;

    string theCurrentLine;

    public List<Fungus.Block> currentLine;

    private bool isAngry = false;
 

    void Start()
    {
        character = this.transform.parent.gameObject;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        xAxisClamp = 0f;

        pickUpMesh = pickUpPoint.gameObject.GetComponent<MeshRenderer>();
        pickUpMesh.enabled = false;

        hasWater = true;

    }

    void Update()
    {

        theCurrentLine = myFlowchart.GetStringVariable("CurrentLine");
        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            AngryDate();
        }
        */
        mySlider.value = myFlowchart.GetIntegerVariable("Attractiveness");

     // if (myFlowchart.GetBooleanVariable("ChoiceTime") && grabbyFork.chewing && Input.GetKeyDown(KeyCode.Space))
      //  {
      //      myFlowchart.SetBooleanVariable("MouthFull", true);
      //  }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }

        //Debug.Log(atFace);
        mouseX = Input.GetAxis(mouseXInput) * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis(mouseYInput) * sensitivity * Time.deltaTime;

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //SceneManager.LoadScene(0);
        }

        if (isHolding && pickUpPoint.transform.localPosition.z <= innerEdge)
        {
            atFace = true;

        }
        else
        {
            atFace = false;
            theReticle.color = new Color(0, 0, 0, 100);
        }


        if (!isRotating)
            CameraRotation();
        else
            ObjectRotation();

        Debug.DrawRay(this.transform.position, this.transform.forward * rayDistance, Color.magenta);


        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, rayDistance, layerMask))
        {
            //boxCasting = Physics.BoxCast(pickUpPoint.transform.position, hit.collider.bounds.extents, this.transform.forward, out boxHit, pickUpPoint.transform.rotation, rayDistance);
            //boxCasting = Physics.BoxCast(hit.transform.position, hit.transform.localScale, hit.transform.forward, out boxHit, pickUpPoint.transform.rotation, rayDistance);
            //Debug.Log(boxHit.collider.name);

            if (!atFace)
            {
                theReticle.color = new Color(180, 170, 0, 100);
            }
            else
            {
                theReticle.color = new Color(0, 50, 220, 100);
            }
            hitTag = hit.transform.tag;

            //holding R key changes mode to ObjectRotation
            if (isHolding)
            {
                if (Input.GetKey(KeyCode.R))
                    isRotating = true;
                else
                    isRotating = false;
            }

            if (Input.GetMouseButtonDown(0) && isHolding == false)
            {
                pickUpPoint.transform.position = hit.transform.position;

                //StartCoroutine("NowHolding");
                canScroll = true;
                isHolding = true;

            }
            else if (Input.GetMouseButtonDown(0) && isHolding == true)
            {
                atFace = false;
                pickerUpper.Release();
                // StopCoroutine("NowHolding");
                canScroll = false;
                isHolding = false;

                pickUpPoint.transform.localPosition = Vector3.zero;

                isRotating = false;
            }

            scrollDirection = Input.GetAxis("Mouse ScrollWheel");


            if (canScroll == true)
            {
                ScrollItem();
            }

            if (isHolding && hitTag == "Fork")
                holdingFork = true;
            else
                holdingFork = false;

            //sends message to drop water if mouse is too fast
            if (isHolding && hitTag == "Glass" && hasWater)
            {
                if (mouseX > fastMouse || mouseY > fastMouse)
                {
                    foreach (GameObject drop in waterDrops)
                    {
                        drop.GetComponent<waterScript>().WaterJump();
                    }
                }
                holdingGlass = true;

            }
            else
            {
                holdingGlass = false;
            }
        }
        else if (isHolding && mouseX < 0.01f && mouseY < 0.01f)
        {
            //if statement checks mouse movement because camera sometimes moves faster than raycast

            atFace = false;
            pickerUpper.Release();
            canScroll = false;
            isHolding = false;
            isRotating = false;

            //teleports pickUpPoint to inside player
            pickUpPoint.transform.localPosition = Vector3.zero;
        }


        if (!waterDrops[0].activeInHierarchy && !waterDrops[1].activeInHierarchy && !waterDrops[2].activeInHierarchy && !waterDrops[3].activeInHierarchy)
            hasWater = false;

        if (waterScript.noise >= 2)
        {
            AngryDate();
            waterScript.noise = 0;
            Debug.Log("Dropped water");
        }


    }

    private void AngryDate()
    {
        if (!isAngry)
        {
            isAngry = true;

            currentLine = myFlowchart.GetExecutingBlocks();

            //myFlowchart.stop

            //theCurrentLine = myFlowchart.SelectedBlock.BlockName;

            theCurrentLine = currentLine[0].BlockName;

            myFlowchart.SetStringVariable("CurrentLine", theCurrentLine);

            myFlowchart.StopBlock(theCurrentLine);

            myFlowchart.ExecuteBlock("Oops");

            Debug.Log(theCurrentLine);
        }
        
    }

    public void ResetDialogue()
    {
        //myFlowchart.ExecuteBlock(theCurrentLine);

        myFlowchart.ExecuteBlock(theCurrentLine);

        isAngry = false;
        //Debug.Log("Reset");
    }

   private void FixedUpdate()
    {
        /*
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, rayDistance, layerMask))
        {
            //boxCasting = Physics.BoxCast(pickUpPoint.transform.position, hit.collider.bounds.extents, this.transform.forward, out boxHit, pickUpPoint.transform.rotation, rayDistance);
            //boxCasting = Physics.BoxCast(hit.transform.position, hit.transform.localScale, hit.transform.forward, out boxHit, pickUpPoint.transform.rotation, rayDistance);
            //Debug.Log(boxHit.collider.name);


            hitTag = hit.transform.tag;

            //holding R key changes mode to ObjectRotation
            if (isHolding)
            {
                if (Input.GetKey(KeyCode.R))
                    isRotating = true;
                else
                    isRotating = false;
            }

            if (Input.GetMouseButtonDown(0) && isHolding == false)
            {
                canScroll = true;
                isHolding = true;
                pickerUpper.GrabOn();

                hit.rigidbody.useGravity = false;
                hit.rigidbody.isKinematic = true;
                pickUpPoint.transform.position = hit.transform.position;
                hit.transform.parent = pickUpPoint.transform;
            }
            else if (Input.GetMouseButtonDown(0) && isHolding == true)
            {
                atFace = false;
                Release();
                canScroll = false;
            }

            scrollDirection = Input.GetAxis("Mouse ScrollWheel");

            if (isHolding)
            {
                pickUpMesh.enabled = true;
                //hit.transform.parent = this.transform;
            }


            if (canScroll == true)
            {
                ScrollItem();
            }


            //sends message to drop water if mouse is too fast
            if (isHolding && hitTag == "Glass" && hasWater)
            {
                if (mouseX > fastMouse || mouseY > fastMouse)
                {
                    foreach (GameObject drop in waterDrops)
                    {
                        drop.GetComponent<waterScript>().WaterJump();
                    }
                }
                holdingGlass = true;

            }
            else
            {
                holdingGlass = false;
            }
        }
        */
    }

    /*
    private void OnDrawGizmos()
    {
        if (boxCasting)
        {
            Gizmos.DrawWireCube(pickUpPoint.transform.position + this.transform.forward * boxHit.distance, hit.collider.bounds.extents);
            //Debug.Log("BoxHit Distance: "+boxHit.distance);
            //Debug.Log("Hit Distance: "+hit.distance);
        }
    }
    */

    void CameraRotation()
    {

        xAxisClamp += mouseY;

        if (xAxisClamp > 90f)
        {
            //clamps top rotation
            xAxisClamp = 90f;
            mouseY = 0f;
            ClampXAxisRotation(270f);
        }
        else if (xAxisClamp < -90f)
        {
            //clamps bottom rotation
            xAxisClamp = -90f;
            mouseY = 0f;
            ClampXAxisRotation(90f);
        }

        transform.Rotate(Vector3.left * mouseY);
        character.transform.Rotate(Vector3.up * mouseX);

    }

    //stops camera from exceeding clamp
    void ClampXAxisRotation(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    void ObjectRotation()
    {
        if (isHolding)
        {
            //hit.transform.Rotate(Vector3.up * mouseX);
            //hit.transform.Rotate(Vector3.left * mouseY);
            pickUpPoint.transform.Rotate(Vector3.down * mouseY);
            pickUpPoint.transform.Rotate(Vector3.right * mouseX);

        }

    }



    public void ScrollItem()
    {
        if (scrollDirection > 0f && pickUpPoint.transform.localPosition.z < outerEdge)
        {
            pickUpPos = pickUpPoint.transform.localPosition;
            pickUpPos[2] += 0.1f;
            pickUpPoint.transform.localPosition = pickUpPos;
        }
        else if (scrollDirection < 0f && pickUpPoint.transform.localPosition.z > innerEdge)
        {
            pickUpPos = pickUpPoint.transform.localPosition;
            pickUpPos[2] -= 0.1f;
            pickUpPoint.transform.localPosition = pickUpPos;
        }


    }

    public void Release()
    {
        isHolding = false;
        //if (hitTag == "Interactable")
        //{
        hit.rigidbody.useGravity = true;
        hit.rigidbody.isKinematic = false;
        hit.transform.parent = null;
        //hit.rigidbody.AddRelativeForce(hit.rigidbody.velocity.normalized * Time.deltaTime * 4f);
        //hit.rigidbody.AddForce(hit.rigidbody.velocity.normalized,)

        //boxCasting = false;

        pickUpMesh.enabled = false;
        //}


    }

}

