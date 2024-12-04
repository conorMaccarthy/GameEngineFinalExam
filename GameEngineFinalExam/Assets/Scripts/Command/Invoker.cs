using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }

    public void UndoCommand(ICommand command)
    {
        command.Undo();
    }
}
