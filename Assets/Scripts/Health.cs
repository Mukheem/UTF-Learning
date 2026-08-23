using System;

public class Health
{
    private int _maxHealth;
    public int CurrentHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0; // Ciomputed property to reduce storage and memory.

    public Health(int maxHealth){

        this._maxHealth = (maxHealth <=0) ? 100 : maxHealth;
        CurrentHealth = this._maxHealth;
        
    }

    public void TakeDamage(int amount){

        amount = Math.Max(amount,0); // Covers scenario when amount is negative or 0

        CurrentHealth = CurrentHealth - amount;

        CurrentHealth = Math.Max(CurrentHealth,0);// If Amount is greater than current health then current health is set to 0 bcz in previous step currentHealth would be set to negative for this case.


    }

    public void Heal(int amount){
        int tempCurrentHealth;

        amount = Math.Max(amount,0); // If amount is 0 or negative

        if(CurrentHealth >0){ // If the player is dead then no healing to happen.
            tempCurrentHealth = (CurrentHealth+amount);

            CurrentHealth = Math.Min(this._maxHealth, tempCurrentHealth); // Math.Min - Covers scenario when amount is greater than leftPercentage of health i.e., currentHealth is 80 and maxHealth is 100 then amount is 30 --> Caps the currentHealth to Max health.
        }

    }
}
