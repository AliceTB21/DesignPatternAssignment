using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float observedHealth;
    [SerializeField] private Player playerRef;

    private void Start()
    {
        playerRef = Manager.Instance.GetPlayer;
        playerRef.onHealthChanged += UpdateHealth; // Subscribes UpdateHealth to onHealthChanged and updates it when there's a change
        healthText.text = playerRef.GetHealth.ToString();
    }

    public void UpdateHealth(float previousHealth, float currentHealth)
    {
        observedHealth = currentHealth;
        healthText.text = observedHealth.ToString();
        Debug.Log("Health changed from:" + previousHealth + " to " + currentHealth);
    }
}
