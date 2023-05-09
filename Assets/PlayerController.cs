using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

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
        this.MoveOnPath();
    }

    private void MoveOnPath()
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
