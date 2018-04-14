using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Recipe : MonoBehaviour {

    public class RecipePoint
    {
        public ExtendedType _extendedType;
        public Image _checkPoint; 
    }

    public class Ingredient
    {
        public ExtendedType _extendedType;
        public GameObject _gameObject;
        public bool _isAdded; 
    }

    [SerializeField]
    private RecipePoint[] _recipe;

    [SerializeField]
    private Ingredient[] _ingredients; 

    [SerializeField]
    private Transform _productContainer; 

    [SerializeField]
    private Sprite _check;

    [SerializeField]
    private Sprite _uncheck;

    private ExtendedType collisionProduct; 

    private void OnTriggerEnter(Collider other) 
    {
        collisionProduct = other.gameObject.GetComponent<ExtendedType>();
        
        if (collisionProduct != null)
        {
            Debug.Log("Added " + collisionProduct._type.ToString());  
        }
    }

    private void SetProduct(ExtendedType _product) // положить продукт внутрь булочки 
    {
        foreach (Ingredient item in _ingredients)
        {
            if (_product._type == item._extendedType._type && _product._sliced == item._extendedType._sliced)
            {
                if (!item._isAdded)
                {
                    item._gameObject.SetActive(true);
                }
            }
            Destroy(_product.gameObject); 
        }

        CheckProduct(_product); 
    }

    public void CheckProduct(ExtendedType _product) // проверить, есть ли продукт в рецепте 
    {
        foreach (RecipePoint item in _recipe)
        {
            if (_product._type == item._extendedType._type)
            {
                if (_product._sliced == item._extendedType._sliced)
                {
                    item._checkPoint.sprite = _check;
                }
                else
                {
                    item._checkPoint.sprite = _uncheck;
                }
                return;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collisionProduct != null)
        {
            SetProduct(collisionProduct); 
        }
    }
}

public class ExtendedType : MonoBehaviour
{
    public TypeProducts _type;
    public bool _sliced;
    public bool _fried;

    public bool GetSliced()
    {
        return _sliced;
    }

    public void SetSliced(bool isSliced)
    {
        _sliced = isSliced;
    }

    public bool GetFried()
    {
        return _fried;
    }

    public void SetFried(bool fried)
    {
        _fried = fried;
    }

    [Header("Спрайтшит для партиклов")]
    [SerializeField]
    protected Sprite _particlesSpriteShit;

    [Header("Геймобджекты разных типов")]
    [SerializeField]
    protected GameObject _rawGO; // сырой продукт
    [SerializeField]
    protected GameObject _halfSlicedGO; // наполовину нарезанный продукт
    [SerializeField]
    protected GameObject _slicedGO; // нарезанный продукт

    protected GameObject _currentProduct;
    protected int _sliceNum;

    protected int _sliceMax = 3;
    protected int _sliceMin = 2; 

    public void IncSlice()
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
    }

    public void ChangeForSliced(GameObject _newGO)
    {
        if (!_sliced && _slicedGO != null)
        {
            Destroy(_currentProduct);
            _currentProduct = Instantiate(_newGO, transform);
        }
    }
}

public enum TypeProducts
{
    Tomato = 1,
    Cucumber = 2,
    Onion = 3,
    Cabbage = 4,
    Mushrooms = 5,
    Cheese = 6,
    Ketchup = 7,
    Myonnaise = 8,
    Mustard = 9,
    Susage = 10, 
    Meat = 11, 
    Cutlet = 12, 
    Salad = 13
}