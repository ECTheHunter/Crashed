using UnityEngine;

public class Item : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
          if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterModel>().IncreaseAclik(15f);
            other.gameObject.GetComponent<CharacterModel>().IncreaseOksijen(10f);
            other.gameObject.GetComponent<CharacterModel>().IncreaseSusuzluk(15f);
            other.gameObject.GetComponent<FPS_Movement>().lightsource = 15f;
            Destroy(gameObject);
        }
    }


}
