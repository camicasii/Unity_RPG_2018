using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="ScriptableObject/Items/Potions/Helth")]
public class Potion : Item
{
    public int healing;
    public override bool IsUsedItem(){
        Health healthPlayer=GameManager.Instance.player.GetComponent<Health>();
        if(healthPlayer.HealthCurrent>=healthPlayer.health)
        {
            Debug.Log("salud LLena");
            return false;
        }
        else {
            healthPlayer.changeHealth(healing);        
        return true;}

        
    }

}
