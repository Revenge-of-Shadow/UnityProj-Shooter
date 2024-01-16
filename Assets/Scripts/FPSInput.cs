using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPSInput")]
public class FPSInput : MonoBehaviour
{
    public float speed = 16.0F;
    public float gravity = -9.81F;
    private CharacterController _charController;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        //float deltaZ = 0;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement *= Time.deltaTime * 10;
        movement = Vector3.ClampMagnitude(movement, speed);
        movement = transform.TransformDirection(movement);
        movement.y = gravity;
        _charController.Move(movement);
    }
}
