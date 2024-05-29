using UnityEngine;

public class boxScript : MonoBehaviour
{
   [SerializeField] private Collision2D  _collission2D;
   public void OnCollisionEnter2D(Collision2D other) 
   {
      Destroy(this.gameObject);
   }
}
