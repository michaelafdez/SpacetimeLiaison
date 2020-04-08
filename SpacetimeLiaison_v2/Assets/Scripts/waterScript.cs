using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterScript : MonoBehaviour
{

    private Rigidbody thisRigid;
    private Vector3 jumpForce;
    private bool hasStruck;
    public int xzJump, yJump;
	public static int noise;
    // Start is called before the first frame update
    void Start()
    {
		noise = 0;
        thisRigid = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Water") 
            || other.gameObject.CompareTag("Glass") || other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Nothing");
        }
        else
        {
            if (!hasStruck)
            {
				noise++;
                //cameraController.strikes++;
            //    Debug.Log(cameraController.strikes);
                hasStruck = true;
            }
            if (hasStruck)
                gameObject.SetActive(false);
        }
    }

    public void WaterJump()
    {

        if (Random.value < 0.5f)
        {
            xzJump = 20;
            yJump = 90;
        } else
        {
            xzJump = -20;
            yJump = -90;
        }

        jumpForce = new Vector3(xzJump, yJump, xzJump);

        thisRigid.AddForce(jumpForce);
    }

    private void Update()
    {
        //Debug.Log(thisRigid.velocity);
    }
}
