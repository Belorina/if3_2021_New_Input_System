using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveVector;
    public float movementSpeed;
    public CharacterController controller;

    public void ShootyMcShoot(InputAction.CallbackContext context)      // callback = que unity appelle quand event qui ce back   =/= fonction que pour etre appeler par un evenement par unity en reponce a un evenements   // context = information sur ce qui ce passe, tous les venements autour 'sous quelle conditions ' etc  
    {
        if (context.performed)
        {
            print("Pan!");
        }
        else if (context.canceled)
        {
            Debug.Log("*bruit de ball qui tombe*");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();        // entre chevrons = quelle est le type de valeur qu on veux aller chercher
        Debug.Log(moveVector);
    }

    void Update()
    {
        float y = 0;
        if (!controller.isGrounded)
        {
            y = -1; 
        }

        controller.Move(new Vector3(moveVector.x, y, moveVector.y) * Time.deltaTime * movementSpeed);
    }
}
