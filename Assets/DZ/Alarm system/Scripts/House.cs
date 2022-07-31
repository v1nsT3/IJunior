using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction OnHouseEntered;
    public event UnityAction OnHouseOuted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThiefMovement thief))
        {
            OnHouseEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ThiefMovement thief))
        {
            OnHouseOuted?.Invoke();
        }
    }
}
