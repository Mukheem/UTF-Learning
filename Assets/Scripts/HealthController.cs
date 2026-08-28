using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private Health health;
    [SerializeField]
    private int _startingMaxHealth = 100;
    public float lastDamageTime{ get; private set; }
    private float regenDelay = 3f;
    private int regenAmount = 1;

    void Awake(){
        
        health = new Health(this._startingMaxHealth);

    }

    void Start(){
        StartCoroutine(RegenRoutine());
    }

    public void TakeDamage(int amount){
        if(amount > 0){
            lastDamageTime = Time.time;
        }
        health.TakeDamage(amount);
    }

    public void Heal(int amount){
        health.Heal(amount);
    }

    public int getCurrentHealth(){
        return health.CurrentHealth;
    }

    public IEnumerator RegenRoutine(){
        while(true){
                 
        yield return new WaitForSeconds(1f);
        if (!health.IsDead && ( Time.time - lastDamageTime > regenDelay)){
            health.Heal(regenAmount);
        }
        }
   
    }
}
