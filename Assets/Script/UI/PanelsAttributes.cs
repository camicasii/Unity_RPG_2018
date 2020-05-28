using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelsAttributes : MonoBehaviour
{
    private static PanelsAttributes _instance=null;
    public static PanelsAttributes Instance{get{return _instance;} private set{}}
    public TextMeshProUGUI txtlevel;
    public TextMeshProUGUI txtExp;
    public TextMeshProUGUI txtHealth;
    public TextMeshProUGUI txtAtack;
    public TextMeshProUGUI txtVelocity;

    private void Awake() {
        if(Instance!=null && _instance!=this)
        {
            Destroy(this.gameObject);            
        }
        else{
        _instance=this;
        }
    }
    public void updateTextAttributes(Attributes attributes,Health health,LevelExp levelExp)
    {
        txtlevel.text=levelExp.level.ToString();
        txtlevel.text=levelExp.exp.ToString();
        //txtHealth.text=health.healthBase.ToString();
        txtHealth.text=health.health.ToString();
        txtAtack.text=attributes.atack.ToString();
        txtVelocity.text=attributes.velocity.ToString();
    }
   
}
