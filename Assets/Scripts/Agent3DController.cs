using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Agent3DController : MonoBehaviour, IAgentController

{
    private IStepsController<Step> _controller;
    private Vector3 _target;
    private float _prevTime;
    private Rigidbody _rigidbody;
    
    private Vector3 _initialPos;
    private Vector3 _initialRot;

    public string sourceFilePath;
    public Mesh[] meshes;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;
        _initialRot = transform.rotation.eulerAngles;

        _controller = new FileStepsController<Step>(sourceFilePath, Step.FromLine);
        _prevTime = Time.fixedTime;
        Step firstStep = _controller.GetNext();
        transform.position = _initialPos + firstStep.Position;
        transform.rotation = Quaternion.Euler(_initialRot+firstStep.Rotation);
        ChangeShape(firstStep.Shape);
        ChangeColor(firstStep.Color);
        
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime - _prevTime >= _controller.DeltaTime)
        {
            if (!NextStep())
            {
                _rigidbody.velocity = Vector3.zero;
                enabled = false;
            }
        }
    }

    public void ChangeShape(string s)
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        switch (s)
        {
            case "square": meshFilter.mesh = meshes[0]; break;
            case "circle": meshFilter.mesh = meshes[1]; break;
            case "triangle": meshFilter.mesh = meshes[2]; break;
            default: meshFilter.mesh = meshes[0]; break;
        }
    }

    public void ChangeColor(string s)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        switch (s)
        {
            case "blue": meshRenderer.material.color = Color.blue; break;
            case "green": meshRenderer.material.color = Color.green; break;
            case "yellow": meshRenderer.material.color = Color.yellow; break;
            case "red": meshRenderer.material.color = Color.red; break;
            case "cyan": meshRenderer.material.color = Color.cyan; break;
            case "black": meshRenderer.material.color = Color.black; break;
            case "gray": meshRenderer.material.color = Color.gray; break;
            case "magenta": meshRenderer.material.color = Color.magenta; break;
            case "white": meshRenderer.material.color = Color.white; break;
            default: meshRenderer.material.color = Color.white; break;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public bool NextStep()
    {
        Step nextStep = _controller.GetNext();
        if (nextStep == null)
        {
            return false;
        }

        _target = _initialPos + nextStep.Position;
        _rigidbody.velocity = (_target - transform.position) / _controller.DeltaTime;
        transform.rotation = Quaternion.Euler(_initialRot+nextStep.Rotation);
        ChangeShape(nextStep.Shape);
        ChangeColor(nextStep.Color);
        _prevTime = Time.fixedTime;
        
        return true;
    }
}
