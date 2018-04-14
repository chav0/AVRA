using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : ExtendedType
{
    [SerializeField]
    private ParticleSystem _particles; 

    private void Awake()
    {
        _sliceMax = 5; 
        _sliceNum = 0;
        _sliced = false;
        _fried = true; 
        _currentProduct = Instantiate(_rawGO, transform);
        

        if (_type == TypeProducts.Salad)
        {
            _sliced = true; 
        }
    }
}

