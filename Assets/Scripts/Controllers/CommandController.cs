using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CommandController : MonoBehaviour
{
    private Queue<Command> commands = new Queue<Command>();
    private Command currentCommand;
    private NavMeshAgent agent;
    private LineRenderController lineController;
    private List<Vector3> points;

    private AnimationController animController;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        lineController = FindObjectOfType<LineRenderController>();
        points = new List<Vector3>();

        animController = GetComponent<AnimationController>();
    }


    private void Start()
    {
        points.Add(transform.position);
    }

    void Update()
    {
        processComands();
        drawPath();
    }

    private void processComands() {

        if (currentCommand != null && currentCommand.isFinished == false)
        {

            animController.setMoveAnim(true);

            return;
        }

    


        if (commands.Any() == false)
        {
            animController.setMoveAnim(false);
            return;
        }


        currentCommand = commands.Dequeue();
        currentCommand.Execute();

    }

    public void addCommands(Vector3 destination) {


        points.Add(destination);
        commands.Enqueue(new MoveCommand(destination, agent));

    }

    private void drawPath()
    {
  
        lineController.setUpLine(points);

    }


}
