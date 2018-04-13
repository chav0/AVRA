using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

    private Product collisionProduct;

    private void OnTriggerEnter(Collider other)
    {
        collisionProduct = other.gameObject.GetComponent<Product>();
        if (collisionProduct != null)
        {
            collisionProduct.IncSlice();
            Debug.Log("Knife"); 
        }
    }
}
