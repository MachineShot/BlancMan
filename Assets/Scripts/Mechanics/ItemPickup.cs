using UnityEngine;

public class ItemPickup : Interactable
{
    //public Item item;
    public Equipment equipment;
    public override void Interact()
    {
        //base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up item " + equipment.name);
        EquipmentManager.instance.Equip(equipment);
        Destroy(gameObject);
    }
}
