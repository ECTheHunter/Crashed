using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   
    public int NumberofItems {  get; private set; }

    public UnityEvent<PlayerInventory> OnItemCollected;

    public void ItemCollected()
    {
        NumberofItems++;
        OnItemCollected?.Invoke(this);
    }


}
