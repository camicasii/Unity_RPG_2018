using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EnemyIA
{
    public Projectile projectile;
    
    public override  void changeSprite(){
        if(input.axiX<0)spriteRenderer.flipX=false;
        else spriteRenderer.flipX=true;
    }
        
    public override void EnemyAtack(){
        Vector2 direction = input.directionToPlayer;
        
        skill.FireProjectile(projectile,projectile.velocityIni,
        direction,attributes.atack);
    }
    
}
