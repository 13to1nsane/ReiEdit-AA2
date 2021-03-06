﻿// --------------------------------------------------
// AA2Lib - NativeMethods.cs
// --------------------------------------------------

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AA2Lib.Code
{
    internal static class NativeMethods
    {
        [DllImport("gdi32.dll")]
        internal static extern bool BitBlt(
            IntPtr destinationDcHandle,
            int destinationX,
            int destinationY,
            int width,
            int height,
            IntPtr sourceDcHandle,
            int sourceX,
            int sourceY,
            CopyPixelOperation rasterOperation);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr dcHandle, int width, int height);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr dcHandle);

        [DllImport("gdi32.dll")]
        internal static extern bool DeleteDC(IntPtr dcHandle);

        [DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr objectHandle);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr windowHandle);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindowDC(IntPtr windowHandle);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr windowHandle, out NativeRectangle rectangle);

        [DllImport("user32.dll")]
        internal static extern bool ReleaseDC(IntPtr windowHandle, IntPtr dcHandle);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr SelectObject(IntPtr dcHandle, IntPtr objectHandle);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeRectangle
    {
        internal int Left;
        internal int Top;
        internal int Right;
        internal int Bottom;

        internal Rectangle ToRectangle()
        {
            return new Rectangle(Left, Top, Right - Left, Bottom - Top);
        }
    }
}