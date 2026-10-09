using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos);
        if (hit == null)
        {
            return;
        }
        if(hit.TryGetComponent(out IClickable clickable))
        {
            clickable.OnHit();
        }
    }
}
