using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YDelete : MonoBehaviour
{
    float PY;
    Camera cam;

    void Start()
    {
        PY = transform.position.y;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < PY - 10 || transform.position.z < cam.transform.position.z) 
            Destroy(gameObject);
    }
}
