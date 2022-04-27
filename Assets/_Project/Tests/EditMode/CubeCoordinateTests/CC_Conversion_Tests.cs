using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CC_Conversion_Tests
{
    [Test] public void ConvertsToV3IntZero() {
        Assert.AreEqual(Vector3Int.zero, CubeCoordinate.zero.ToGrid());
    }
    [Test] public void ConvertsV3IntToCubeZero() {
        Assert.AreEqual(CubeCoordinate.zero, CubeCoordinate.ToCube(Vector3Int.zero));
    }
    [Test] public void CreatesCubeFromV3IntZero() {
        Assert.AreEqual(CubeCoordinate.zero, new CubeCoordinate(Vector3Int.zero));
    }

    [Test] public void Cube_to_NorthEast() {
        Assert.AreEqual(new Vector3Int(0, 1, 0), CubeCoordinate.upRight.ToGrid());
    }
    [Test] public void Cube_to_SouthEast() {
        Assert.AreEqual(new Vector3Int(0, -1, 0), CubeCoordinate.downRight.ToGrid());
    }
    [Test] public void Cube_to_NorthWest() {
        Assert.AreEqual(new Vector3Int(-1, 1, 0), CubeCoordinate.upLeft.ToGrid());
    }
    [Test] public void Cube_to_SouthWest() {
        Assert.AreEqual(new Vector3Int(-1, -1, 0), CubeCoordinate.downLeft.ToGrid());
    }
    [Test] public void Cube_to_East() {
        Assert.AreEqual(new Vector3Int(1, 0, 0), CubeCoordinate.right.ToGrid());
    }
    [Test] public void Cube_to_West() {
        Assert.AreEqual(new Vector3Int(-1, 0, 0), CubeCoordinate.left.ToGrid());
    }

    [Test] public void V3Int_to_NorthEast() {
        var v = new Vector3Int(0, 1, 0);
        Assert.AreEqual(CubeCoordinate.upRight, new CubeCoordinate(v));
    }
    [Test] public void V3Int_to_SouthEast() {
        var v = new Vector3Int(0, -1, 0);
        Assert.AreEqual(CubeCoordinate.downRight, new CubeCoordinate(v));
    }
    [Test] public void V3Int_to_NorthWest() {
        var v = new Vector3Int(-1, 1, 0);
        Assert.AreEqual(CubeCoordinate.upLeft, new CubeCoordinate(v));
    }
    [Test] public void V3Int_to_SouthWest() {
        var v = new Vector3Int(-1, -1, 0);
        Assert.AreEqual(CubeCoordinate.downLeft, new CubeCoordinate(v));
    }
    [Test] public void V3Int_to_East() {
        var v = new Vector3Int(1, 0, 0);
        Assert.AreEqual(CubeCoordinate.right, new CubeCoordinate(v));
    }
    [Test] public void V3Int_to_West() {
        var v = new Vector3Int(-1, 0, 0);
        Assert.AreEqual(CubeCoordinate.left, new CubeCoordinate(v));
    }
}
