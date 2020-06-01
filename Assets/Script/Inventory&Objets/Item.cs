using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="ScriptableObject/Items/ItemGeneric")]
public class Item : ScriptableObject
{
    public Sprite artWork;
    public string name_;
    public bool stackable; // se puede apilar o stajear el items
    [TextArea(1,3)]
    public string description;
    public virtual bool IsUsedItem(){
        Debug.Log("utilizado " + name );
        return true;
    }
     
    
}
