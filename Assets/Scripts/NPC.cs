using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
