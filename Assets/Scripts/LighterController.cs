
using DefaultNamespace;
using UnityEngine;

public class LighterController : RestartableGameObject
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

        if (Input.GetButtonUp("Fire") && _currentFlame.gameObject != null)
        {
            Destroy(_currentFlame.gameObject);
        }
    }
    
    public override void Restart()
    {
        if (_currentFlame != null)
        {
            Destroy(_currentFlame.gameObject);
        }        
    }
}
