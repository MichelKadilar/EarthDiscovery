using UnityEngine;

public class Levitation : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public bool rotate = true;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 30, 0) * (Time.deltaTime*frequency));
        }
    }
}