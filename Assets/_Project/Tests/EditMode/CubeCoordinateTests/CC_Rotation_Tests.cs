using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CC_Rotation_Tests
{
    [Test] public void RotateClockwise(){
        CubeCoordinate c = CubeCoordinate.upLeft;
        c.Rotate();
        Assert.AreEqual(CubeCoordinate.upRight, c);
    }
    [Test] public void RotateClockwiseMultiple(){
        CubeCoordinate c = CubeCoordinate.upRight;
        c.Rotate(2);
        Assert.AreEqual(CubeCoordinate.downRight, c);
    }
    [Test] public void RotateClockwiseMultiple_0_StaysSame() {
        CubeCoordinate c = CubeCoordinate.upRight;
        c.Rotate(0);
        Assert.AreEqual(CubeCoordinate.upRight, c);
    }
    [Test] public void RotateClockwiseMultiple_6x_StaysSame() {
        CubeCoordinate c = CubeCoordinate.upRight;
        c.Rotate(12);
        Assert.AreEqual(CubeCoordinate.upRight, c);
    }
    [Test] public void RotateCounterClockwise() {
        CubeCoordinate c = CubeCoordinate.upLeft;
        c.RotateCounterClockwise();
        Assert.AreEqual(CubeCoordinate.left, c);
    }
    [Test] public void RotateCounterClockwiseMultiple(){
        CubeCoordinate c = CubeCoordinate.upRight;
        c.RotateCounterClockwise(2);
        Assert.AreEqual(CubeCoordinate.left, c);
    }
    [Test] public void RotateCounterClockwiseMultiple_0_StaysSame(){
        CubeCoordinate c = CubeCoordinate.upRight;
        c.RotateCounterClockwise(0);
        Assert.AreEqual(CubeCoordinate.upRight, c);
    }
    [Test] public void RotateCounterClockwiseMultiple_6x_StaysSame() {
        CubeCoordinate c = CubeCoordinate.downRight;
        c.Rotate(12);
        Assert.AreEqual(CubeCoordinate.downRight, c);
    }
    [Test] public void SafeRotate() {
        var c = CubeCoordinate.upRight;
        var n = c.SafeRotate();
        Assert.AreEqual(CubeCoordinate.upRight, c);
        Assert.AreEqual(CubeCoordinate.right, n);
    }
    [Test] public void SafeClockwiseRotateMultiple() {
        var c = CubeCoordinate.upRight;
        var n = c.SafeRotate(4);
        Assert.AreEqual(CubeCoordinate.upRight, c);
        Assert.AreEqual(CubeCoordinate.left, n);
    }
    [Test] public void SafeClockwiseRotateMultiple_0_StaysSame() {
        var c = CubeCoordinate.upRight;
        var n = c.SafeRotate(0);
        Assert.AreEqual(CubeCoordinate.upRight, c);
        Assert.AreEqual(CubeCoordinate.upRight, n);
    }
    [Test] public void SafeClockwiseRotateMultiple_6x_StaysSame() {
        var c = CubeCoordinate.upRight;
        var n = c.SafeRotate(18);
        Assert.AreEqual(CubeCoordinate.upRight, c);
        Assert.AreEqual(CubeCoordinate.upRight, n);
    }
    [Test] public void SafeClockwiseRotate() {
        var c = CubeCoordinate.upRight;
        var n = c.SafeRotate();
        Assert.AreEqual(CubeCoordinate.upRight, c);
        Assert.AreEqual(CubeCoordinate.right, n);
    }
    [Test] public void SafeRotateCounterClockwiseMultiple() {
        var c = CubeCoordinate.left;
        var n = c.SafeRotate(3);
        Assert.AreEqual(CubeCoordinate.left, c);
        Assert.AreEqual(CubeCoordinate.right, n);
    }
    [Test] public void SafeRotateCounterClockwiseMultiple_0_StaysSame() {
        var c = CubeCoordinate.downLeft;
        var n = c.SafeRotate(0);
        Assert.AreEqual(CubeCoordinate.downLeft, c);
        Assert.AreEqual(CubeCoordinate.downLeft, n);
    }
    [Test] public void SafeRotateCounterClockwiseMultiple_6x_StaysSame() {
        var c = CubeCoordinate.upLeft;
        var n = c.SafeRotate(18);
        Assert.AreEqual(CubeCoordinate.upLeft, c);
        Assert.AreEqual(CubeCoordinate.upLeft, n);
    }
}
