using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Stat))]
public class P_InputHandler : MonoBehaviour
{
    Stat stat;
    SO_PlayerStat cStat;
    P_AnimationHandler anim;
    Rigidbody rb;

    float xInput, zInput;
    bool isSprint;

    public UnityEvent<Stat> OnSkillOneEvent;

    private void Awake()
    {
        TryGetComponent<Stat>(out stat);
        TryGetComponent<P_AnimationHandler> (out anim);
        TryGetComponent<Rigidbody> (out rb);
        cStat = stat.SO_stat as SO_PlayerStat;
    }
    private void FixedUpdate()
    {
        Action_Move();
    }


    void Action_Move()
    {
        if (!stat.IsCanMove) return;

        float newVelocityZ = rb.linearVelocity.z;
        newVelocityZ += zInput * (zInput < 0 ? cStat.zBackwardAcceleration : cStat.zForwardAcceleration);
        newVelocityZ = Mathf.Clamp(newVelocityZ, -cStat.zBackwardSpeed, cStat.zForwardSpeed);

        float newVelocityX = rb.linearVelocity.x + xInput * cStat.xAcceleration;
        bool isMoving = (zInput != 0) || (xInput != 0);

        if (zInput < 0) // Round up to 2 decimals to prevent "e" decimals value
        {
            newVelocityX = Mathf.Clamp(newVelocityX, -cStat.xBackwardSpeed, cStat.xBackwardSpeed);
            float xAnim = (float) System.Math.Round(newVelocityX / cStat.xBackwardSpeed, 2);
            float zAnim = (float) System.Math.Round(newVelocityZ / cStat.zBackwardSpeed, 2);
            anim.Animation_Walk(xAnim, zAnim, isMoving, isSprint);
        }
        else
        {
            newVelocityX = Mathf.Clamp(newVelocityX, -cStat.xForwardSpeed, cStat.xForwardSpeed);
            float xAnim = (float) System.Math.Round(newVelocityX / cStat.xForwardSpeed, 2);
            float zAnim = (float) System.Math.Round(newVelocityZ / cStat.zForwardSpeed, 2);
            anim.Animation_Walk(xAnim, zAnim, isMoving, isSprint);
        }

        rb.linearVelocity = new Vector3(newVelocityX, rb.linearVelocity.y, newVelocityZ);
    }


    #region Input Handlers
    void OnMove(InputValue value)
    { 
        Vector2 input = value.Get<Vector2>();

        xInput = input.x;
        zInput = input.y;
    }
    void OnSprint(InputValue value)
    {
        isSprint = value.Get<float>() == 1;
    }
    void OnAttackOne(InputValue value)
    {
        if (!stat.IsCanUseSkill) return;

        if (value.Get<float>() == 1)
            OnSkillOneEvent?.Invoke(stat);
    }
    #endregion
}
