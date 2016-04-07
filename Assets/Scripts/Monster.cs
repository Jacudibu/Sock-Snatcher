﻿using UnityEngine;
using System.Collections;

public class Monster : NetworkObject
{

    public float speed = 5f;

	public override void Start ()
    {
        base.Start();

        // #TODO: Play door sound

        // Tell the child it's about time to wake up
        StartCoroutine(WakeChildUp());
    }
	
	public override void Update ()
    {
        base.Update();

        if (!hasAuthority)
            return;

        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
	}

    IEnumerator WakeChildUp()
    {
        yield return new WaitForSeconds(2f);
        CameraFade.instance.FadeAndSendMessageAfterwards(Color.clear, "StartGame", FindObjectOfType<Child>());
    }
}
