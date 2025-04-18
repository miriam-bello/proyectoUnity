using UnityEngine;

public class InicioSceneGranja : MonoBehaviour
{
    public GameObject playerInstance;
    private bool isInitialized = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInstance = GameObject.FindWithTag("Player");
        playerInstance.transform.SetLocalPositionAndRotation(transform.position, playerInstance.transform.localRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized)
        {
            playerInstance = GameObject.FindWithTag("Player");
            playerInstance.transform.SetLocalPositionAndRotation(transform.position, playerInstance.transform.localRotation);
            isInitialized = true;
        }


    }
}
