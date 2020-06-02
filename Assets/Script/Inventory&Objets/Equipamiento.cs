using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipment{
    helmet,
    armor,
    weapon
}
 [CreateAssetMenu(menuName="ScriptableObject/Items/Equipement")]
public class Equipamiento : Item
{
    public Equipment typeEquipment;
    public int health;
    public int  attacker;
    public int velocity;

    public override bool IsUsedItem()
    {
        
        return true;
    }

    
}
