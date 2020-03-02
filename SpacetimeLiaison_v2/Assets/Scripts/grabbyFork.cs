﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabbyFork : MonoBehaviour
{
    public bool isHolding;
	public bool chewing;
	int chewTimer;
	public GameObject indicator;
	public Image indicatorImage;

    public GameObject dialogueManager;

    public int currentBits, bitsMax;

    public cameraController camControl;

   public bool isDirty;
   public float crumbValue;
   public float crumbMax;

    public bool isDrinking = false;

    public AudioSource SipSound, BiteSound;

    public Slider chewMeter;
    public float chewSpeed, biteAmount, dirtyMax;

	public static float dirtyTimer;

	public static int dirtyNoise;
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
                cameraController.strikes++;
              //  Debug.Log(cameraController.strikes);
                dirtyTimer = 0;
				dirtyNoise++;
            }
        }

        //eating food
        //used to check if chewing was false
        if (Input.GetMouseButtonDown(1) && camControl.atFace == true && isHolding == true && chewMeter.value < 0.9f && camControl.holdingFork)
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
        if (Input.GetMouseButtonDown(1) && chewing && camControl.atFace && camControl.holdingGlass && !isDrinking)
        {
            Debug.Log("Drink");
            isDrinking = true;
            SipSound.Play();
        }

        /*
        if (chewing) {

            if (!isDrinking)
                chewTimer++;
            else
                chewTimer += 2;

            if (chewTimer >= 150) {
				indicatorImage.color = new Color (200, 255, 0);
			}
			if (chewTimer >= 300) {
				indicatorImage.color = new Color (0, 255, 0);
			}
			if (chewTimer >= 450) {
				indicator.SetActive (false);
				chewing = false;
                isDrinking = false;
            }

		} 
        */
		
    }

    public IEnumerator ChewingFood()
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

    public void crumbsPlusPlus()
    {
         if (crumbValue < crumbMax)
          {
             crumbValue += Random.Range(1.5f,3.0f);
             if (crumbValue >= crumbMax)
            {
                isDirty = true;
                crumbValue = 0;
            }
        }

    }

    public void OnTriggerStay(Collider collision)
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
    public void OnTriggerExit(Collider collision)
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
