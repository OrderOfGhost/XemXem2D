using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> listWeapon;
    [SerializeField] private SpriteRenderer weapon;
    int currentWeapon = 0;

    void Update()
    {
        
    }

    public void ChangeWeapon()
    {
        if (currentWeapon == listWeapon.Count - 1)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }

        weapon.sprite = listWeapon[currentWeapon];
    }

    public void ShowAndHideWeapon()
    {
        weapon.enabled = !weapon.enabled;
    }
}
