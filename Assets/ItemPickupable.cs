using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Fuel,
    Capacity,
    Health,
    FullHealth,
}
public class ItemPickupable : MonoBehaviour
{
    [SerializeField] private ItemType itemType = ItemType.Fuel;

    private void OnTriggerEnter(Collider other)
    {
        Transform gameObject = other.transform.parent.parent;
        if (gameObject == null) return;
        switch (itemType)
        {
            case ItemType.Fuel:
                gameObject.GetComponentInChildren<CarEnergy>().LoadFuel(25f);
                break;
            case ItemType.Capacity:
                gameObject.GetComponentInChildren<CarEnergy>().AddCapacity(10f);
                break;
            case ItemType.Health:
                gameObject.GetComponentInChildren<DamageReceived>().RepairDamage(30f);
                break;
            case ItemType.FullHealth:
                gameObject.GetComponentInChildren<DamageReceived>().Reborn();
                break;
            default:
                break;
        }
        Destroy(this.transform.parent.gameObject);
    }
}
