using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private bool canTakeDamage = true;
    private float damageCooldown = 1f;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Trap"))
    //     {
    //         Debug.Log("PlayerLife ");
    //         GetComponent<Health>().TakeDamage(1);

    //     }
    // }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (canTakeDamage)
            {
                Debug.Log("PlayerLife");
                GetComponent<Health>().TakeDamage(1);
                StartCoroutine(StartDamageCooldown());
            }
        }
    }

    private IEnumerator StartDamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(damageCooldown);
        canTakeDamage = true;
    }

    public void Die()
    {

        deathSoundEffect.Play();
        // rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        GetComponent<SavingPlayerPrefabs>().SaveData();
        SceneManager.LoadScene("End Screen");
    }
    public void Win()
    {

        deathSoundEffect.Play();
        // rb.bodyType = RigidbodyType2D.Static;
        // anim.SetTrigger("death");
        GetComponent<SavingPlayerPrefabs>().SaveData();
        // SceneManager.LoadScene("End Screen");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {   
            Debug.Log("Finish: " + collision.gameObject.name);
            GetComponent<SavingPlayerPrefabs>().SaveData();
            GetComponent<SavingPlayerPrefabs>().SaveLevelCompleted();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
