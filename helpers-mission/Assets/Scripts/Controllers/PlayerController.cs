using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use this to create an instance of the script from the menu.
[CreateAssetMenu(fileName ="PlayerController", menuName ="InputController/PlayerController")]
public class PlayerController : InputController
{
    //Implementing the methods
    public override bool RetrieveJumpInput()
    {
        return Input.GetKeyDown(KeyCode.J); //listen jump button down event
    }
    
    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal"); //listen to horizontal axis
    }
}
