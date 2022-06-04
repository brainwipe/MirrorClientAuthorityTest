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

    [Server]
    public void RemoveAuthority()
    {
        netIdentity.RemoveClientAuthority();
        Debug.Log($"No player has authority, connection to client? {netIdentity.connectionToClient != null}");
    }

    [Server]
    public void GiveAuthority(NetworkConnectionToClient playerConnection)
    {
        netIdentity.AssignClientAuthority(playerConnection);
        Debug.Log($"Player {netIdentity.connectionToClient.connectionId} has authority");
    }
}
