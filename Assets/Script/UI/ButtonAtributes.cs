using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAtributes : MonoBehaviour
{
 public void isActivate(int pointAttributes)
 {
     if(pointAttributes>0)
     {
         gameObject.SetActive(true);
     }
     else{
         gameObject.SetActive(false);
     }
 }
}
