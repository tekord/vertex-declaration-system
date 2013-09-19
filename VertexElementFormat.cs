using System;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// Defines the vertex element formats.
	/// </summary>
	public enum VertexElementFormat {
		/// <summary>
		/// Single-component, 32-bit floating-point, expanded to (float, 0, 0, 1).
		/// </summary>
		Single,
		
		/// <summary>
		/// Two-component, 32-bit floating-point, expanded to (float, float, 0, 1).
		/// </summary>
		Vector2,
		
		/// <summary>
		/// Three-component, 32-bit floating point, expanded to (float, float, float, 1).
		/// </summary>
		Vector3,
		
		/// <summary>
		/// Four-component, 32-bit floating point, expanded to (float, float, float, float).
		/// </summary>
		Vector4,
		
		/// <summary>
		/// Four-component, packed, unsigned byte, mapped from 0 to 1 range. Input is in Int32 format (ARGB) expanded to (R, G, B, A).
		/// </summary>
		Color,
		
		/// <summary>
		/// Two-component, signed short expanded to (value, value, 0, 1).
		/// </summary>
		Short2,
		
		/// <summary>
		/// Four-component, signed short expanded to (value, value, value, value).
		/// </summary>
		Short4,
		
		/// <summary>
		/// Four-component, unsigned byte.
		/// </summary>
		Byte4
	}
}
