using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class Objets : Interactive
{
    public Item item;
    private SpriteRenderer spriteRenderer;
    
    public int quantity=1;    


    private void OnValidate() {
        spriteRenderer=GetComponent<SpriteRenderer>();
        gameObject.name=item.name_;
        spriteRenderer.sprite=item.artWork;

    }


    // Start is called before the first frame update
    void Start()
    {
       boxCollider2D=GetComponent<BoxCollider2D>();
       player =GameManager.Instance.player.GetComponent<PlayerController>();
       
       spriteRenderer.sortingLayerName="Drop";
       boxCollider2D.isTrigger=true;
       boxCollider2D.size=Vector2.one; 
        gameObject.layer=14; 
        
    }

    // Update is called once per frame
    public override  void Interacting(){
        
        if(Inventory.Instance.addObjet(item,quantity))
        {
            Destroy(gameObject);
        }

    }
}
