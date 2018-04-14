using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        ExtendedType collisionProduct = other.gameObject.GetComponent<ExtendedType>();
        if (collisionProduct != null)
        {
            Destroy(collisionProduct.gameObject); 
        }
    }
}
