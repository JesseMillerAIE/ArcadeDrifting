using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float MoveSpeed = 50;
    public float Maxspeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;

    private Vector3 MoveForce;
    private InputReader InputReader;

    private void Awake()
    {
        InputReader = GetComponent<InputReader>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving
        float accelerationValue;
        if (InputReader.IsAccelerating) accelerationValue = 1;
        else accelerationValue = 0;
        
        MoveForce += transform.forward * MoveSpeed * accelerationValue * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Steering
        //float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * InputReader.MovementValue.x * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag and max speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, Maxspeed);

        // Traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

        //Handbrake Attempt

        
        if (InputReader.IsBreaking)
        {
            SteerAngle = 30;
            
            Traction = -10;
        }

        else {

            SteerAngle = 20;
           
            Traction = 1;
        }

    }
}
