using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameObject instance;
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
