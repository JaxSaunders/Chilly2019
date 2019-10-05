using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayers : MonoBehaviour
{

    public GameObject follower;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - 0.5f*follower.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follower.transform.position + offset;
    }
}
