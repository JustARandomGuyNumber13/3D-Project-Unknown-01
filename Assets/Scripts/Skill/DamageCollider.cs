using UnityEngine;
using UnityEngine.Events;

public class DamageCollider : MonoBehaviour
{
    public SO_AttackData.ColliderType[] Type;
    public UnityEvent<Collider> OnTriggerEnterEvent;
    Collider col;
    private void Awake()
    {
        TryGetComponent(out col);
    }
    private void OnEnable()
    {
        col.enabled = true;
    }
    private void OnDisable()
    {
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other);
    }
}
