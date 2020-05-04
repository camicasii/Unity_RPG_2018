using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{   
    public UnityEvent onDeath;
    public int healthBase;
    public Transform healthBar;
    //public int healthBar;

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
                Debug.Log(onDeath)         ;
                if(onDeath!=null)
                {
                    onDeath.Invoke();
                }
                //Destroy(gameObject);
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
        UpdateHealthBar();

    }
    private void DestroyGameObject(){
        Destroy(gameObject);
    }
    public void UpdateHealthBar(){
        float var =(float)healthCurrent/healthBase;
        Vector3 scale = new Vector3(var,1,1);
        healthBar.localScale=scale;
    }
  
}
