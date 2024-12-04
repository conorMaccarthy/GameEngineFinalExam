using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    public void Execute()
    {
        ReticleController.instance.MoveReticle(3);
    }

    public void Undo()
    {
        ReticleController.instance.MoveReticle(4);
    }
}
