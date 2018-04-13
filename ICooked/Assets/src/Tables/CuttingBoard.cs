using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour {

    [SerializeField]
    private Transform _productContainer; // куда складывать продукты 

    public bool _isEmpty; // занята ли разделочная доска 
    public bool _isCollision; 
    public Product _currentProduct;

    private Product collisionProduct; 

    private void Awake () {
        _isEmpty = true; 
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        collisionProduct = other.gameObject.GetComponent<Product>();
        if (collisionProduct != null && _isEmpty)
        {
            _isCollision = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionProduct = other.gameObject.GetComponent<Product>();
        if (collisionProduct != null && !_isEmpty)
        {
            //collisionProduct.transform.SetParent(_productContainer); // положить в контейнер продукт 
            Debug.Log("OnExit");
            _isEmpty = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isCollision && collisionProduct != null)
        {
            _isCollision = false; 
            collisionProduct.transform.SetParent(_productContainer, true);
            _isEmpty = false;
            collisionProduct.transform.localPosition = Vector3.zero;

        }
    }
}



