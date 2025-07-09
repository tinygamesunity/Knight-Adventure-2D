using UnityEngine;

public class DestructiblePlantVisual : MonoBehaviour
{
    [SerializeField] private DestructiblePlant destructiblePlant;
    [SerializeField] private GameObject bushDeathVFXPrefab;

    private void Start()
    {
        destructiblePlant.OnDestructibleTakeDamage += DestructiblePlant_OnDestructibleTakeDamage;
    }

    private void DestructiblePlant_OnDestructibleTakeDamage(object sender, System.EventArgs e)
    {
        ShowDeathVFX();
    }

    private void ShowDeathVFX()
    {
        Instantiate(bushDeathVFXPrefab, destructiblePlant.transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        destructiblePlant.OnDestructibleTakeDamage -= DestructiblePlant_OnDestructibleTakeDamage;
    }
}
