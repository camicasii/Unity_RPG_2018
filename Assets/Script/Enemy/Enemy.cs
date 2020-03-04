using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attributes attributes;
    public string name_;
    public int exp;    

    protected void SayName(){

Debug.Log(" i am " + name_);
    }
}
