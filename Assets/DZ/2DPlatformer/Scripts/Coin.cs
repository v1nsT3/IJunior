using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction OnPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rogue rogue))
        {
            OnPickup?.Invoke();
            Destroy(gameObject);
        }
    }
}
