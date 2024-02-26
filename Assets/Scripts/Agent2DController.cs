using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Color = System.Drawing.Color;

public class Agent2DController : MonoBehaviour, IAgentController
{
    
    private IStepsController<Step> _controller;
    private Vector3 _target;
    private float _prevTime;
    private Rigidbody _rigidbody;

    private Vector3 _initialPos;
    private Vector3 _initialRot;
    
    public string sourceFilePath;
    public Sprite[] shapes;

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

    // ReSharper disable Unity.PerformanceAnalysis
    public void ChangeShape(string s)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        switch (s)
        {
            case "square": spriteRenderer.sprite = shapes[0]; break;
            case "circle": spriteRenderer.sprite = shapes[1]; break;
            case "triangle": spriteRenderer.sprite = shapes[2]; break;
            case "bird": spriteRenderer.sprite = shapes[3]; break;
            default: spriteRenderer.sprite = shapes[0]; break;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void ChangeColor(string s)
    {
        //TODO Can be optimised using RGB codes...
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        switch (s)
        {
            case "blue": spriteRenderer.color = UnityEngine.Color.blue; break;
            case "green": spriteRenderer.color = UnityEngine.Color.green; break;
            case "yellow": spriteRenderer.color = UnityEngine.Color.yellow; break;
            case "red": spriteRenderer.color = UnityEngine.Color.red; break;
            default: spriteRenderer.color = UnityEngine.Color.red; break;
        }
    }

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
