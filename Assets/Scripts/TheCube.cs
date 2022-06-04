using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCube : NetworkBehaviour
{
    [Server]
    private void Update()
    {
        if (netIdentity.connectionToClient == null)
        {
            transform.position = new Vector3(0, Mathf.Sin(Time.time) * 3, 0);
        }
        else
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * 2, 0, 0);
        }
    }
}
