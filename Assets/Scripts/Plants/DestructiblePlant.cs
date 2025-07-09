using System;
using UnityEngine;

public class DestructiblePlant : MonoBehaviour
{

    public event EventHandler OnDestructibleTakeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Sword>())
        {
            OnDestructibleTakeDamage?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);

            NavMeshSurfaceManagement.Instance.RebakeNavmeshSurface();
        }
    }
}
