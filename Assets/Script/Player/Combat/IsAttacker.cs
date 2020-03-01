using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttacker : MonoBehaviour
{

    private Health health;
    private void Start() {
        health=GetComponent<Health>();
    }
    public void getAttack(){        
        if(health!=null){        
        health.HealthCurrent -= 1;
        Debug.Log(health.HealthCurrent);}
    }
}
