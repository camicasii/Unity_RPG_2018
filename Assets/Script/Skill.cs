using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void  FireProjectile(Projectile projectile, float velocityIni, Vector2 directionIni, int damage)
    {
    
    
       GameObject newProjectile =Instantiate(projectile.gameObject,
       transform.position,Quaternion.identity);
       Projectile myProjectile =newProjectile.GetComponent<Projectile>();
        
        myProjectile.velocityIni= velocityIni;
        myProjectile.directionIni=directionIni;
        myProjectile.damage=damage;
    }

}
