using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Interactive : MonoBehaviour,IPointerDownHandler
{ 
    protected Collider2D collider2;
    protected BoxCollider2D boxCollider2D;
    public UnityEvent OnInteraction;
    protected PlayerController player;
    

    // Start is called before the first frame update
    private void Awake() {
        
    }
    void Start()
    {
        collider2 =GetComponent<Collider2D>();
        boxCollider2D   =GetComponent<BoxCollider2D>();
        player=GameManager.Instance.player.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        OnInteraction.Invoke();
        
    }

    
    /*private void OnMouseDown() {
        Debug.Log("Click2");
        interarte();
    }*/

    protected void interarte()
    {
        foreach (RaycastHit2D item in player.Interactive())
        {            
            if(item.collider.gameObject==this.gameObject)
            {
                Interacting();
            }
        }
    }
    public virtual void Interacting()
    {
        Debug.Log("Click3 " + gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {         
         interarte();
    }
}
