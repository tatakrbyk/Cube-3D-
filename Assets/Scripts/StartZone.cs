
using UnityEngine;

public class StartZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if(cube != null)
        {
            if(!cube.isMainCube && cube.CubeRigidbody.velocity.magnitude < .1f)
            {
                // TODO: GameOver Popup
                Debug.Log("Game Over");
            }
        }
    }
}
