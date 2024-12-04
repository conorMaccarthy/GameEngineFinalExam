using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    public void Execute()
    {
        ReticleController.instance.MoveReticle(4);
    }

    public void Undo()
    {
        ReticleController.instance.MoveReticle(3);
    }
}
