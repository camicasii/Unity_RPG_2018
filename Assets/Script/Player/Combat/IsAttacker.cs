using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttacker : MonoBehaviour
{

    private Health health;
    private Rigidbody2D rgd2D;
    private void Start() {
        health=GetComponent<Health>();
        rgd2D =GetComponent<Rigidbody2D>();
    }
    public void getAttack(){        
        if(health!=null){        
        health.HealthCurrent -= 1;        
    }
    }
    public void getAttack(Vector2 directionOfAtack, int damage) {
        health.changeHealth(-damage);
        //rgd2D.AddForce(directionOfAtack*damage*1000);
        Debug.Log("push" + damage);
    }
}
