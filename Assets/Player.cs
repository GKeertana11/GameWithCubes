using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public Vector3 movement;
    Rigidbody rb;
    public Camera cam;
    Quaternion playerRotation;
    Quaternion camRotation;
    public float rotationSpeed;
    public float toMinX = -90;
    public float toMaxX = 90;
    float mouseX;
    float mouseY;
  //  public GameObject player;
   // public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      //  animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        transform.Translate(movement.x * speed, 0, movement.z * speed);
       // animator.SetFloat("walkSpeed", 10);

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce);
        }
        /* mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
         mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
         playerRotation = Quaternion.Euler(0, movement.y, 0) * playerRotation;
         camRotation = ClampRotationOfPlayer(Quaternion.Euler(-movement.x, 0, 0) * camRotation);

         //Debug.Log(playerRotation);
         //Debug.Log(camRotation);

         this.transform.localRotation = playerRotation;
         cam.transform.localRotation = camRotation;*/
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.rotation = transform.rotation * Quaternion.Euler(0, mouseX * rotationSpeed, 0);
        Camera cam = GetComponentInChildren<Camera>();
        cam.transform.localRotation = ClampRotationOfPlayer(Quaternion.Euler(-mouseY, 0, 0) * cam.transform.localRotation);
    }

    public Quaternion ClampRotationOfPlayer(Quaternion n)
    {
        n.w = 1f;
        n.x /= n.w;
        n.y /= n.w;
        n.z /= n.w;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(n.x);
        angleX = Mathf.Clamp(angleX, toMinX, toMaxX);
        n.x = Mathf.Tan(Mathf.Deg2Rad * 0.5f * angleX);
        return n;

    }
}
