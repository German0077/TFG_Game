using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public PlayerCombat sword;
    public PlayerBow bow;
    public InventoryManager inventory;
    
    public Items swordItem;
    public Items bowItem;
    
    void Update()
    {
        if (Input.GetButtonDown("ChangeSword")) {
            sword.enabled = true;
            bow.enabled = false;
            inventory.ChangeWeapon(swordItem);
        }

        if (Input.GetButtonDown("ChangeBow")) {
            sword.enabled = false;
            bow.enabled = true;
            inventory.ChangeWeapon(bowItem);
        }
    }
}
