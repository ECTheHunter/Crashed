using UnityEngine;

public class Item : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ItemCollected();
            gameObject.SetActive(false);
        }
    }


}
