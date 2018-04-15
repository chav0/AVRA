using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mobile : MonoBehaviour {

    [SerializeField]
    private AudioClip[] _clips;

    [SerializeField]
    private AudioSource _source;

    [SerializeField]
    private Text _audioName; 

    private int i = 0; 
     

    public void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || !_source.isPlaying)
        {
            i++; 
            if (i >= _clips.Length)
            {
                i = 0; 
            }
            _source.clip = _clips[i];
            _source.Play();
            _audioName.text = _clips[i].name; 
        }
    }
}
