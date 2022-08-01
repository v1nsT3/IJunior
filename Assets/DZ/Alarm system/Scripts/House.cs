using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction<bool> OnEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            OnEntered?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            OnEntered?.Invoke(false);
        }
    }
}
