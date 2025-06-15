using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{
    public string itemName;
    [TextArea] public string itemDescription;
    public Sprite icon;

    public bool isGold;

    [Header("Stats")]
    public int currentHealth;
    public int speed;
    public int damage;

    [Header("Temporary")]
    public float duration;
}
