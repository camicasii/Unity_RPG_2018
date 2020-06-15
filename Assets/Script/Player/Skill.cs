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
    
    
       Projectile newProjectile =Instantiate(projectile,
       transform.position,Quaternion.identity);       
        newProjectile.gameObject.transform.SetParent(transform);
        //newProjectile.gameObject.transform.SetParent(GameManager.Instance.containerOfProyectile);
        newProjectile.velocityIni= velocityIni;
        //newProjectile.transform.position=transform.position;
        newProjectile.directionIni=directionIni;
        newProjectile.damage=damage;
        //rotal el proyectir a la direccion del disparo
        float angulo = Mathf.Atan2(directionIni.y,directionIni.x)*Mathf.Rad2Deg;
        newProjectile.transform.Rotate(0,0,angulo);
        
    }
    public void Dash(Vector2 direccion, Rigidbody2D rigidbody)
    {
        Vector2 direcctionVelocity=direccion.normalized * 30;        
        rigidbody.velocity=direcctionVelocity;
    }

}
