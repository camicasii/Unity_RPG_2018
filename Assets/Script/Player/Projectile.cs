using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocityIni;
    public Vector2 directionIni;
    public int damage;
    private Rigidbody2D rgb2d;
    public string tagObjetive;
    // Start is called before the first frame update
    void Start()
    {   //transform.position=transform.parent.position + (Vector3)directionIni; ;//transform.parent.position *directionIni.normalized; //directionIni;        
        //transform.localEulerAngles=directionIni;
        rgb2d=GetComponent<Rigidbody2D>();
        rgb2d.velocity=directionIni.normalized * velocityIni;    
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.gameObject.CompareTag(tagObjetive));
        if(other.gameObject.CompareTag(tagObjetive)){
            other.gameObject.GetComponent<IsAttacker>().getAttack(directionIni,damage);       
            Destroy(gameObject);
             }
           
            
    }

}
