using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : ICommand
{
    public void Execute()
    {
        ReticleController.instance.MoveReticle(2);
    }

    public void Undo()
    {
        ReticleController.instance.MoveReticle(1);
    }
}
