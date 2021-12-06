using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private float thrust = 150f;
    [SerializeField] private float wallDistance = 5f;
    [SerializeField] private float minCamDistance = 3f;
    [SerializeField] MeshDestroy Md;

     private Rigidbody rb;
    private Vector2 lastMousePos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaPos = Vector2.zero;
        
        if (Input.GetMouseButton(0))
        {
            Vector2 CurrrentMousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
                lastMousePos = CurrrentMousePos;

            deltaPos = CurrrentMousePos - lastMousePos;
            lastMousePos = CurrrentMousePos;
             
            Vector3 toche = new Vector3(deltaPos.x, 0, deltaPos.y)*thrust;
            rb.velocity = toche * Time.deltaTime;
            //rb.AddForce (toche);
        }
        else
        {
            lastMousePos = Vector2.zero;
            rb.AddForce(Vector3.zero);
          //  rb.AddForce(Vector3.forward);
        }
        if (gameObject.layer == 9)
        {
            PlayerManager.gameOver = true;
            rb.velocity=(Vector3.down * 5);
        }
    }
 


    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if(transform.position.x<-wallDistance)
        {
            pos.x = -wallDistance;
        }
        else if(transform.position.x>wallDistance)
        {
            pos.x = wallDistance;
        }

        if (transform.position.z<Camera.main.transform.position.z+minCamDistance)
        {
            pos.z = Camera.main.transform.position.z + minCamDistance;
        }
        transform.position = pos;
    }


    public void OnCollisionEnter(Collision collision)
    {
         
        if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<MeshRenderer>().materials[0].color != GetComponent<MeshRenderer>().materials[0].color)
        {
            rb.velocity=(Vector3.forward * 100);
            Md.DestroyMesh();
            PlayerManager.gameOver = true;
            //Time.timeScale = 0.5f;
        }
        if (collision.gameObject.tag == "finish")
        {
            rb.velocity=(Vector3.forward * 20);
            PlayerManager.isGameFinished = true;
        }


    }

    [ContextMenu("Play")]
    public void Play()
    {
        Time.timeScale = 1;
    }

}
