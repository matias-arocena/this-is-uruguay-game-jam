using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _jonny;
    [SerializeField] private GameObject _tommy;
    [SerializeField] private GameObject _deathWall;

    private Vector3 _jonnyStartPosition;
    private Vector3 _tommyStartPosition;
    private Vector3 _deathWallStartPosition;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _jonnyStartPosition = _jonny.transform.position;
        _tommyStartPosition = _tommy.transform.position;
        _deathWallStartPosition = _deathWall.transform.position;
    }

    public void Restart()
    {
        _jonny.transform.position = _jonnyStartPosition;
        _tommy.transform.position = _tommyStartPosition;
        _deathWall.transform.position = _deathWallStartPosition;

        _jonny.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        _tommy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        
        _deathWall.GetComponent<WallMovement>().Restart();
    }

}
