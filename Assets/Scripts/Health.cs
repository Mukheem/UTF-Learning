public class Health
{
    private int maxHealth;
    private int currentHealth;

    public Health(int maxHealth){

        maxHealth = (maxHealth <=0) ? 100 : maxHealth;
        
    }
}
