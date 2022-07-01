using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In this script we'll take the input from another source
[CreateAssetMenu(fileName ="AIController", menuName ="InputController/AIController")]
public class AIController : InputController
{
    //no calculation, just simulating an AI input
    public override bool RetrieveJumpInput()
    {
        return true;
    }
    
    public override float RetrieveMoveInput()
    {
        return 1f;
    }
}
