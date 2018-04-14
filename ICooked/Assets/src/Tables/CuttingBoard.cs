using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour {

    [SerializeField]
    private Transform _productContainer; // куда складывать продукты 

    public bool _isEmpty; // занята ли разделочная доска 
    public bool _isCollision; 
    public ExtendedType _currentProduct;

    private ExtendedType collisionProduct; 

    private void Awake () {
        _isEmpty = true; 
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        collisionProduct = other.gameObject.GetComponent<ExtendedType>();
        if (collisionProduct != null && _isEmpty)
        {
            collisionProduct.transform.SetParent(_productContainer, true);
            _isEmpty = false;
            collisionProduct.GetComponent<Rigidbody>().freezeRotation = true;
            collisionProduct.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; 
            collisionProduct.transform.eulerAngles = Vector3.zero;
            collisionProduct.transform.localPosition = Vector3.zero;
            collisionProduct.GetComponent<Rigidbody>().freezeRotation = false;
            collisionProduct.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            collisionProduct = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionProduct = other.gameObject.GetComponent<ExtendedType>();
        if (collisionProduct != null)
        {
            if (!_isEmpty)
            {
                if (collisionProduct == _currentProduct)
                {
                    _currentProduct = null; 
                }
            }
            Debug.Log("OnExit");
            collisionProduct = null;
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
            collisionProduct = null; 
        }
    }
}



