using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : ICommand
{
    public void Execute()
    {
        ReticleController.instance.MoveReticle(1);
    }

    public void Undo()
    {
        ReticleController.instance.MoveReticle(2);
    }
}
