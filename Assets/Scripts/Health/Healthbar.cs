using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Awake()
    {
        // playerHealth = GetComponent<Health>();
        // totalhealthBar = GetComponent<Image>();
        // currenthealthBar = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        if (playerHealth != null)
        {
            totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
        }
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
        }
    }
}