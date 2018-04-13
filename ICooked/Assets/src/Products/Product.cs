using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour {

    [SerializeField]
    public Type _type;

    [Header("Спрайтшит для партиклов")]
    [SerializeField]
    private Sprite _particlesSpriteShit;

    [Header("Геймобджекты разных типов")]
    [SerializeField]
    private GameObject _raw; // сырой продукт
    [SerializeField]
    private GameObject _sliced; // нарезанный

    private bool _isSliced;
    private GameObject _currentProduct;
    private int _sliceNum;

    private int _sliceMax = 5; 

    private void Awake()
    {
        _sliceNum = 0; 
        _currentProduct = Instantiate(_raw, transform);
    }

    public void IncSlice()
    {
        _sliceNum++; 
        if (_sliceNum == _sliceMax)
        {
            ChangeForSliced(); 
        }
    }

    public void ChangeForSliced()
    {
        Destroy(_currentProduct);
        _currentProduct = Instantiate(_sliced, transform);
        SetSliced(true); // установить как разрезанный 
    }

    public bool GetSliced()
    {
        return _isSliced; 
    }

    public void SetSliced(bool isSliced)
    {
        _isSliced = isSliced; 
    }
}

public enum Type
{
    Tomato = 0,
    Cucumber = 1,
    Onion = 2,
    Cabbage = 3,
    Mushrooms = 4
}