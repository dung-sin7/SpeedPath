using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float rotateSpeed = 30f;

    [SerializeField] DriveMode driveMode = DriveMode.Manual;

    [SerializeField] Transform nextTarget;
    [SerializeField] List<Transform> points;
    [SerializeField] int currentIndex = 0;

    private void Reset()
    {
        this.LoadComponents();
    }
    // Start is called before the first frame update
    private void Awake()
    {
        this.LoadComponents();
    }

    private void LoadComponents()
    {
        this.LoadPoints();
    }

    private void LoadPoints()
    {
        if (this.points.Count > 0)
            this.points.Clear();
        var points = GameObject.Find("Points");
        foreach (Transform point in points.transform) 
        { 
            this.points.Add(point);
        }
    }

    void Start()
    {
        this.nextTarget = this.points[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    void Move()
    {
        if (this.driveMode == DriveMode.Automatic)
        {
            this.AutoMoveOnPath();
        }

        else if (this.driveMode == DriveMode.Manual)
        {
            this.MoveByKeyboard();
        }
    }

    private void MoveByKeyboard()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 pos = transform.position + transform.forward * verticalInput * speed * Time.deltaTime;
   
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed * horizontalInput);
        transform.position = pos;

    }

    private void AutoMoveOnPath()
    {
        Vector3 target = new Vector3(this.nextTarget.position.x, transform.position.y, this.nextTarget.position.z);
        if (Vector3.Distance(transform.position, target) < 0.5)
        {
            this.currentIndex++;
            if (currentIndex >= this.points.Count)
                this.currentIndex = 0;
            this.nextTarget = this.points[currentIndex];
        }
        target = new Vector3(this.nextTarget.position.x, transform.position.y, this.nextTarget.position.z);
        this.transform.position = Vector3.MoveTowards(transform.position, target, this.speed * Time.deltaTime);
        this.transform.LookAt(target);
    }
}
