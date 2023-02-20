using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SceneTransTest
{
    [UnityTest]
    public IEnumerator SceneToConferenceRoom()
    {
        var doorObject = new GameObject();
        var door = doorObject.AddComponent<ToConRoom>();

        Scene ogScene = SceneManager.GetActiveScene();

        door.LoadConRoom();

        yield return new WaitForSeconds(0.1f);

        Scene ctScene = SceneManager.GetActiveScene();

        Assert.AreNotEqual(ogScene, ctScene);
    }

    [UnityTest]
    public IEnumerator SceneToOffice()
    {
        var doorObject = new GameObject();
        var door = doorObject.AddComponent<ToOfficeRoom>();

        Scene ogScene = SceneManager.GetActiveScene();

        door.LoadOffice();

        yield return new WaitForSeconds(0.1f);

        Scene ctScene = SceneManager.GetActiveScene();

        Assert.AreNotEqual(ogScene, ctScene);
    }

    [UnityTest]
    public IEnumerator SceneToMaze()
    {
        var doorObject = new GameObject();
        var door = doorObject.AddComponent<ChangeToMaze>();

        Scene ogScene = SceneManager.GetActiveScene();

        door.LoadMaze();

        yield return new WaitForSeconds(0.1f);

        Scene ctScene = SceneManager.GetActiveScene();

        Assert.AreNotEqual(ogScene, ctScene);
    }

    [UnityTest]
    public IEnumerator WinningMaze()
    {
        var objectA = new GameObject();
        var astroid = objectA.AddComponent<MazeObjectMovement>();

        Scene ogScene = SceneManager.GetActiveScene();

        astroid.FinishLine();

        yield return new WaitForSeconds(0.1f);

        Scene ctScene = SceneManager.GetActiveScene();

        Assert.AreNotEqual(ogScene, ctScene);
    }
}
