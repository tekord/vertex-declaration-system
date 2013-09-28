using System;
using System.Runtime.InteropServices;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// 
	/// </summary>
	public static class VertexElementHelper {
		/// <summary>
		/// Utility method for helping to calculate offsets.
		/// </summary>
		public static int GetTypeSize(VertexElementFormat format) {
			switch (format) {
				case VertexElementFormat.Single:
					return Marshal.SizeOf(typeof(float));

				case VertexElementFormat.Vector2:
					return Marshal.SizeOf(typeof(float)) * 2;

				case VertexElementFormat.Vector3:
					return Marshal.SizeOf(typeof(float)) * 3;

				case VertexElementFormat.Vector4:
					return Marshal.SizeOf(typeof(float)) * 4;

				case VertexElementFormat.Color:
					return Marshal.SizeOf(typeof(byte)) * 4;
			}

			// Keep the compiler happy
			return 0;
		}
	}
}
