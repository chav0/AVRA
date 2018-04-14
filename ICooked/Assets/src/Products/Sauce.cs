using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce : ExtendedType {

    [SerializeField]
    private ParticleSystem _particles;

    private void Awake()
    {
        _sliced = true;
        _fried = true;
        _currentProduct = Instantiate(_rawGO, transform);
    }
}
