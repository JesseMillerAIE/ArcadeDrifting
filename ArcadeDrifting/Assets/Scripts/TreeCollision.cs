using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TreeCollision : MonoBehaviour
{
    
    public float collisionForce;
    CarController carControllerMaster;
    public float timeout;
    void OnCollisionEnter(Collision other)
    {
        
        //on collision the lwanmower will get pushed back it will then 
        if (other.gameObject.TryGetComponent<CarController>(out CarController carController))
        {
            carControllerMaster = carController;

            carControllerMaster.MoveForce = carController.MoveForce * collisionForce;
            carControllerMaster.canDrive = false;
            //it will turn the driving off for two seconds. it can be modified with the public float "Timeout"
            Invoke("CollisionTimeout", timeout);
        }


    }

    void CollisionTimeout()
    {
        carControllerMaster.CollisionTimeout();

    }
}
