using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    public float timeout;
    CarController carControllerMaster;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<CarController>(out CarController carController))
        {
            carController.Maxspeed = 2;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<CarController>(out CarController carController))
        {
            carController.Maxspeed = 15;
        }
    }

   
}
