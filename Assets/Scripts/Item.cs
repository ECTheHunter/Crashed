using UnityEngine;

public class Item : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharacterModel>().IncreaseAclik(15f);
            other.GetComponent<CharacterModel>().IncreaseOksijen(10f);
            other.GetComponent<CharacterModel>().IncreaseSusuzluk(15f);
            other.GetComponent<FPS_Movement>().lightsource = 15f;
            Destroy(gameObject);
        }
    }


}
