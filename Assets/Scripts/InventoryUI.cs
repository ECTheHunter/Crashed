using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{


    private TextMeshProUGUI itemText;

    private void Start()
    {
        itemText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateItemText(PlayerInventory playerInventory)
    {
        itemText.text = playerInventory.NumberofItems.ToString();
    }
}
