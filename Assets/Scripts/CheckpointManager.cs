using DefaultNamespace;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var restartable = col.GetComponent<RestartableGameObject>();
        if (restartable != null)
        {
            restartable.UpdateState();
        }
    }
}
