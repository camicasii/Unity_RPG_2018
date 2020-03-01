using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]
public class PlayerController : MonoBehaviour
{


    private InputPlayers inputPlayer;
    private Transform transform_;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private Attacker attacker;


    //[SerializeField] private float velocity =0;
    [HideInInspector] private float axiX;
    [HideInInspector] private float axiY;

    private Attributes attributes;
    int runHashCode;
    




    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
        inputPlayer = GetComponent<InputPlayers>();
        transform_ = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        attributes = GetComponent<Attributes>();
        attacker = GetComponent<Attacker>();
        //tomar en cuentas el StringToHash para mejorar rendimiento
        runHashCode = Animator.StringToHash("run");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector2 newPosition =transform_.position + (new Vector3(axi_x,axi_y,0)*velocity*Time.deltaTime);
        // transform_.position=newPosition;

        /*#######################MOVIMIENTO####################*/
        //caso1
        // Vector2 force = new Vector2(axiX,axiY) * velocity *Time.deltaTime;        
        // playerRigidbody.AddForce(force);
        //caso2
        if(animator.GetBool("atacker"))
        {
            playerRigidbody.velocity =Vector2.zero;
        }
        else{
        Vector2 velocityPlayer = new Vector2(axiX, axiY) * attributes.velocity;
        playerRigidbody.velocity = velocityPlayer;}

    }
    private void Update()
    {
        axiX = inputPlayer.axiHorizontal;
        axiY = inputPlayer.axiVertical;
        animationPlayer(axiX, axiY);
        getAtacker();


    }
    
private void getAtacker(){
if(Input.GetButtonDown("atack")) animator.SetBool("atacker",true);
            
}
private void AtackerController(){  
        
        attacker.Atack(inputPlayer.lookToDirection, attributes.atack);
        animator.SetBool("atacker",false);
        

    }
    
    private void animationPlayer(float axiX, float axiY)
    {
        if (axiX != 0 || axiY != 0)
        {

            setXYAnimator();
            animator.SetBool(runHashCode, true);

        }
        else
        {
            animator.SetBool(runHashCode, false);
        }
        if (axiX != 0)
        {
            sprite.flipX = false;

        }
    }
    private void setXYAnimator()
    {
        animator.SetFloat("X", axiX);
        animator.SetFloat("Y", axiY);
    }

}
