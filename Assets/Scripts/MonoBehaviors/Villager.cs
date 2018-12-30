using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Job
{
    Move move;
    private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = true;
        move = GetComponentInParent<Move>();
        jobName = "Villager";
    }

    // Update is called once per frame
    void Update()
    {
        Strolling();
    }

    private void Strolling()
    {
        if (move.IsArrivedAtDestination())
        {
            float x = (toggle) ? (transform.position.x + 3f) : transform.position.x - 3f;
            Vector3 newPosition = new Vector3(x, transform.position.y);
            move.SetDestination(newPosition);
            toggle = !toggle;
        }
        move.MoveToDestination();
    }

    private void OnEnable()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponentInParent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }

    private void OnDisable()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponentInParent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.white);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }
}
