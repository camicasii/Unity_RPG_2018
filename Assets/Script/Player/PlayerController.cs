using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]
public class PlayerController : MonoBehaviour
{

    public Projectile projectile;
    public LayerMask layerInteracte;
    private InputPlayers inputPlayer;
    
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private Attacker attacker;
    private Skill skill;
    private float dashCoolDown=0;
    private bool isDash;
    TrailRenderer trailRenderer;


    //[SerializeField] private float velocity =0;
    [HideInInspector] private float axiX;
    [HideInInspector] private float axiY;

    public Attributes attributesPlayer;
    
    int runHashCode;
    
    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody2D>();
        inputPlayer = GetComponent<InputPlayers>();        
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        skill = GetComponent<Skill>();
        trailRenderer=GetComponent<TrailRenderer>();
        
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
        else if(axiX != 0 || axiY != 0 && !isDash)
        {
            
        Vector2 velocityPlayer = new Vector2(axiX, axiY) * attributesPlayer.velocity;
        playerRigidbody.velocity = velocityPlayer;
        }
        //-Skills
        if(inputPlayer.skill_2 && !isDash)
        {
            IsActiveTrailRenderer();
            isDash=true;
            skill.Dash(inputPlayer.lookToDirection,playerRigidbody);            
        }
        if(inputPlayer.skill_1)
        {
            skill.FireProjectile(projectile,10,inputPlayer.lookToDirection,attributesPlayer.atack);
        }
        

    }
    
    private void IsActiveTrailRenderer()
        {
            if(trailRenderer.enabled)
            {
                trailRenderer.enabled=false;
            }
            else
            {
                trailRenderer.enabled=true;
            }
        }

    private void Update()
    {
        
        axiX = inputPlayer.axiHorizontal;
        axiY = inputPlayer.axiVertical;
        animationPlayer(axiX, axiY);
        getAtacker();
        if(inputPlayer.inventory)PanelsMenu.instance.OpenClosedPanels();
        updateDashCoolDown();
        inputPlayer.getLookToDirection();

    }
    private void updateDashCoolDown()
    {
        
        if(isDash)
        { 
            dashCoolDown +=Time.deltaTime;  
            if(dashCoolDown>trailRenderer.time)
            {   IsActiveTrailRenderer();             
                dashCoolDown=0;
                isDash=false;
                
            }


        }
    }
    
private void getAtacker(){
if(Input.GetButtonDown("atack")) animator.SetBool("atacker",true);
            
}
private void AtackerController(){     
        //Debug.Log(attributesPlayer.atack);     
        //Debug.Log(attributesPlayer.velocity);             
        attacker.Atack(inputPlayer.lookToDirection, attributesPlayer.atack);
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
    public RaycastHit2D[] Interactive()
    {
        //Vector3 dir=new Vector3(4,0,0) + transform.position;
        //Debug.DrawRay(transform.position,transform.position +Vector3.Scale(dir,transform.lossyScale),Color.cyan);   
        //Debug.LogWarning(inputPlayer.lookToDirection.normalized);
        RaycastHit2D[] circleCast=Physics2D.CircleCastAll(
            transform.position,GetComponent<CapsuleCollider2D>().size.x,
            inputPlayer.lookToDirection.normalized,1f,layerInteracte
        );
        
        

        
        
        if(circleCast!=null)
        {
            return circleCast;
        }
        else{
            return null;
        }

        
    }


}
