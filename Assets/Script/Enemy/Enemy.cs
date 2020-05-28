using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public Attributes attributes;
    public string name_;
    public int exp_;   

    public void  giveExp(){   
        //Debug.Log("give "+exp_ + name_);     
        GameManager.Instance.player.GetComponent<LevelExp>().exp+=exp_;
    }
}
