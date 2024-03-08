using UnityEngine;

public class clicker : MonoBehaviour
{
    private void OnMouseDown()//om man klickar på spriten så förminskas den
    {
        transform.localScale = Vector3.one;
    }
}
