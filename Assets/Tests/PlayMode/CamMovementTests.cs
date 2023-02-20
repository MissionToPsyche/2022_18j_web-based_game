using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CamMovementTests
{
    [UnityTest]
    public IEnumerator Forward()
    {
        var camObject = new GameObject();
        var player = camObject.AddComponent<camera_view>();

        var originalPosition = player.transform.position;

        player.moveForward();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(originalPosition.x, player.transform.position.x);
        Assert.AreNotEqual(originalPosition.z, player.transform.position.z);
        Assert.IsTrue(originalPosition.z < player.transform.position.z);
    }

    [UnityTest]
    public IEnumerator Backword()
    {
        var camObject = new GameObject();
        var player = camObject.AddComponent<camera_view>();

        var originalPosition = player.transform.position;

        player.moveBackword();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(originalPosition.x, player.transform.position.x);
        Assert.AreNotEqual(originalPosition.z, player.transform.position.z);
        Assert.IsTrue(originalPosition.z > player.transform.position.z);
    }

    [UnityTest]
    public IEnumerator Left()
    {
        var camObject = new GameObject();
        var player = camObject.AddComponent<camera_view>();

        var originalPosition = player.transform.position;

        player.moveLeft();

        yield return new WaitForSeconds(0.1f);

        Assert.AreNotEqual(originalPosition.x, player.transform.position.x);
        Assert.AreEqual(originalPosition.z, player.transform.position.z);
        Assert.IsTrue(originalPosition.x > player.transform.position.x);
    }

    [UnityTest]
    public IEnumerator Right()
    {
        var camObject = new GameObject();
        var player = camObject.AddComponent<camera_view>();

        var originalPosition = player.transform.position;

        player.moveRight();

        yield return new WaitForSeconds(0.1f);

        Assert.AreNotEqual(originalPosition.x, player.transform.position.x);
        Assert.AreEqual(originalPosition.z, player.transform.position.z);
        Assert.IsTrue(originalPosition.x < player.transform.position.x);
    }

    [Test]
    public void LookAround()
    {
        var camObject = new GameObject();
        var player = camObject.AddComponent<camera_view>();

        var ogCamPosition = player.transform.eulerAngles;

        var mdMouseMoveY = -1f;
        var mdMouseMoveX = 1f;

        player.Look(mdMouseMoveY, mdMouseMoveX);

        Assert.AreNotEqual(ogCamPosition, player.transform.eulerAngles);
    }
}