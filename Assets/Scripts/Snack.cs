using UnityEngine;

public class Snack : MonoBehaviour
{
    public int value = 1;

    // Static variable to track snacks directly in the Snack class
    public static int totalSnacksCollected = 0;

    public void Eat()
    {
        Debug.Log("Yum!");

        // Increment our own static counter
        totalSnacksCollected += value;

        // Log the current total
        Debug.Log("Snacks collected: " + totalSnacksCollected);

        Destroy(gameObject);
    }

    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Eat();
    }
}
