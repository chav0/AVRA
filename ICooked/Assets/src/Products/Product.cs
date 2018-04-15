using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : ExtendedType
{
    [Header("Материал для партиклов")]
    [SerializeField]
    protected Material _particlesSpriteShit;

    [Header("Партиклы")]
    [SerializeField]
    private ParticleSystemRenderer _particles;

    [Header("Звук разрезания")]
    [SerializeField]
    private AudioSource _sound; 

    private void Awake()
    {
        _sliceMax = 5; 
        _sliceNum = 0;
        _sliced = false;
        _fried = false;
        _burned = false;  
        _currentProduct = Instantiate(_rawGO, transform);

        _particles.material = _particlesSpriteShit;
    }

    public override void IncSlice()
    {
        _sliceNum++;
        if (_sliceNum == _sliceMin)
        {
            ChangeForSliced(_halfSlicedGO);
        }
        if (_sliceNum == _sliceMax)
        {
            ChangeForSliced(_slicedGO);
            SetSliced(true);
        }

        _particles.GetComponent<ParticleSystem>().Play();
        _sound.Play(); 
    }
}

