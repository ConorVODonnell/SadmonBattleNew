using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CC_Sextant_Tests
{
    [Test] public void Sextant0_A() {
        var c = 2 * CubeCoordinate.right;
        Assert.AreEqual(0, c.GetSextant());
    }
    [Test] public void Sextant0_B() {
        var c = CubeCoordinate.right + CubeCoordinate.upRight;
        Assert.AreEqual(0, c.GetSextant());
    }
    [Test] public void Sextant1_A() {
        var c = 2 * CubeCoordinate.upRight;
        Assert.AreEqual(1, c.GetSextant());
    }
    [Test] public void Sextant1_B() {
        var c = CubeCoordinate.upRight + CubeCoordinate.upLeft;
        Assert.AreEqual(1, c.GetSextant());
    }
    [Test] public void Sextant2_A() {
        var c = 2 * CubeCoordinate.upLeft;
        Assert.AreEqual(2, c.GetSextant());
    }
    [Test] public void Sextant2_B() {
        var c = CubeCoordinate.upLeft + CubeCoordinate.left;
        Assert.AreEqual(2, c.GetSextant());
    }
    [Test] public void Sextant3_A() {
        var c = 2 * CubeCoordinate.left;
        Assert.AreEqual(3, c.GetSextant());
    }
    [Test] public void Sextant3_B() {
        var c = CubeCoordinate.left + CubeCoordinate.downLeft;
        Assert.AreEqual(3, c.GetSextant());
    }
    [Test] public void Sextant4_A() {
        var c = 2 * CubeCoordinate.downLeft;
        Assert.AreEqual(4, c.GetSextant());
    }
    [Test] public void Sextant4_B() {
        var c = CubeCoordinate.downLeft + CubeCoordinate.downRight;
        Assert.AreEqual(4, c.GetSextant());
    }
    [Test] public void Sextant5_A() {
        var c = 2 * CubeCoordinate.downRight;
        Assert.AreEqual(5, c.GetSextant());
    }
    [Test] public void Sextant5_B() {
        var c = CubeCoordinate.downRight + CubeCoordinate.right;
        Assert.AreEqual(5, c.GetSextant());
    }
    [Test] public void Sextant6_Position000() {
        var c = CubeCoordinate.zero;
        Assert.AreEqual(6, c.GetSextant());
    }

    [Test] public void GetSextantPreservesOriginalCoordinate() {
        var c = CubeCoordinate.left + CubeCoordinate.upLeft;
        c.GetSextant();
        Assert.AreEqual(CubeCoordinate.left + CubeCoordinate.upLeft, c);
    }

    [Test] public void IdentityIsSextant0() {
        var c = CubeCoordinate.downRight + CubeCoordinate.right;

        var s = c.GetSextant();
        var idC = c.Identity();
        var s_idC = idC.GetSextant();

        Assert.AreEqual(5, s);
        Assert.AreEqual(0, s_idC);
    }
    [Test] public void IdentityPreservesOriginalCoordinate() {
        var c = CubeCoordinate.left + CubeCoordinate.upLeft;
        c.Identity();
        Assert.AreEqual(CubeCoordinate.left + CubeCoordinate.upLeft, c);
    }
}
