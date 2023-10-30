using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerHealthUI : MonoBehaviour
{
    public static PlayerHealthUI Instace { get; private set; }

    private PlayerController player;

    [SerializeField] private TextMeshProUGUI playerHealthText;

    private void Awake()
    {
        Instace = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        playerHealthText.text = player.health.ToString();
    }


}
