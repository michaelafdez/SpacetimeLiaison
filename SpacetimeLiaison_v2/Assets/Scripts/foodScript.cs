using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{
    public GameObject remains;
    public GameObject remains2;
    public GameObject remainsForMini;
    
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Food")
        {
            Vector3 clone1Transform = new Vector3 (other.transform.position.x + 0.275f,other.transform.position.y + 0.075f,other.transform.position.z - 0.1f);
            Vector3 clone2Transform = new Vector3 (clone1Transform.x - 0.325f,clone1Transform.y,clone1Transform.z);
            GameObject clone =  Instantiate(remains, clone1Transform, other.transform.rotation) as GameObject;
            GameObject clone2 = Instantiate(remains2, clone2Transform, other.transform.rotation) as GameObject;
            //Transform children = clone.transform.root.GetComponentInChildren<Transform>();
            // GameObject clone2 = Instantiate(remains, other.transform.position + new Vector3 (clone.transform.position.x,clone.transform.position.y,clone.transform.position.z) , other.transform.rotation) as GameObject;
            // Vector3 children2 = new Vector3 (clone.transform.position.x - 5,clone.transform.position.y,clone.transform.position.z);
            //Transform children2 = clone2.transform.root.GetComponentInChildren<Transform>();
            //foreach (Transform child in children)
            // {
            //    child.gameObject.AddComponent<forkRaycast>();
            //  }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "MiniFood")
        {
            Transform children = other.transform.root.GetComponentInChildren<Transform>();
            GameObject miniBoy = Instantiate(remainsForMini, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(other.gameObject);
        }
    }
}
