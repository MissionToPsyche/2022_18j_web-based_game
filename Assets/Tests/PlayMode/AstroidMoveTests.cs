using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class AstroidMoveTests
{

    [UnityTest]
    public IEnumerator AstroidMovesUp()
    {
        var objectA = new GameObject("Astroid");
        var astroid = objectA.AddComponent<MazeObjectMovement>();

        Rigidbody rbt = objectA.AddComponent<Rigidbody>();

        rbt.mass = 5;

        var originalPosition = astroid.transform.position;

        Vector3 input = new Vector3(0, 0, 100);

        yield return new WaitForFixedUpdate();

        astroid.MoveAstroid(input,rbt);

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(originalPosition.x, astroid.transform.position.x);
        Assert.AreNotEqual(originalPosition.z, astroid.transform.position.z);
        Assert.IsTrue(originalPosition.z < astroid.transform.position.z);
    }

    [UnityTest]
    public IEnumerator AstroidMovesDown()
    {
        var objectA = new GameObject("Astroid");
        var astroid = objectA.AddComponent<MazeObjectMovement>();

        Rigidbody rbt = objectA.AddComponent<Rigidbody>();

        rbt.mass = 5;

        var originalPosition = astroid.transform.position;

        Vector3 input = new Vector3(0, 0, -100);

        yield return new WaitForFixedUpdate();

        astroid.MoveAstroid(input, rbt);

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(originalPosition.x, astroid.transform.position.x);
        Assert.AreNotEqual(originalPosition.z, astroid.transform.position.z);
        Assert.IsTrue(originalPosition.z > astroid.transform.position.z);
    }

    [UnityTest]
    public IEnumerator AstroidMovesRight()
    {
        var objectA = new GameObject("Astroid");
        var astroid = objectA.AddComponent<MazeObjectMovement>();

        Rigidbody rbt = objectA.AddComponent<Rigidbody>();

        rbt.mass = 5;

        var originalPosition = astroid.transform.position;

        Vector3 input = new Vector3(100, 0, 0);

        yield return new WaitForFixedUpdate();

        astroid.MoveAstroid(input, rbt);

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(originalPosition.z, astroid.transform.position.z);
        Assert.AreNotEqual(originalPosition.x, astroid.transform.position.x);
        Assert.IsTrue(originalPosition.x < astroid.transform.position.x);
    }

    [UnityTest]
    public IEnumerator AstroidMovesLeft()
    {
        var objectA = new GameObject("Astroid");
        var astroid = objectA.AddComponent<MazeObjectMovement>();

        Rigidbody rbt = objectA.AddComponent<Rigidbody>();

        rbt.mass = 5;

        var originalPosition = astroid.transform.position;

        Vector3 input = new Vector3(-100, 0, 0);

        yield return new WaitForFixedUpdate();

        astroid.MoveAstroid(input, rbt);

        yield return new WaitForFixedUpdate();

        Assert.AreEqual(originalPosition.z, astroid.transform.position.z);
        Assert.AreNotEqual(originalPosition.x, astroid.transform.position.x);
        Assert.IsTrue(originalPosition.x > astroid.transform.position.x);
    }
}
