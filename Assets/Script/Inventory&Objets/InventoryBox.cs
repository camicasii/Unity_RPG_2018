using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryBox : MonoBehaviour
{
    public int quantityStock;
    public Item itemStock;
    private Image image;
    
    private void Awake() {
        image =GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(itemStock==null)
        {
            image.enabled=false;            
        }        
    }

    public void addObjet(Item item,int quantity)
    {
        itemStock=item;
        image.enabled=true;
        image.sprite=item.artWork;
        quantityStock=quantity;

    }
    public void deleteObjet()
    {
        image.sprite=null;
        quantityStock=0;
        image.enabled=false;
        itemStock=null;

    }

    protected  virtual void  UseObjetBox(){
        if(itemStock)
        {
            if(itemStock.IsUsedItem())
            {
                reducerStock(1);
            }
        }
    }

    void reducerStock(int quantity)
    {
        quantityStock -= quantity;
        if(quantityStock<=0)
        {
            deleteObjet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        UseObjetBox();
    }
}
