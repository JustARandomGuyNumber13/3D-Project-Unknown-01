using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_InputHandler : MonoBehaviour
{
    [SerializeField] SO_CharacterStat cStat;
    P_AnimationHandler anim;
    Rigidbody rb;

    float xInput, zInput;
    bool isSprint;

    private void Awake()
    {
        TryGetComponent<P_AnimationHandler> (out anim);
        TryGetComponent<Rigidbody> (out rb);
    }
    private void FixedUpdate()
    {
        Action_Move();
    }


    void Action_Move()
    {
        float newVelocityX = Mathf.Clamp(rb.linearVelocity.x + xInput * cStat.acceleration, -cStat.xTopSpeed, cStat.xTopSpeed);
        float newVelocityZ = Mathf.Clamp(rb.linearVelocity.z + zInput * cStat.acceleration, -cStat.zTopSpeed, cStat.zTopSpeed);
        rb.linearVelocity = new Vector3 (newVelocityX, rb.linearVelocity.y, newVelocityZ);

        anim.Animation_Walk(newVelocityX / cStat.xTopSpeed, newVelocityZ / cStat.zTopSpeed, isSprint);
    }


    void OnMove(InputValue value)
    { 
        Vector2 input = value.Get<Vector2>();

        //if (input.x < 0) xInput = -1;
        //else if (input.x > 0) xInput = 1;
        //else xInput = 0;

        //if (input.y < 0) zInput = -1;
        //else if (input.y > 0) zInput = 1;
        //else zInput = 0;

        xInput = input.x;
        zInput = input.y;
    }
    void OnSprint(InputValue value)
    {
        isSprint = value.Get<float>() == 1;
    }
}
