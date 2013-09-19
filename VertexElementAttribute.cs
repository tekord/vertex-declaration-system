using System;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public sealed class VertexElementAttribute : Attribute {
		/// <summary>
		/// 
		/// </summary>
		public int Stream {
			get; set;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Usage {
			get; set;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public VertexElementFormat Format {
			get; set;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public int Offset {
			get; set;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public short UsageIndex {
			get; set;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="usage"></param>
		/// <param name="format"></param>
		/// <param name="usageIndex"></param>
		public VertexElementAttribute(string usage, VertexElementFormat format, short usageIndex = 0) {
			Usage = usage;
			Format = format;
			UsageIndex = usageIndex;
		}
	}
}
