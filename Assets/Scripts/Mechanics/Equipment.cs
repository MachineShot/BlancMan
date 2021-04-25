using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }
}
public enum EquipmentSlot { Weapon }