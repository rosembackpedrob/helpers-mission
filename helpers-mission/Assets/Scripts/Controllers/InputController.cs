using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Abstraction from the Input Source. This Class can be used to represent a generic input.

public abstract class InputController : ScriptableObject /*add the abstract modifier to the class, 
and change the base class to ScriptableObject*/
{
    public abstract float RetrieveMoveInput();
    
    public abstract bool RetrieveJumpInput();
}
