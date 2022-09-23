using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TreeCollision : MonoBehaviour
{
    public GameObject player;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<CarController>(out CarController carController))
        {
            Debug.Log(carController.name);
        }


    }
}
