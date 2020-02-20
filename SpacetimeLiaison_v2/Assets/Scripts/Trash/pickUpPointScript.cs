using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpPointScript : MonoBehaviour
{

    //distance of raycast
    public float rayDistance, smoothing, scrollDirection;

    public int outerEdge, innerEdge;

    Vector3 thisPosition;
    
    //what the ray is hitting
    RaycastHit hit;

    public string hitTag;

    public bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.DrawRay(this.transform.position, this.transform.forward * rayDistance, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, rayDistance))
        {
            hitTag = hit.transform.tag;

            if (hitTag == "Interactable" && Input.GetMouseButton(0))
                PickUp();
            else if (hitTag == "Interactable" && Input.GetMouseButtonUp(0))
                Release();
        }
        */

        //scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        

    }

    /*
    IEnumerator ObjectHeld()
    {
        
        //this does the same thing apparently
        while (isHolding)
        {
            if (hit.rigidbody != null)
            {
                if (hit.rigidbody.useGravity && !hit.rigidbody.isKinematic)
                {
                    hit.rigidbody.useGravity = false;
                    hit.rigidbody.isKinematic = true;
                }

                //position of object held = position of pickUpPoint
                hit.transform.position = rayEnd;

                Debug.Log(isHolding);

                if (Input.GetMouseButtonDown(1))
                {
                    Release();
                }
                yield return null;
            }
            else
            {
                Release();
                break;
            }
            
        }
        
}
*/

    void PickUp()
    {
        if (hit.rigidbody.useGravity && !hit.rigidbody.isKinematic)
        {
            hit.rigidbody.useGravity = false;
            hit.rigidbody.isKinematic = true;
        }

        //position of object held = position of pickUpPoint
        //hit.transform.position = this.transform.position;
        //hit.transform.position = Vector3.Lerp(hit.transform.position, rayEnd, Time.deltaTime * smoothing);

        this.transform.position = hit.transform.position;

        hit.transform.parent = this.transform;

        ScrollItem();
    }

    void ScrollItem()
    {
        if (scrollDirection > 0f && this.transform.localPosition.z < outerEdge)
        {
            thisPosition = this.transform.localPosition;
            thisPosition[2] += 0.5f;
            this.transform.localPosition = thisPosition;
        }
        else if (scrollDirection < 0f && this.transform.localPosition.z > innerEdge)
        {
            thisPosition = this.transform.localPosition;
            thisPosition[2] -= 0.5f;
            this.transform.localPosition = thisPosition;
        }
    }

    void Release()
    {
        //if (hitTag == "Interactable")
        //{
            hit.rigidbody.useGravity = true;
            hit.rigidbody.isKinematic = false;
            hit.transform.parent = null;
            hit.rigidbody.AddRelativeForce(hit.rigidbody.velocity.normalized * Time.deltaTime * 4f);

            this.transform.localPosition = Vector3.forward;
        //}

    }

}
