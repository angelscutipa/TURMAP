using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    CharacterController controlador;
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;

    public Camera cam;
    public float Chorizontal;
    public float Cvertical;
    public float minRot;
    public float maxRot;

    float h_mouse, v_mouse;

    private Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        /*h_mouse += Chorizontal*Input.GetAxis("Mouse X");
        v_mouse += Cvertical * Input.GetAxis("Mouse Y");*/

        //cam.transform.localEulerAngles = new Vector3(-v_mouse, h_mouse,0);
        cam.transform.localEulerAngles = new Vector3(0, Input.acceleration.y, 0) * Time.deltaTime * 5;
        //cam.transform.Rotate(new Vector3(0, Input.acceleration.y, 0) * Time.deltaTime * 5);

        move = new Vector3(Input.acceleration.x, 0, Input.acceleration.z)*runSpeed;
        //move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move = transform.TransformDirection(move) * runSpeed;
        }
        else
        {
            move = transform.TransformDirection(move) * walkSpeed;
        }


        controlador.Move(move*Time.deltaTime);
    }
}
