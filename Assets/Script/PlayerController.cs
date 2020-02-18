using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private InputPlayers inputPlayer;
    private Transform transform_;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private SpriteRenderer sprite;


    [SerializeField] private float velocity;
    [HideInInspector] private float axiX;
    [HideInInspector] private float axiY;

    private bool back;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        inputPlayer = GetComponent<InputPlayers>();
        transform_ = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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
        Vector2 velocityPlayer = new Vector2(axiX, axiY) * velocity;
        playerRigidbody.velocity = velocityPlayer;

    }
    private void Update()
    {

        axiX = inputPlayer.axiHorizontal;
        axiY = inputPlayer.axiVertical;
        back = axiY > 0;


        IsBackSprite();   
        if (axiX != 0 || axiY != 0)
        {
         setXYAnimator();

        }


    }
    private void IsBackSprite(){
              if (axiX < 0 && Mathf.Abs(axiX) > Mathf.Abs(axiY))
        {
            sprite.flipX = true;
        }
        else if (axiX != 0)
        {
            sprite.flipX = false;

        }
    }
    private void setXYAnimator(){
        animator.SetFloat("X", axiX);
        animator.SetFloat("Y", axiY);
    }

}
