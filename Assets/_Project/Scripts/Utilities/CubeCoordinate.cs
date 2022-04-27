using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public struct CubeCoordinate : IEquatable<CubeCoordinate>
{
    [SerializeField] private int m_Q;    //  0 along UpRight DownLeft,   +DownRight  -UpLeft
    [SerializeField] private int m_R;    //  0 along Horizontal,         +Up         -Down
    [SerializeField] private int m_S;    //  0 along UpLeft DownRight,   +DownLeft   -UpRight

    private static readonly CubeCoordinate s_Zero = new CubeCoordinate(0, 0, 0);
    private static readonly CubeCoordinate s_UpRight = new CubeCoordinate(0, 1, -1);
    private static readonly CubeCoordinate s_UpLeft = new CubeCoordinate(-1, 1, 0);
    private static readonly CubeCoordinate s_DownRight = new CubeCoordinate(1, -1, 0);
    private static readonly CubeCoordinate s_DownLeft = new CubeCoordinate(0, -1, 1);
    private static readonly CubeCoordinate s_Right = new CubeCoordinate(1, 0, -1);
    private static readonly CubeCoordinate s_Left = new CubeCoordinate(-1, 0, 1);

    //
    // Summary:
    //     Q component of the vector.
    public int q {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return m_Q;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set {
            m_Q = value;
        }
    }
    //
    // Summary:
    //     R component of the vector.
    public int r {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return m_R;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set {
            m_R = value;
        }
    }
    //
    // Summary:
    //     S component of the vector.
    public int s {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return m_S;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set {
            m_S = value;
        }
    }

    public static CubeCoordinate zero {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_Zero;
        }
    }
    public static CubeCoordinate upRight {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_UpRight;
        }
    }
    public static CubeCoordinate upLeft {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_UpLeft;
        }
    }
    public static CubeCoordinate downRight {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_DownRight;
        }
    }
    public static CubeCoordinate downLeft {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_DownLeft;
        }
    }
    public static CubeCoordinate right {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_Right;
        }
    }
    public static CubeCoordinate left {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get {
            return s_Left;
        }
    }

    //
    // Summary:
    //     Initializes and returns an instance of a new CubeCoordinate with q, r and s components
    //
    // Parameters:
    //   q:
    //     The Q component of the CubeCoordinate.
    //
    //   r:
    //     The R component of the CubeCoordinate.
    //
    //   s:
    //     The S component of the CubeCoordinate.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CubeCoordinate(int q, int r, int s) {
        if (q + r + s != 0) throw new ArgumentException($"q + r + s must equal zero to be a valid CubeCoordinate. You submitted q:{q} r:{r} s:{s}");
        m_Q = q;
        m_R = r;
        m_S = s;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CubeCoordinate(Vector3Int gridPos) {
        var q = gridPos.x - (gridPos.y - (gridPos.y & 1)) / 2;
        var r = gridPos.y;
        m_Q = q;
        m_R = r;
        m_S = -q - r;
    }

    public Vector3Int ToGrid() {
        var col = q + (r - (r & 1)) / 2;    // q + ((r down to nearest even) / 2)
        var row = r;
        return new Vector3Int(col, row);
    }
    public static CubeCoordinate ToCube(Vector2Int gridPos) {
        return ToCube((Vector3Int)gridPos);
    }
    public static CubeCoordinate ToCube(Vector3Int gridPos) {
        var q = gridPos.x - (gridPos.y - (gridPos.y & 1)) / 2;
        var r = gridPos.y;
        return new CubeCoordinate(q, r, -q - r);
    }

    public int Steps() {
        return Steps(this, CubeCoordinate.zero);
    }
    public int StepsTo(CubeCoordinate other) {
        return Steps(this, other);
    }
    public static int Steps(CubeCoordinate a, CubeCoordinate b) {
        var c = a - b;
        return ((Mathf.Abs(c.q) + Mathf.Abs(c.r) + Mathf.Abs(c.s)) / 2);
    }
    /// <summary>
    ///     Transforms the CubeCoord by rotating it 60 degrees clockwise
    /// </summary>
    public CubeCoordinate Rotate() {
        int temp = r;
        m_R = -q;
        m_Q = -s;
        m_S = -temp;
        return this;
    }
    public CubeCoordinate Rotate(int times) {
        for (int i = 0; i < (times % 6); i++)
            Rotate();
        return this;
    }
    public CubeCoordinate RotateCounterClockwise() {
        int temp = q;
        m_Q = -r;
        m_R = -s;
        m_S = -temp;
        return this;
    }
    public CubeCoordinate RotateCounterClockwise(int times) {
        for (int i = 0; i < (times % 6); i++)
            RotateCounterClockwise();
        return this;
    }
    public bool AtZero() {
        if (q == 0 && r == 0) return true;
        return false;
    }
    /// <summary>
    /// Returns the sextant (like Quadrant, but six) that contains this position, relative to center.<br/>
    /// A CubeCoordinate, rotated Clockwise, a number of times equal to its Sextant, will be in the 0 Sextant.<br/>
    /// 0 is UpRight, going counterClockwise<br/>
    /// If returns 6, it means it's in the center.
    /// </summary>
    /// <returns></returns>
    public int GetSextant() {
        var c = this;
        for (int sextant = 0; sextant < 6; sextant++) {
            if (c.q > 0 && c.r >= 0) return sextant;
            c.Rotate();
        }
        Debug.LogWarning("Coordinate is at (0, 0, 0), so Sextant = 6. Make sure to check AtZero if that's a possibility, before calling.");
        return 6;
    }
    public CubeCoordinate Identity() {
        int s = GetSextant();
        return SafeRotate(s);
    }
    public static CubeCoordinate Identity(Vector3Int position) {
        var c = ToCube(position);
        return c.Identity();
    }

    /// <summary>
    /// Returns a rotated CubeCordinate while preserving the original
    /// </summary>
    /// <returns></returns>
    public CubeCoordinate SafeRotate() {
        return new CubeCoordinate(-s, -q, -r);
    }
    public CubeCoordinate SafeRotate(int times) {
        var c = new CubeCoordinate(q, r, s);
        for (int i = 0; i < (times % 6); i++)
            c.Rotate();
        return c;

    }
    public CubeCoordinate SafeRotateCounterClockwise() {
        return new CubeCoordinate(-r, -s, -q);
    }
    public CubeCoordinate SafeRotateCounterClockwise(int times) {
        var c = new CubeCoordinate(q, r, s);
        for (int i = 0; i < (times % 6); i++)
            c.RotateCounterClockwise();
        return c;

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CubeCoordinate operator +(CubeCoordinate a, CubeCoordinate b) {
        return new CubeCoordinate(a.q + b.q, a.r + b.r, a.s + b.s);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CubeCoordinate operator -(CubeCoordinate a, CubeCoordinate b) {
        return new CubeCoordinate(a.q - b.q, a.r - b.r, a.s - b.s);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CubeCoordinate operator -(CubeCoordinate a) {
        return new CubeCoordinate(-a.q, -a.r, -a.s);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CubeCoordinate operator *(int a, CubeCoordinate b) {
        return new CubeCoordinate(a * b.q, a * b.r, a * b.s);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CubeCoordinate operator *(CubeCoordinate a, int b) {
        return new CubeCoordinate(a.q * b, a.r * b, a.s * b);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(CubeCoordinate lhs, CubeCoordinate rhs) {
        return lhs.q == rhs.q && lhs.r == rhs.r && lhs.s == rhs.s;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(CubeCoordinate lhs, CubeCoordinate rhs) {
        return !(lhs == rhs);
    }

    //
    // Summary:
    //     Returns true if the objects are equal.
    //
    // Parameters:
    //   other:
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object other) {
        if (!(other is CubeCoordinate)) {
            return false;
        }

        return Equals((CubeCoordinate)other);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(CubeCoordinate other) {
        return this == other;
    }
    //
    // Summary:
    //     Gets the hash code for the Vector3Int.
    //
    // Returns:
    //     The hash code of the Vector3Int.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() {
        int hashCode = r.GetHashCode();
        int hashCode2 = s.GetHashCode();
        return q.GetHashCode() ^ (hashCode << 4) ^ (hashCode >> 28) ^ (hashCode2 >> 4) ^ (hashCode2 << 28);
    }

    public override string ToString() {
        return string.Format("({0}, {1}, {2})", q.ToString(), r.ToString(), s.ToString());
    }
}

