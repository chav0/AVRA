using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour {

    [System.Serializable]
    public class RecipePoint
    {
        public TypeProducts _type;
        public bool _sliced;
        public bool _fried;
        public bool _burned;
        public Image _checkPoint;
    }

    [System.Serializable]
    public class Ingredient
    {
        public TypeProducts _type;
        public bool _sliced;
        public MeshRenderer _mesh;
        public bool _isAdded;
    }

    [SerializeField]
    private RecipePoint[] _recipe;

    [SerializeField]
    private Ingredient[] _ingredients; 

    [SerializeField]
    public Transform _productContainer; 

    [SerializeField]
    private Sprite _check;

    [SerializeField]
    private Sprite _uncheck;

    private ExtendedType collisionProduct;
    private float level = 0f; 

    private void OnTriggerEnter(Collider other) 
    {
        collisionProduct = other.gameObject.GetComponent<ExtendedType>();
        
        if (collisionProduct != null)
        {
            SetProduct(collisionProduct); 
        }
    }

    public void SetProduct(ExtendedType _product) // положить продукт внутрь булочки 
    {
        foreach (Ingredient item in _ingredients)
        {
            if (_product._type == item._type && _product._sliced == item._sliced)
            {
                if (!item._isAdded)
                {
                    level += 0.0111f;
                    item._mesh.transform.parent.localPosition = new Vector3(0f, level, 0f); 
                    item._mesh.transform.parent.gameObject.SetActive(true);
                    if (_product._fried)
                    {
                        item._mesh.material = _product._friedGO; 
                    }
                    if (_product._burned)
                    {
                        item._mesh.material = _product._burnedGO;
                    }
                    CheckProduct(_product);
                }
            }

        }
        Destroy(_product.gameObject);
    }

    public void CheckProduct(ExtendedType _product) // проверить, есть ли продукт в рецепте 
    {
        foreach (RecipePoint item in _recipe)
        {
            if (_product._type == item._type)
            {
                if (_product._sliced == item._sliced && _product._fried == item._fried && _product._burned == item._burned)
                {
                    item._checkPoint.sprite = _check;
                    Debug.Log("check"); 
                }
                else
                {
                    item._checkPoint.sprite = _uncheck;
                    Debug.Log("uncheck");
                }
                return;
            }
        }
    }
}

public class ExtendedType : MonoBehaviour
{
    public TypeProducts _type;
    public bool _sliced;
    public bool _fried;
    public bool _burned;

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

    public bool GetBurned()
    {
        return _burned;
    }

    public void SetBurned(bool burned)
    {
        _burned = burned;
    }

    [Header("Геймобджекты разных типов")]
    [SerializeField]
    protected GameObject _rawGO; // сырой продукт
    [SerializeField]
    protected GameObject _halfSlicedGO; // наполовину нарезанный продукт
    [SerializeField]
    protected GameObject _slicedGO; // нарезанный продукт
    [SerializeField]
    public Material _friedGO; // пожаренный продукт
    [SerializeField]
    public Material _burnedGO; // сгоревший

    protected GameObject _currentProduct;
    protected int _sliceNum;

    protected int _sliceMax = 3;
    protected int _sliceMin = 2; 

    public virtual void IncSlice()
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
    Hum = 12, 
    Salad = 13,
    Bread = 14, 
    Pita = 15, 

}

