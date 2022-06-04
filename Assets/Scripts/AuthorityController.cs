using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorityController : NetworkBehaviour
{
    TheCube theCube;

    private void Awake()
    {
        theCube = GameObject.Find("Cube").GetComponent<TheCube>(); ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AuthorityCommand();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveAuthorityCommand();
        }
    }

    [Command]
    private void AuthorityCommand()
    {
        theCube.GiveAuthority(netIdentity.connectionToClient);
    }

    [Command]
    private void RemoveAuthorityCommand()
    {
        theCube.RemoveAuthority();
    }
}
