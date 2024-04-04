using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    PlayerController inputActions;

    [SerializeField] private Transform[] where2shoot;
    [SerializeField] private GameObject[] Cannons;

    [SerializeField] ObjectPooling bulletPool;

    private void Awake()
    {
        inputActions = new PlayerController();
    }
    private void Start()
    {
        inputActions.Enable();
        inputActions.Controller.ShootC1.performed += ShootCannonN1;
        inputActions.Controller.ShootC2.performed += ShootCannonN2;
        inputActions.Controller.ShootC3.performed += ShootCannonN3;
        inputActions.Controller.ShootC4.performed += ShootCannonN4;
        inputActions.Controller.ShootC5.performed += ShootCannonN5;
    }

    void ShootCannonN1(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            GameObject tempBullet = bulletPool.RequestObject();
            tempBullet.transform.position = Cannons[0].transform.position;
            tempBullet.GetComponent<Bullet>().getDir(where2shoot[0]);
        }
    }
    
    void ShootCannonN2(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            if (context.ReadValue<float>() > 0)
            {
                GameObject tempBullet = bulletPool.RequestObject();
                tempBullet.transform.position = Cannons[1].transform.position;
                tempBullet.GetComponent<Bullet>().getDir(where2shoot[1]);
            }
        }
    }

    void ShootCannonN3(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            if (context.ReadValue<float>() > 0)
            {
                GameObject tempBullet = bulletPool.RequestObject();
                tempBullet.transform.position = Cannons[2].transform.position;
                tempBullet.GetComponent<Bullet>().getDir(where2shoot[2]);
            }
        }
    }

    void ShootCannonN4(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            if (context.ReadValue<float>() > 0)
            {
                GameObject tempBullet = bulletPool.RequestObject();
                tempBullet.transform.position = Cannons[3].transform.position;
                tempBullet.GetComponent<Bullet>().getDir(where2shoot[3]);
            }
        }
    }

    void ShootCannonN5(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0)
        {
            if (context.ReadValue<float>() > 0)
            {
                GameObject tempBullet = bulletPool.RequestObject();
                tempBullet.transform.position = Cannons[4].transform.position;
                tempBullet.GetComponent<Bullet>().getDir(where2shoot[4]);
            }
        }
    }
}
