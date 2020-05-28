using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Health : MonoBehaviour
{   
    public UnityEvent onDeath;
    public int healthBase;
    public int health{get{ return healthBase+healthMoficator;}}
    public Transform healthBar;
    //public int healthBar;
    public Image healthBar_;


    private int healthCurrent;
    public int healthMoficator;
    

    public int HealthCurrent { 
        get
        {
            return healthCurrent;
        }
        set
        {
            if(value>0&&value<= health)
            healthCurrent=value;
            else if(value>health)healthCurrent=health;            
            else{
                healthCurrent=0;                   
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
        HealthCurrent=health;
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
        //float var =(float)healthCurrent/healthBase;
        float var =(float)healthCurrent/health;
        Vector3 scale = new Vector3(var,1,1);
        healthBar.localScale=scale;
    }
    //Modificador de barra de salud mas eficiente 
    //y sin modificaciones de tranformadas que pueden ocacional problemas
    public void UpdateHealthBar_(){
        if(healthBar_){        
        //float var =(float)healthCurrent/healthBase;        
        float var =(float)healthCurrent/health;        
        healthBar_.fillAmount=var;}
    }

    public void HealthBaseModificator(int value)
    {
        healthBase+=value;
        UpdateHealthBar_();        
    }
  
}
