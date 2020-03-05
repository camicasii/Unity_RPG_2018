using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    private InputEnemy input;
    private Attacker attacker;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isDeath;
    private bool isAtacking;
    private bool isCombat;
    private Vector2 atackDirection;
    private int walkHash;
    private int atackHash;
    private int deathHash;
    
    [SerializeField] private float areaDection;
    [SerializeField] private float areaMinAtack;

    private void Start() {
        input =GetComponent<InputEnemy>();
        attacker =GetComponent<Attacker>();
        animator =GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        walkHash = Animator.StringToHash("walk");
        atackHash = Animator.StringToHash("atack");
        deathHash = Animator.StringToHash("death");
    }
    private void Update() {
      
        States();
    }
    public void States(){
        if(!isDeath)
        {   if(input.distance >  areaDection){
            isCombat=false;
            animator.SetBool(walkHash,false);
        }
            //Atack
            if(!isAtacking && input.distance < areaMinAtack)
            {   
               GetAtack();
            }
            else if(!isAtacking && (isCombat ||input.distance <  areaDection))
            {
                MoveToPlayer();
            } 

        }
    }

    public void KnightAtack(){
        attacker.Atack(atackDirection,attributes.atack);
        
    }
    public void MoveToPlayer()
    {    animator.SetBool(walkHash,true); 
        changeSprite();
        transform.position +=(Vector3)input.directionToPlayer * attributes.velocity * Time.deltaTime ;
    }
    public void changeSprite()
    {
        if(input.axiX<0)spriteRenderer.flipX=true;
        else spriteRenderer.flipX=false;
    }
    public void KnightAtackFalse(){
        isAtacking=false;        
    }
    public void GetAtack(){
        int prob =Random.Range(0,100);
        if(prob>98)
        {
            atackDirection=input.directionToPlayer;
            isAtacking=true;
            isCombat=true;
            animator.SetBool(walkHash,false);
            animator.SetTrigger(atackHash);
        }
    }

    public void Death(){
        animator.SetBool(deathHash,true);
    }




}
