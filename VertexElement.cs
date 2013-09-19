using System;
using System.Collections.Generic;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// Defines input vertex data for the pipeline.
	/// </summary>
	public class VertexElement {
		protected string _usage;
		protected VertexElementFormat _format;
		protected short _offset;
		protected short _usageIndex;

		/// <summary>
		/// Gets a value describing how the vertex element is to be used.
		/// </summary>
		/// <value>The usage of the element.</value>
		public string Usage {
			get { return _usage; }
		}
		
		/// <summary>
		/// Gets the format of this vertex element. 
		/// </summary>
		/// <value>The format of the element.</value>
		public VertexElementFormat Format {
			get { return _format; }
		}
		
		/// <summary>
		/// Gets the offset into the buffer where this element starts.
		/// </summary>
		/// <value>The offset in the buffer that this element starts at.</value>
		public short Offset {
			get { return _offset; }
			internal set { _offset = value; }
		}

		/// <summary>
		/// Gets the index of this element, only applicable for repeating elements (like texture coordinates).
		/// </summary>
		/// <value></value>
		public int UsageIndex {
			get { return _usageIndex; }
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="usage">The meaning of the element.</param>
		/// <param name="format">The format of element.</param>
		/// <param name="offset">The offset in the buffer that this element starts at.</param>
		/// <param name="usageIndex">Index of the item, only applicable for some elements like texture coordinates.</param>
		public VertexElement(string usage, VertexElementFormat format, short offset, short usageIndex = 0) {
			this._offset = offset;
			this._format = format;
			this._usage = usage;
			this._usageIndex = usageIndex;
		}

		/// <summary>
		/// Gets the size of this element in bytes.
		/// </summary>
		/// <returns></returns>
		public int GetFormatSize() {
			return VertexElementHelper.GetTypeSize(_format);
		}
		
		public override string ToString() {
			return string.Format("[VertexElement Usage={0}, Format={1}, Offset={2}, UsageIndex={3}]", _usage, _format, _offset, _usageIndex);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="elements"></param>
		/// <returns></returns>
		public static int ComputeStride(IList<VertexElement> elements) {
			int result = 0;
			
			foreach (var i in elements) {
				result += i.GetFormatSize();
			}
			
			return result;
		}
		
		/// <summary>
		/// Finds a <see cref="VertexElement"/> with the given semantic (usage), and index if there is more than one element with the same semantic.
		/// </summary>
		/// <param name="elements"></param>
		/// <param name="usage">Semantic to search for.</param>
		/// <param name="index">Index of item to looks for using the supplied semantic (applicable to texture coordinates and colors).</param>
		/// <returns></returns>
		public static VertexElement FindByUsage(IList<VertexElement> elements, string usage, short index = 0) {
			foreach (var element in elements) {
				if (element.Usage == usage && element.UsageIndex == index)
					return element;
			}
			
			return null;
		}
	}
}
