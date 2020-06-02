using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBox : InventoryBox
{
    public Equipment equipment;

    protected override void UseObjetBox()
    {
        
    }

    private void UnEquipment()
    {
        if(Inventory.Instance.isFull)
        {
            Debug.Log("inventario esta lleno accion nopermitida");
        }
        else{
            Inventory.Instance.addObjet(itemStock,1);
            deleteObjet();
        }
    }
}
