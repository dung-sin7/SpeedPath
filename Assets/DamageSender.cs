using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSender : MonoBehaviour
{
    [SerializeField] private float damage = 5f;


    private void OnCollisionEnter(Collision collision)
    {
        this.Send(collision.gameObject);
    }

    private void Send(GameObject gameObject)
   {
      var damageReceived = gameObject.GetComponentInChildren<DamageReceived>();
      if (damageReceived == null) return;
      damageReceived.TakeDamage(damage);
   }
}
