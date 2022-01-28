using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlot;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoCount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoCount)
    {
        GetAmmoType(ammoType).ammoCount += ammoCount;
    }

    public int GetAmmo(AmmoType ammotype)
    {
    AmmoSlot ammoSlot = GetAmmoType(ammotype);
        
        return ammoSlot.ammoCount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoType(ammoType);
        ammoSlot.ammoCount--;
    }

    private AmmoSlot GetAmmoType(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlot)
        {
            if (slot.ammoType == ammoType)
            {
                
                return slot;
            }
        }
        return null;
    }
}