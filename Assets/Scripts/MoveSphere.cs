using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveSphere : MonoBehaviour 
{
    [SerializeField]
    public float speed = 5;

    [SerializeField]
    public float minX, maxX;

    [SerializeField]
    MeshDestroy Md;
 

     private float mY, mX;
    
    private Rigidbody rb;
    private Vector3 moveVelocity;
    private CharacterController Character;

    float speedClone;
     
    // Start is called before the first frame update
    void Start()
    {
         
        rb = GetComponent<Rigidbody>();
        Character = GetComponent<CharacterController>();


        mX = Camera.main.scaledPixelWidth / 2;
        mY = Camera.main.scaledPixelHeight / 4.5f;

        speedClone = speed;

    }
     

   // Update is called once per frame
    void Update()
    {
       moveVelocity = Vector3.zero;
        // moveVelocity.y = rb.velocity.y;

        if (Input.GetMouseButton(0))
        {

            if ((Input.mousePosition.x - mX) / mX > 0)
                moveVelocity.x = 1;
            else if ((Input.mousePosition.x - mX) / mX < 0)
                moveVelocity.x = -1;
            else moveVelocity.x = 0;


            moveVelocity.z = (Input.mousePosition.y - mY) / mY;

            if ((transform.position.x <= minX && moveVelocity.x < 0) || (transform.position.x >= maxX && moveVelocity.x > 0))
                moveVelocity.x = 0;



        }

        if (transform.position.z <= Camera.main.transform.position.z + 6)
        {
            speed += 0.5f;
            if (moveVelocity.z < 0)
                moveVelocity.z = 0;
        }
        else if (moveVelocity.z > 0 && transform.position.z >= Camera.main.transform.position.z + 20)
            moveVelocity.z = 0;
        else speed = speedClone;
    }

    void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        rb.velocity = ((Vector3.forward + moveVelocity) * speed);
        // rb.velocity=((Vector3.forward + moveVelocity) * speed * Time.deltaTime);
        //Character.Move((Vector3.forward + moveVelocity) * speed * Time.fixedDeltaTime);
    }


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<MeshRenderer>().materials[0].color != GetComponent<MeshRenderer>().materials[0].color)  
        {
            Md.DestroyMesh();
            PlayerManager.gameOver = true;
            //Time.timeScale = 0.5f;
        }
        if(collision.gameObject.tag=="finish")
        {
            PlayerManager.isGameFinished = true;
        }

 
    }
     
    [ContextMenu("Play")]
    public void Play() 
    {
        Time.timeScale = 1;
    }

}
