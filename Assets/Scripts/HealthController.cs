using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private Health health;
    [SerializeField]
    private int _startingMaxHealth = 100; // This default value is used only when the object is instantiated thru code like {new GameObject().AddComponent<HealthController>()}
    public float lastDamageTime{ get; private set; }
    [SerializeField]
    private float regenDelay = 3f; 
    [SerializeField]
    private int regenAmount = 1;

    public float RegenDelay => regenDelay; // Expression bodied read-only property for the tests to read the values set thru prefab
    public int RegenAmount => regenAmount; // Expression bodied read-only property for the tests to read the values set thru prefab

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

    public int GetCurrentHealth(){
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
