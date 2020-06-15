using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelEquipment : MonoBehaviour
{
    private static PanelEquipment _instance=null;
    public static PanelEquipment Instance{get{return _instance;} private set{}}

    public Attributes attributes;

    public EquipmentBox[] equipmentBoxes;
    public List<Equipamiento> equipamientos=new List<Equipamiento>();


    private void Awake() {
        if(Instance!=null && _instance!=this)
        {
            Destroy(this.gameObject);            
        }
        else{
        _instance=this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        equipmentBoxes =GetComponentsInChildren<EquipmentBox>();
        
    }

    public Equipamiento wearEquipment(Equipamiento equipamiento){
        foreach(var item in equipmentBoxes)
        {            
            if(item.typeEquipment==equipamiento.typeEquipment)
            {
                if(!item.itemStock){
                    Debug.Log("Empty box");
                    addEquipment(equipamiento,item);
                    
                    return null;
                }
                else
                {
                    //Casteos
                    //Equipamiento itemWear=(Equipamiento)item.itemStock;
                    Equipamiento itemWear=item.itemStock as Equipamiento;
                    //removeEquipment(equipamiento,item);
                    addEquipment(equipamiento,item);
                    return itemWear;

                }
            }
            
        }
        return null;
    }

    public void addEquipment(Equipamiento equipamiento, EquipmentBox equipmentBox_)
    {
       equipmentBox_.addObjet(equipamiento,1);
       equipamientos.Add(equipamiento);
        attributes.updateEquipment(equipamientos);

    }
    public void  removeEquipment(Equipamiento   equipamiento){
        equipamientos.Remove(equipamiento);        
        attributes.updateEquipment(equipamientos);       
        
    }
}
