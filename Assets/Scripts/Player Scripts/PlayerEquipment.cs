using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public PlayerCombat sword;
    public PlayerBow bow;
    public InventoryManager inventory;
    
    public Items swordItem;
    public Items bowItem;
    public bool hasBow = false;
    
    void Update()
    {
        if (Input.GetButtonDown("ChangeSword")) {
            sword.enabled = true;
            bow.enabled = false;
            inventory.ChangeWeapon(swordItem);
        }

        if (Input.GetButtonDown("ChangeBow") && hasBow) {
            sword.enabled = false;
            bow.enabled = true;
            inventory.ChangeWeapon(bowItem);
        }
    }

    public void EquipBow() {
        sword.enabled = false;
        bow.enabled = true;
        inventory.ChangeWeapon(bowItem);
    }
}
