using UnityEngine;

public class Block : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Blam!");
            Destroy(gameObject);
        }
    }
}