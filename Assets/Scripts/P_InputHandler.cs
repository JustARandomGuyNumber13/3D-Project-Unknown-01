using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_InputHandler : MonoBehaviour
{
    P_AnimationHandler anim;

    float xInput, yInput;
    bool isSprint;

    private void Awake()
    {
        TryGetComponent<P_AnimationHandler> (out anim);
    }
    private void FixedUpdate()
    {
        Action_Move();
    }


    void Action_Move()
    {
        anim.Animation_Walk(xInput, yInput, isSprint);
    }


    void OnMove(InputValue value)
    { 
        Vector2 input = value.Get<Vector2>();

        if (input.x < 0) xInput = -1;
        else if (input.x > 0) xInput = 1;
        else xInput = 0;

        if (input.y < 0) yInput = -1;
        else if (input.y > 0) yInput = 1;
        else yInput = 0;
    }
    void OnSprint(InputValue value)
    {
        isSprint = value.Get<float>() == 1;
    }
}
