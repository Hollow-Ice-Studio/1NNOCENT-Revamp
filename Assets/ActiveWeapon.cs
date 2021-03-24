 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;


public class ActiveWeapon : MonoBehaviour
{
    public enum WeaponSlot
    {
        Primary = 0,
        Secundary = 1
    }
    public Transform crossHairTarget;
    public UnityEngine.Animations.Rigging.Rig handIk;
    public Transform weaponLeftGrip;
    public Transform weaponRightGrip;
    public Animator rigController;
    public Transform[] weaponSlots;
    public Cinemachine.CinemachineFreeLook playerCamera;
    

    RaycastWeapon[] equipped_weapons = new RaycastWeapon[2];
    int activeWeaponIndex;
    bool isHolstered = false;
   

    // Start is called before the first frame update
    void Start()
    {
        

        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }

    RaycastWeapon GetWeapon (int index)
    {
        if (index < 0 || index >= equipped_weapons.Length)
        {
            return null;
        }
        return equipped_weapons[index];
    }


    // Update is called once per frame
    void Update()
    {
        var weapon = GetWeapon(activeWeaponIndex);
        if (weapon)
        {
            if (Input.GetButtonDown("Fire1") && !isHolstered)
            {
                //Debug.Log("hahahahahahahahahahahahahah");
                //Debug.Log(Time.deltaTime);
                weapon.StartFiring();
            }

            if (weapon.isFiring && weapon.isAutomatic && !isHolstered)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }

            weapon.UpdateBullet(Time.deltaTime);

            if (Input.GetButtonUp("Fire1"))
            {
                weapon.StopFiring();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleActiveWeapon();
                
            }
        }
        else
        {
            handIk.weight = 0.0f;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(WeaponSlot.Secundary);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(WeaponSlot.Primary);
        }

    }

   
    public void Equip (RaycastWeapon newWeapon)
    {
        int weaponSlotIndex = (int)newWeapon.weaponSlot;
        var weapon = GetWeapon(weaponSlotIndex);

        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.recoil.playerCamera = playerCamera;
        weapon.recoil.rigController = rigController;
        weapon.transform.SetParent (weaponSlots[weaponSlotIndex], false);
        equipped_weapons[weaponSlotIndex] = weapon;
        
        handIk.weight = 1.0f;

        SetActiveWeapon(newWeapon.weaponSlot);
    }

    void ToggleActiveWeapon()
    {
        bool isHolstered = rigController.GetBool("holster_weapon");
        if (isHolstered)
        {
            StartCoroutine(ActivateWeapon(activeWeaponIndex));
        }
        else
        {
            StartCoroutine(HolsterWeapon(activeWeaponIndex));
        }
    }

    void SetActiveWeapon(WeaponSlot weaponSlot)
    {
        int holsterIndex = activeWeaponIndex;
        int activateindex = (int)weaponSlot;

        if(holsterIndex == activateindex)
        {
            holsterIndex = -1;
        }
        StartCoroutine(SwitchWeapon(holsterIndex, activateindex));
    }

    IEnumerator SwitchWeapon(int holsterIndex, int activateIndex)
    {
        yield return StartCoroutine(HolsterWeapon(holsterIndex));
        yield return StartCoroutine(ActivateWeapon(activateIndex));
        activeWeaponIndex = activateIndex;
    }
    IEnumerator HolsterWeapon (int index)
    {
        isHolstered = true;
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("holster_weapon", true);
            do
            {
                yield return new WaitForEndOfFrame();

            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        }
    }

    IEnumerator ActivateWeapon(int index)
    {
        var weapon = GetWeapon(index);
        if (weapon)
        {
            rigController.SetBool("holster_weapon", false);
            rigController.Play("Weapon_Anim_" + weapon.weaponName);
            do
            {
                yield return new WaitForEndOfFrame();

            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
            isHolstered = false;
        }
    }
}
