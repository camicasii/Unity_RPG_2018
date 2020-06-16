using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public AudioClip sounAttack;
    private AudioSource audioSource;

    public float gap = 1f; //desface
    public Vector2 hitBox = Vector2.one;
    // Start is called before the first frame update
    [HideInInspector] private Vector2 vectorGapAtack, pointA, pointB;
    public LayerMask layerAtack;
    private Collider2D[] atackColliders=new Collider2D[12];
    private ContactFilter2D filterOfAtack;
    private TextHitGenerator textHitGenerator;
    
    private void Start() {
        filterOfAtack.layerMask=layerAtack;
        filterOfAtack.useLayerMask =true;
        textHitGenerator = GetComponent<TextHitGenerator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        DebugHitBox();
    }
    public void Atack(Vector2 directionAtack, int damage)
    {
        createHitBox(directionAtack);
         int atacksElementents = Physics2D.OverlapArea(pointA,pointB,filterOfAtack,atackColliders);
         
         GameObject test;
         audioSource.clip=sounAttack;
         audioSource.Play();
         for(int i =0;i<atacksElementents;i++){                
                test =atackColliders[i].gameObject;                

                if(test!=null&&test.GetComponent<IsAttacker>()) {                    
                    test.GetComponent<IsAttacker>().getAttack(directionAtack,damage);
                    GenerarTextHit(damage,test);
                    }
         }        
    }
    private void GenerarTextHit(int damage,GameObject objetAttacker){
        float  floatDamage =(float)damage;                
        if(textHitGenerator)
            {
            //textHitGenerator.createTextHit(textHitGenerator.textHit,floatDamage,
            //objetAttacker.transform,0.2f,Color.white,2);
            textHitGenerator.createTextHit((float)damage,objetAttacker.transform);
            }
    }
    private void createHitBox(Vector2 directionAtack)
    {
        //vector para escalar vectores
        Vector2 scale = transform.lossyScale;
        Vector2 hitBoxScale = Vector2.Scale(hitBox, scale);
        //Vector2.normalized reprecenta un vector unitario         
        vectorGapAtack = Vector2.Scale(directionAtack.normalized * gap, scale);
        //(Vector2)transform.position tranformamos la posicion de un V3 a un V2 casting        
        pointA = (Vector2)transform.position + vectorGapAtack - hitBoxScale * 0.5f;
        pointB = pointA + hitBoxScale;

    }
    private void DebugHitBox()
    {

        Debug.DrawLine(transform.position, (Vector2)transform.position + vectorGapAtack, Color.yellow);
        Debug.DrawLine(pointA, pointB, Color.green);
    }
}
