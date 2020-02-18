using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputPlayers : MonoBehaviour
{
    
  [HideInInspector] public float axiHorizontal;
  [HideInInspector] public float axiVertical;
  [HideInInspector] public bool atacar;    
  [HideInInspector] public bool skill_1;
  [HideInInspector] public bool skill_2;
  [HideInInspector] public bool inventory;

  [HideInInspector] public bool interactive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atacar = Input.GetButtonDown("atack");
        skill_1 = Input.GetButtonDown("skill1");
        skill_2 = Input.GetButtonDown("skill2");
        inventory = Input.GetButtonDown("inventory");
        interactive = Input.GetButtonDown("interactive");
        axiHorizontal =Input.GetAxis("Horizontal");
        axiVertical =Input.GetAxis("Vertical");
        
    }
}
