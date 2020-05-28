using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Health : MonoBehaviour
{   
    public UnityEvent onDeath;
    public int healthBase;
    public Transform healthBar;
    //public int healthBar;
    public Image healthBar_;

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
                Debug.Log(onDeath);
                gameObject.layer=13;         ;
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
        UpdateHealthBar_();

    }
    private void DestroyGameObject(){
        Destroy(gameObject);
    }
    //Utilizando la escala de la imagen
    public void UpdateHealthBar(){
        float var =(float)healthCurrent/healthBase;
        Vector3 scale = new Vector3(var,1,1);
        healthBar.localScale=scale;
    }
    //Modificador de barra de salud mas eficiente 
    //y sin modificaciones de tranformadas que pueden ocacional problemas
    public void UpdateHealthBar_(){
        if(healthBar_){        
        float var =(float)healthCurrent/healthBase;        
        healthBar_.fillAmount=var;}
    }
  
}
