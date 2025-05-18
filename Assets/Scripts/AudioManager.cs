using UnityEngine;

public class AudioManager : MonoBehaviour
{
   static GameObject instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

       instance = gameObject;
        DontDestroyOnLoad(gameObject);

    }

   
}
