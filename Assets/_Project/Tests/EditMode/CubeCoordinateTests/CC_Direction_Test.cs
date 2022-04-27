using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CC_Direction_Test
{
    [Test] public void NorthEast() {
        CubeCoordinate c = CubeCoordinate.upRight;
        Assert.AreEqual(c.q, 0);
        Assert.AreEqual(c.r, 1);
        Assert.AreEqual(c.s, -1);
    }
    [Test] public void SouthEast() {
        CubeCoordinate c = CubeCoordinate.downRight;
        Assert.AreEqual(c.q, 1);
        Assert.AreEqual(c.r, -1);
        Assert.AreEqual(c.s, 0);
    }
    [Test] public void NorthWest() {
        CubeCoordinate c = CubeCoordinate.upLeft;
        Assert.AreEqual(c.q, -1);
        Assert.AreEqual(c.r, 1);
        Assert.AreEqual(c.s, 0);
    }
    [Test] public void SouthWest() {
        CubeCoordinate c = CubeCoordinate.downLeft;
        Assert.AreEqual(c.q, 0);
        Assert.AreEqual(c.r, -1);
        Assert.AreEqual(c.s, 1);
    }
    [Test] public void East() {
        CubeCoordinate c = CubeCoordinate.right;
        Assert.AreEqual(c.q, 1);
        Assert.AreEqual(c.r, 0);
        Assert.AreEqual(c.s, -1);
    }
    [Test] public void West() {
        CubeCoordinate c = CubeCoordinate.left;
        Assert.AreEqual(c.q, -1);
        Assert.AreEqual(c.r, 0);
        Assert.AreEqual(c.s, 1);
    }
}
