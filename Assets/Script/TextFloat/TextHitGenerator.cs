using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextHitGenerator : MonoBehaviour
{
    public float lifeTime=1f;
    public float distanceUp=2;
    public TextMesh textMesh;
    public float timeInitHide;
    private bool hiding;
    public Color color;
    public string sortingLayer="text";

    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName=sortingLayer;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
