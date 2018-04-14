using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : ExtendedType {


    private void Awake()
    {
        if (_type == TypeProducts.Meat)
        {
            _sliced = true;
            _fried = true;
            _currentProduct = Instantiate(_rawGO, transform);
        }

        if (_type == TypeProducts.Cutlet)
        {
            _sliced = false;
            _fried = false; 
            _currentProduct = Instantiate(_rawGO, transform);
        }

        if (_type == TypeProducts.Susage)
        {
            _sliced = false;
            _fried = false;
            _currentProduct = Instantiate(_rawGO, transform);
        }
    }
}
