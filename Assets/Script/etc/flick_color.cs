using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flick_color : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.StartsWith("Cube"))
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }
                }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.StartsWith("Cube"))
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
