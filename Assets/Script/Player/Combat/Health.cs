using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthBase;
    private int healthCurrent;
    public int HealthCurrent { 
        get
        {
            return healthCurrent;
        }
        set
        {
            if(value>0)
            healthCurrent=value;
            else
            healthCurrent=0;
        }
     }
    // Start is called before the first frame update
    void Start()
    {
        healthCurrent=healthBase;
    }

  
}
