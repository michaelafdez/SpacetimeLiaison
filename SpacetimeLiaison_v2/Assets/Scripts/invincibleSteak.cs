using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleSteak : MonoBehaviour
{
    // Start is called before the first frame update
   public  void Start()
    {
        Invoke("Invincible", 1);
    }

    void Invincible ()
    {
        this.gameObject.tag = "MiniFood";
    }
}
