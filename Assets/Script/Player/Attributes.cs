using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    velocity,
    atack,
    health
}





[CreateAssetMenu(menuName="ScriptableObject/Attributes")]
public class Attributes:ScriptableObject
{    [SerializeField]
    private int velocityBase;
    [SerializeField]
    private int atackBase;
    [SerializeField]
    private int velocityModificator;
    [SerializeField]
    private int ataqueModificator;



    //[Tooltip("velocidad de movimiento")]
    //public int velocity;
    public int velocity{get{return velocityBase +velocityModificator;} }
    public int atack{get{return atackBase +ataqueModificator;}}

    public void UpVelocityBase(int value){
        velocityBase+=value;
    }

    public void UpAtackBase(int value){
        atackBase+=value;
    }
    

    public void changeAtributes(Attribute attribute, int value)
    {
        switch (attribute)
        {
            case Attribute.velocity:
                velocityModificator=value;
                break;
            case Attribute.atack:
                ataqueModificator=value;                
                break;
            case Attribute.health:
                
                break;
            default:
                break;
        }
    }
    private void ModificateHealth(Health health, int value)
    {
        health.healthMoficator +=value;
    }

    public void updateEquipment(List<Equipamiento> equipamientos)
    {
        ResetModificator();
        foreach (var item in equipamientos)
        {
            velocityModificator+=item.velocity;
            ataqueModificator+=item.attacker;
            GameManager.Instance.player.GetComponent<Health>().healthMoficator+=item.health;
        }
        PanelsAttributes.Instance.updateTextAttributes(this,
        GameManager.Instance.player.GetComponent<Health>(),
        GameManager.Instance.player.GetComponent<LevelExp>());
        GameManager.Instance.player.GetComponent<Health>().UpdateHealthBar_();
    }

    private void ResetModificator()
    {
        velocityModificator=0;
        ataqueModificator=0;
        GameManager.Instance.player.GetComponent<Health>().healthMoficator=0;
    }
}
