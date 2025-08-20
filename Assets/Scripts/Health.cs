using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    float curHealth;

    [SerializeField] bool isAutoRespawn;
    [SerializeField] float autoRespawnDelay;
    WaitForSecondsRealtime autoRespawn;

    [SerializeField] Animator anim;

    public UnityEvent<float> OnSetUpEvent;
    public UnityEvent<float> OnHealthChangeEvent;
    public UnityEvent OnHealthDecreaseEvent;
    public UnityEvent OnDieEvent;
    public UnityEvent OnRespawnEvent;

    private void Awake()
    {
        curHealth = MaxHealth;
        autoRespawn = new WaitForSecondsRealtime(autoRespawnDelay);
        OnSetUpEvent?.Invoke(curHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) TakeDamage(3);
    }
    public void TakeDamage(float damageAmount)
    {
        curHealth -= damageAmount;
        OnHealthChangeEvent?.Invoke(curHealth);

        if (curHealth < 0)
        {
            OnDieEvent?.Invoke();
            StartCoroutine(RespawnCoroutine());
            enabled = false;
        }  
        else
        {
            OnHealthDecreaseEvent?.Invoke();
        }
    }
    IEnumerator RespawnCoroutine()
    {
        if (!isAutoRespawn) yield break;

        // Knock down
        yield return null; // wait for animation swap then procceed, transition duration need to be 0
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length);
        yield return autoRespawn;

        // Healing
        curHealth = MaxHealth;
        OnHealthChangeEvent?.Invoke(curHealth);
        OnRespawnEvent?.Invoke();

        // Stand up
        yield return null; // wait for animation swap then procceed, transition duration need to be 0
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length);
        enabled = true;
    }
}
