using UnityEngine;

public class PlantingSpotssss : MonoBehaviour
{

    private static GameObject instancePlantingSpotsss;

    void Awake()
    {
        if (gameObject == null) { 
        return;}

        if (instancePlantingSpotsss != null)
        {
            Destroy(gameObject);
            return;
        }
        instancePlantingSpotsss = gameObject;

        DontDestroyOnLoad(gameObject);

    }
}
