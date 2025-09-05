using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Stat))]
public class P_InputHandler : MonoBehaviour
{
    Stat stat;
    SO_PlayerStat cStat;
    P_AnimationHandler anim;
    SkillHandler skillHandler;
    Rigidbody rb;

    float xInput, zInput;
    bool isSprint;

    private void Awake()
    {
        TryGetComponent(out stat);
        TryGetComponent(out anim);
        TryGetComponent(out rb);
        TryGetComponent(out skillHandler);
        cStat = stat.statData as SO_PlayerStat;
    }
    private void FixedUpdate()
    {
        Action_Move();
    }


    void Action_Move()
    {
        if (!stat.IsCanMove || stat.IsStun)
        {
            anim.Animation_Walk(0, 0, false, false);
            return;
        }

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
    void Action_UseSkill(int index)
    {
        skillHandler.UseSkill(stat, index);
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
    void OnSkillOne(InputValue value)
    {
        if (value.Get<float>() == 1)
            Action_UseSkill(0);
    }
    void OnSkillTwo(InputValue value)
    {
        if (value.Get<float>() == 1)
            Action_UseSkill(1);
    }
    void OnSkillThree(InputValue value)
    {
        if (value.Get<float>() == 1)
            Action_UseSkill(2);
    }
    void OnSkillFour(InputValue value)
    {
        if (value.Get<float>() == 1)
            Action_UseSkill(3);
    }
    void OnSkillFive(InputValue value)
    {
        if (value.Get<float>() == 1)
            Action_UseSkill(4);
    }
    #endregion
}
