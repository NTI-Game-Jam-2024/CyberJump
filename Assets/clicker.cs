using UnityEngine;

public class clicker : MonoBehaviour
{
    private void OnMouseDown()//om man klickar p� spriten s� f�rminskas den
    {
        transform.localScale = Vector3.one;
    }
}
