using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StairsInteractive : MonoBehaviour
{
    private Collider2D currentCollider;
    //public LevelController levelController;
    public UnityEvent OnInteractiveStair;


    private void Start() {
     currentCollider=GetComponent<Collider2D>();

    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {        
        //levelController.NextLevel(other.gameObject);
        OnInteractiveStair?.Invoke();
          
    }

    
}
