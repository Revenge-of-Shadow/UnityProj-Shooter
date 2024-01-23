using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxis{
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxis axis = RotationAxis.MouseX;

    public float senseHorizontal = 20.0F;
    public float senseVertical = 20.0F;

    public float maxVertAngle = 60.0F;
    public float minVertAngle = -60.0F;
    public float vertAngle = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null) body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        vertAngle -= Input.GetAxis("Mouse Y") * senseVertical;
        vertAngle = Mathf.Clamp(vertAngle, minVertAngle, maxVertAngle);

        float delta = Input.GetAxis("Mouse X") * senseHorizontal;

        float rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(vertAngle, rotationY, 0);

    }
}
