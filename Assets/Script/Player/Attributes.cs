using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="ScriptableObject/Attributes")]
public class Attributes:ScriptableObject
{    
    [Tooltip("velocidad de movimiento")]
    public int velocity;
    public int atack;

}
