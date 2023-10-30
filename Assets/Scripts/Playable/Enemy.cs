using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            AudioManager.Instance.PlayEffect(SoundType.Damage);

            player.TakeDamage();

            PlayerHealthUI.Instace.UpdateHealthUI();
        }
    }

    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
