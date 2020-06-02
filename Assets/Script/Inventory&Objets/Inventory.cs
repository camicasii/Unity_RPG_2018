using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool isFull;
    private static Inventory _instance = null;
    public static Inventory Instance { get { return _instance; } private set { } }

    private InventoryBox[] inventoryBox;
    private List<Item> inventory = new List<Item>();
    private int emptyBox = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        }
        
    }
    private void Start() {
        inventoryBox = GetComponentsInChildren<InventoryBox>();        
    }
    void NextEmptyBox()
    {
        emptyBox = 0;
        foreach (var box in inventoryBox)
        {
            if (box.itemStock)
            {
                emptyBox++;
            }
        }
        if (emptyBox >= inventoryBox.Length)
        {
            isFull = true;
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

    }

    public bool addObjet(Item item, int quantity)
    {
        NextEmptyBox();
       
        if ((item.stackable && !inventory.Contains(item) && !isFull)
         ||(!item.stackable && !isFull))
        {
        //InventoryBox addBox=inventoryBox[emptyBox];
        
        inventory.Add(item);
        inventoryBox[emptyBox].addObjet(item,quantity);
        //addBox.addObjet(item,quantity);
        
        return true; 
        }
        else if(item.stackable && inventory.Contains(item))
        {
            //nuestro objetos es apilable y tenemos una copia de el
            for(int i=0;i<inventoryBox.Length; i++)
            {
                if(item==inventoryBox[i].itemStock){
                    inventoryBox[i].quantityStock+=quantity;
                    break;
                }
            }
            return true; 
        }
        else{
            Debug.Log("inventorio is full");
            return false;
        }       
    }
    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
    }
}
