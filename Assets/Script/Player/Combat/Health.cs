using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{   
    public UnityEvent onDeath;
    public int healthBase;
    private int healthCurrent;
    public int HealthCurrent { 
        get
        {
            return healthCurrent;
        }
        set
        {
            if(value>0&&value<= healthBase)
            healthCurrent=value;
            else if(value>healthBase)healthCurrent=healthBase;            
            else{
            healthCurrent=0;            
            Destroy(gameObject);
            }
        }
     }
    // Start is called before the first frame update
    void Start()
    {
        HealthCurrent=healthBase;
    }

    public void changeHealth(int value ){
        HealthCurrent += value;

    }
  
}
