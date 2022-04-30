
using UnityEngine;

public class LighterController : MonoBehaviour
{
    [SerializeField] private SetShitOnFireBehaviour flame;

    private SetShitOnFireBehaviour _currentFlame;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            _currentFlame = Instantiate(flame, gameObject.transform);
        }

        if (Input.GetButtonUp("Fire"))
        {
            Destroy(_currentFlame.gameObject);
        }
    }
}
