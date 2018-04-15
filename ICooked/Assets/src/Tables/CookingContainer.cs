using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingContainer : MonoBehaviour {

    [SerializeField]
    private Recipe _sandwich;

    private bool _isEmpty = true; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sandwich" && _isEmpty)
        {
            Debug.Log("YA UDALIL LISHKA");
            _sandwich.gameObject.SetActive(true);
            GameObject bread = Instantiate(other.gameObject, _sandwich._productContainer);
            bread.transform.localPosition = Vector3.zero;
            bread.transform.eulerAngles = Vector3.zero; 
            Destroy(other.gameObject);
        } 
    }
}
