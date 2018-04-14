using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucePlace : MonoBehaviour {

    [SerializeField]
    private Recipe _recipe; 

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }

}
