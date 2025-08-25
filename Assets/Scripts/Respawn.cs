using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    [SerializeField] float respawnStartDelay;
    [SerializeField] float respawnAnimationDelay;
    [SerializeField] float respawnEndDelay;

    WaitForSeconds startDelay;
    WaitForSeconds animationDelay;
    WaitForSeconds endDelay;

    public UnityEvent<float> OnRespawnStartEvent;
    public UnityEvent OnRespawnAnimationEvent;
    public UnityEvent OnRespawnEndEvent;


    private void Awake()
    {
        startDelay = new WaitForSeconds(respawnStartDelay);
        animationDelay = new WaitForSeconds(respawnAnimationDelay);
        endDelay = new WaitForSeconds(respawnEndDelay);
    }
    public void Activate(Stat stat)
    { 
        StartCoroutine(RespawnCoroutine(stat));
    }
    IEnumerator RespawnCoroutine(Stat stat)
    {
        yield return startDelay;
        stat.ResetHealth();
        OnRespawnStartEvent?.Invoke(stat.CurrentHealth);

        yield return animationDelay;
        OnRespawnAnimationEvent?.Invoke();

        yield return endDelay;
        stat.IsAlive = true;
        OnRespawnEndEvent?.Invoke();
    }
}
