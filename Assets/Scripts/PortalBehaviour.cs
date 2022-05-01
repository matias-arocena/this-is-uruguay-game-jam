using Cinemachine;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] _deactivateEntities;
    [SerializeField] private GameObject[] _activateEntities;
    [SerializeField] private Transform _follow;

    private CinemachineVirtualCamera[] _cameras;

    private void Start()
    {
        _cameras = FindObjectsOfType<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Jonny") || col.gameObject.CompareTag("Player"))
        {
            foreach (var obj in _deactivateEntities)
            {
                obj.SetActive(false);
            }

            foreach (var obj in _activateEntities)
            {
                obj.SetActive(true);
            }
            
            foreach (var obj in _cameras)
            {
                obj.Follow = _follow;
            }
        }
    }
}
