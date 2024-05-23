using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get;  set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        Debug.Log("Health : ");
        currentHealth = startingHealth;
        Debug.Log("Awake: currentHealth " + currentHealth + "LevelCompleted: " + GetComponent<SavingPlayerPrefabs>().GetLevelCompleted());
        if (GetComponent<SavingPlayerPrefabs>().GetLevelCompleted() == 1)
        {
            currentHealth = GetComponent<SavingPlayerPrefabs>().GetHealth();
            // GetComponent<SavingPlayerPrefabs>().setLevelCompleted(0);
            Debug.Log(" GetLevelCompleted done: " + GetComponent<SavingPlayerPrefabs>().GetLevelCompleted() + " currentHealth: " + currentHealth); ;
        }
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            Debug.Log("Current Health :" + currentHealth + "-> Hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                Debug.Log("death : ");
                anim.SetTrigger("death");
                GetComponent<PlayerLife>().Die();
                Debug.Log("currentHealth = " + currentHealth + " Dead ");
                // GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    
}