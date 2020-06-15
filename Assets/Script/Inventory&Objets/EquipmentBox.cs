using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBox : InventoryBox
{
    
    public Equipment typeEquipment;

    protected override void UseObjetBox()
    {
        UnEquipment();
    }

    public override void deleteObjet(){
        PanelEquipment.Instance.removeEquipment((Equipamiento)itemStock);
        resetBox();
    }
    protected void UnEquipment()
    {
        if(Inventory.Instance.isFull)
        {
            Debug.Log("inventario esta lleno accion nopermitida");
        }
        else{
            if(Inventory.Instance.addObjet(itemStock,1))
                deleteObjet();
            
        }
    }
    
}
