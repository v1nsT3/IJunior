using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction OnEntered;
    public event UnityAction OnOuted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            OnEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            OnOuted?.Invoke();
        }
    }
}
