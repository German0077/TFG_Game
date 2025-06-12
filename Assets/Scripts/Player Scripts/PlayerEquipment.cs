using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public PlayerCombat sword;
    public PlayerBow bow;
    
    void Update()
    {
        if (Input.GetButtonDown("ChangeSword")) {
            sword.enabled = true;
            bow.enabled = false;
        }

        if (Input.GetButtonDown("ChangeBow")) {
            sword.enabled = false;
            bow.enabled = true;
        }
    }
}
