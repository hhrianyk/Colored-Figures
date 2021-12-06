using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapTo : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Cube"|| collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = null;
            collision.gameObject.GetComponent<MeshRenderer>().material=GetComponent<MeshRenderer>().material;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Cube" || collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<MeshRenderer>().material = null;
    //        collision.gameObject.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
    //    }
    //}
}

