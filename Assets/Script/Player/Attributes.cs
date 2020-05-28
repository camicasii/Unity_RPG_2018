using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="ScriptableObject/Attributes")]
public class Attributes:ScriptableObject
{    [SerializeField]
    private int velocityBase;
    [SerializeField]
    private int atackBase;

    private int velocityModificator;
    private int ataqueModificator;



    //[Tooltip("velocidad de movimiento")]
    //public int velocity;
    public int velocity{get{return velocityBase +velocityModificator;}}
    public int atack{get{return velocityBase +velocityModificator;}}

    public void UpVelocityBase(int value){
        velocityBase+=value;
    }

    public void UpAtackBase(int value){
        atackBase+=value;
    }

}
