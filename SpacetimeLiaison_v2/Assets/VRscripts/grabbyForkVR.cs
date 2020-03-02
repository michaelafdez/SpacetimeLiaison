using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabbyForkVR : grabbyFork
{

    

    // Start is called before the first frame update
    void Start()
    {
        crumbValue = 0;
        crumbMax = 6;
        chewing = false;
        indicator.SetActive(false);
        indicatorImage = indicator.GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (isDirty)
        {
            dirtyTimer++;
            if (dirtyTimer > dirtyMax)
            {
                dirtyTimer = 0;
                dirtyNoise++;
            }
        }
        //eating food
        //used to check if chewing was false
        if (Input.GetAxisRaw("Oculus_CrossPlatform_PrimaryHandTrigger") == 1 && isHolding == true && chewMeter.value < 0.9f && camControl.holdingFork)
        {

            chewMeter.value += biteAmount;

            if (!chewing)
            {
                StartCoroutine("ChewingFood");
                chewing = true;
            }

            isHolding = false;
            Destroy(GameObject.Find("gotFood"));
            //indicator.SetActive(true);
            crumbsPlusPlus();

            BiteSound.Play();

            //chewTimer = 0;
            //indicatorImage.color = new Color(255, 0, 0);

            currentBits++;

            if (currentBits >= bitsMax)
                Debug.Log("You Win");

        }

        //drinking water
        if (Input.GetAxisRaw("Oculus_CrossPlatform_PrimaryHandTrigger") == 1 && chewing && camControl.holdingGlass && !isDrinking)
        {
            Debug.Log("Drink");
            isDrinking = true;
            SipSound.Play();
        }

    }

    public new IEnumerator ChewingFood()
    {
        while (chewMeter.value > 0)
        {
            if (!isDrinking)
                chewMeter.value -= (chewSpeed * Time.deltaTime) * 2;
            else
                chewMeter.value -= (chewSpeed * Time.deltaTime) * 16;

            yield return null;
        }
        chewing = false;
        isDrinking = false;
    }

    public new void crumbsPlusPlus()
    {
        if (crumbValue < crumbMax)
        {
            crumbValue += Random.Range(1.5f, 3.0f);
            if (crumbValue >= crumbMax)
            {
                isDirty = true;
                crumbValue = 0;
            }
        }

    }

    public new void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "ForkInteract" && isHolding == false)
        {
            isHolding = true;
            collision.gameObject.name = ("gotFood");
            collision.GetComponent<Rigidbody>().useGravity = false;
            collision.GetComponent<Rigidbody>().isKinematic = true;
            collision.transform.position = this.transform.position;
            collision.transform.rotation = this.transform.rotation;
            collision.transform.parent = this.transform;
        }
    }
    public new void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "ForkInteract" == true)
        {
            isHolding = false;
            collision.gameObject.name = ("unGotFood");
            collision.GetComponent<Rigidbody>().useGravity = true;
            collision.GetComponent<Rigidbody>().isKinematic = false;
            collision.transform.parent = null;
        }
    }
}
