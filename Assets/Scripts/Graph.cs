using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField, Range(10,100)]
    int resolution = 10;

    Transform[] points;

    private void Awake()
    {
        // Creating the array with 'resolution' size.
        points = new Transform[resolution];
        
        // Math outside of loops is more efficient!
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = ((i + .5f) * step - 1f);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);

            points[i] = point;
        }
    }

    private void Update()
    {
        float time = Time.time;
        for(int i = 0; i < resolution; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}
