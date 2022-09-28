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

    public float handbrakeStrength;
    public float handbrakeTraction;
    public float Yaxis;

    public bool canDrive;

    public Vector3 MoveForce;
    private InputReader InputReader;

    

    private void Awake()
    {
        InputReader = GetComponent<InputReader>();
        canDrive = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float accelerationValue = 0;
        if (canDrive)
        {


            // Moving
            
            if (InputReader.IsAccelerating) accelerationValue = 1;
            else accelerationValue = 0;


            // Steering
            //float steerInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * InputReader.MovementValue.x * MoveForce.magnitude * SteerAngle * Time.deltaTime);


            //Handbrake Attempt 

            if (InputReader.IsBreaking)
            {
                //(Turned into a reverse button)
                //MoveForce -= transform.forward * Time.deltaTime * handbrakeStrength; 

                //MoveForce = transform.forward*handbrakeStrength/Time.deltaTime ;

                MoveForce /= handbrakeStrength;
                Traction = handbrakeTraction;

            }
            else
            {
                Traction = 1;
            }


        }

        // Drag and max speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, Maxspeed);

        // Traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

        MoveForce += transform.forward * MoveSpeed * accelerationValue * Time.deltaTime;
            transform.position += MoveForce * Time.deltaTime;

        Yaxis = transform.position.y;

        if(Yaxis <0.78f)
        {
            Yaxis = 0.78f;
        }
    }

    public void CollisionTimeout()
    {
        canDrive = true;
    }
}
