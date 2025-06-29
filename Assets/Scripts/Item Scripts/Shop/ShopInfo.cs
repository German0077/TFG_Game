using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ShopInfo : MonoBehaviour
{
    public CanvasGroup infoPanel;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    
    [Header ("Stat Field")]
    public TMP_Text[] statText;

    private RectTransform infoPanelRect;

    private void Awake() {
        infoPanelRect = GetComponent<RectTransform>();
    }

    public void ShowInfo(Items item) {
        infoPanel.alpha = 1;
        nameText.text = item.itemName;
        descriptionText.text = item.itemDescription;
        
        List<string> stats = new List<string>();
        if (item.currentHealth > 0)
            stats.Add("Salud: " + item.currentHealth.ToString());
        if (item.speed > 0)
            stats.Add("Velocidad: " + item.speed.ToString());
        if (item.damage > 0)
            stats.Add("Daño: " + item.damage.ToString());
        if (item.duration > 0)
            stats.Add("Duración: " + item.duration.ToString());
        else
            stats.Add("");
            
        if (stats.Count <= 0)
            return;
        for (int i = 0; i < statText.Length; i++) {
            if (i < stats.Count) {
                statText[i].text = stats[i];
                statText[i].gameObject.SetActive(true);
            } else {
                statText[i].gameObject.SetActive(false);
            }
        }
    }

    public void HideInfo() {
        infoPanel.alpha = 0;
        nameText.text = "";
        descriptionText.text = "";
    }  
}
