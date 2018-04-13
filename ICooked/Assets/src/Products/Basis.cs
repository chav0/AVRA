using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basis : MonoBehaviour {

    [SerializeField]
    private GameObject _slicedTomato;
    [SerializeField]
    private GameObject _notSlicedTomato;

    private Product collisionProduct; 

    private void OnTriggerEnter(Collider other)
    {
        collisionProduct = other.gameObject.GetComponent<Product>();
        if (collisionProduct != null)
        {
            if(collisionProduct._type == Type.Tomato)
            {
                if (collisionProduct.GetSliced())
                {
                    _slicedTomato.SetActive(true); 
                } else
                {
                    _notSlicedTomato.SetActive(true); 
                }
            }
        }
    }
}
