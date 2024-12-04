using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Invoker invoker;
    public bool isReversed;
    private bool missed;

    private GameObject[] activeEnemies;
    private GameObject[] activeDecoys;

    private void Start()
    {
        invoker = GameObject.Find("Invoker").GetComponent<Invoker>();
        isReversed = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ICommand newCommand = new MoveUpCommand();
            if (!isReversed) invoker.ExecuteCommand(newCommand);
            else invoker.UndoCommand(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ICommand newCommand = new MoveLeftCommand();
            if (!isReversed) invoker.ExecuteCommand(newCommand);
            else invoker.UndoCommand(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ICommand newCommand = new MoveDownCommand();
            if (!isReversed) invoker.ExecuteCommand(newCommand);
            else invoker.UndoCommand(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ICommand newCommand = new MoveRightCommand();
            if (!isReversed) invoker.ExecuteCommand(newCommand);
            else invoker.UndoCommand(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    private void Shoot()
    {
        missed = true;
        
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        activeDecoys = GameObject.FindGameObjectsWithTag("Decoy");

        foreach (GameObject enemy in activeEnemies)
        {
            //Had to make custom collision detection because OnCollisionEnter didn't work with my movement setup
            if (enemy.transform.position.x > transform.position.x - 1.5f && enemy.transform.position.x < transform.position.x + 1.5f &&
                enemy.transform.position.y > transform.position.y - 1 && enemy.transform.position.y < transform.position.y + 1)
            {
                UIManager.instance.UpdateScore(100);
                if (enemy.GetComponent<EnemyBehavior>() == null) enemy.GetComponent<BadEnemyBehavior>().Deactivate();
                else enemy.GetComponent<EnemyBehavior>().Deactivate();
                missed = false;
            }
        }

        foreach (GameObject decoy in activeDecoys)
        {
            //Had to make custom collision detection because OnCollisionEnter didn't work with my movement setup
            if (decoy.transform.position.x > transform.position.x - 1.5f && decoy.transform.position.x < transform.position.x + 1.5f &&
                decoy.transform.position.y > transform.position.y - 1 && decoy.transform.position.y < transform.position.y + 1)
            {
                isReversed = !isReversed;
                decoy.GetComponent<EnemyBehavior>().Deactivate();
                missed = false;
            }
        }

        if (missed)
        {
            UIManager.instance.UpdateLives(-1);
        }
    }
}
