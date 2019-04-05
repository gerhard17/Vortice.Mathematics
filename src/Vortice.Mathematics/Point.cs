﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vortice.Mathematics
{
    /// <summary>
    /// Defines an ordered pair of floating-point x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Represents a <see cref="Point"/> that has X and Y values set to zero.
        /// </summary>
        public static readonly Point Empty;

        /// <summary>
        /// Gets or sets the x-coordinate of this <see cref="Point"/>.
        /// </summary>
        public float X;

        /// <summary>
        /// Gets or sets the y-coordinate of this <see cref="Point"/>.
        /// </summary>
        public float Y;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Point"/> is empty.
        /// </summary>
        public bool IsEmpty => Equals(Empty);

        /// <summary>
		/// Initializes a new instance of the <see cref="Point"/> struct.
		/// </summary>
		/// <param name="x">The x-coordinate.</param>
		/// <param name="y">The y-coordinate.</param>
		public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="size">The <see cref="Size"/> to initialize from.</param>
        public Point(Size size)
        {
            X = size.Width;
            Y = size.Height;
        }

        public void Deconstruct(out float x, out float y)
        {
            x = X;
            y = Y;
        }

        /// <summary>
        /// Translates a given point by a specified offset.
        /// </summary>
        /// <param name="offset">The offset value.</param>
        public void Offset(Point offset)
        {
            X += offset.X;
            Y += offset.Y;
        }

        /// <summary>
        /// Translates a given point by a specified offset.
        /// </summary>
        /// <param name="dx">The offset in the x-direction.</param>
        /// <param name="dy">The offset in the y-direction.</param>
        public void Offset(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        public static Point Add(Point point, SizeI size) => point + size;
        public static Point Add(Point point, Size size) => point + size;
        public static Point Add(Point left, PointI right) => left + right;
        public static Point Add(Point left, Point right) => left + right;

        public static Point Subtract(Point point, SizeI size) => point - size;
        public static Point Subtract(Point point, Size size) => point - size;
        public static Point Subtract(Point left, PointI right) => left - right;
        public static Point Subtract(Point left, Point right) => left - right;

        public static Point operator +(Point point, SizeI size)
        {
            return new Point(point.X + size.Width, point.Y + size.Height);
        }

        public static Point operator +(Point point, Size size)
        {
            return new Point(point.X + size.Width, point.Y + size.Height);
        }

        public static Point operator +(Point left, PointI right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }

        public static Point operator +(Point left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }

        public static Point operator -(Point point, SizeI size)
        {
            return new Point(point.X - size.Width, point.Y - size.Height);
        }

        public static Point operator -(Point point, Size size)
        {
            return new Point(point.X - size.Width, point.Y - size.Height);
        }

        public static Point operator -(Point left, PointI right)
        {
            return new Point(left.X - right.X, left.Y - right.Y);
        }

        public static Point operator -(Point left, Point right)
        {
            return new Point(left.X - right.X, left.Y - right.Y);
        }

        /// <inheritdoc/>
		public override bool Equals(object obj) => obj is Point value && Equals(ref value);

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Point"/> to compare with this instance.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Point other) => Equals(ref other);

        /// <summary>
		/// Determines whether the specified <see cref="Point"/> is equal to this instance.
		/// </summary>
		/// <param name="other">The <see cref="Point"/> to compare with this instance.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ref Point other)
        {
            return X == other.X
                && Y == other.Y;
        }

        /// <summary>
        /// Compares two <see cref="Point"/> objects for equality.
        /// </summary>
        /// <param name="left">The <see cref="Point"/> on the left hand of the operand.</param>
        /// <param name="right">The <see cref="Point"/> on the right hand of the operand.</param>
        /// <returns>
        /// True if the current left is equal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Point left, Point right) => left.Equals(ref right);

        /// <summary>
        /// Compares two <see cref="Point"/> objects for inequality.
        /// </summary>
        /// <param name="left">The <see cref="Point"/> on the left hand of the operand.</param>
        /// <param name="right">The <see cref="Point"/> on the right hand of the operand.</param>
        /// <returns>
        /// True if the current left is unequal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Point left, Point right) => !left.Equals(ref right);

        /// <inheritdoc/>
		public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
