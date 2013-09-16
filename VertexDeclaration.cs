using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// 
	/// </summary>
	public interface IVertexFormat {
	}
	
	/// <summary>
	/// Represents the format of a set of vertex inputs, which can be issued to the rendering API.
	/// </summary>
	public class VertexDeclaration {
		protected VertexElement[] _elements;
		protected int _stride;
		
		/// <summary>
		/// Gets the array of elements that make up this vertex declaration.
		/// </summary>
		/// <value>The array of elements.</value>
		public VertexElement[] Elements {
			get { return _elements; }
		}
		
		/// <summary>
		/// Gets the number of bytes from one vertex to the next.
		/// </summary>
		/// <value>The stride.</value>
		public int Stride {
			get { return _stride; }
		}
		
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="elements"></param>
		public VertexDeclaration(VertexElement[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			this._elements = elements;
			this._stride = VertexElement.ComputeStride(elements);
		}
		
		/// <summary>
		/// Gets the <see cref="VertexElement"/> at the specified index.
		/// </summary>
		/// <param name="index">Index of the element to retrieve.</param>
		/// <returns>Element at the requested index.</returns>
		public VertexElement GetElementAt(int index) {
			if (index < 0 || index >= _elements.Length)
				throw new ArgumentOutOfRangeException("index");

			return _elements[index];
		}
		
		/// <summary>
		/// Finds a <see cref="VertexElement"/> with the given semantic (usage), and index if there is more than one element with the same semantic.
		/// </summary>
		/// <param name="usage">Semantic to search for.</param>
		/// <param name="index">Index of item to looks for using the supplied semantic (applicable to texture coordinates and colors).</param>
		/// <returns></returns>
		public VertexElement FindElementByUsage(string usage, short index = 0) {
			return VertexElement.FindByUsage(_elements, usage, index);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="usage"></param>
		/// <param name="dstArray"></param>
		/// <param name="elements"></param>
		/// <returns></returns>
		public VertexDeclaration UpdateData<TVertex, TElement>(string usage, TVertex[] dstArray, TElement[] elements)
			where TVertex : struct, IVertexFormat
		{
			var element = FindElementByUsage(usage);
			var offset = element.Offset;
			
			var dstHandle = GCHandle.Alloc(dstArray, GCHandleType.Pinned);
			IntPtr dstAddress = dstHandle.AddrOfPinnedObject();
			
			var dataHandle = GCHandle.Alloc(elements, GCHandleType.Pinned);
			IntPtr dataAddress = dataHandle.AddrOfPinnedObject();
			
			var stepSize = element.GetFormatSize();
			var count = Marshal.SizeOf(elements.GetType().GetElementType()) * elements.Length;
			var vertexIndex = 0;
			
			for (int i = 0, strideCounter = 0; i < count; ++i) {
				var v = Marshal.ReadByte(dataAddress, i);
				
				Marshal.WriteByte(dstAddress, (vertexIndex * _stride) + offset + strideCounter, v);
				
				++strideCounter;
				
				if (strideCounter == stepSize) {
					strideCounter = 0;
					++vertexIndex;
				}
			}
			
			dataHandle.Free();
			dstHandle.Free();
			
			return this;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string DumpElements() {
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			
			sb.AppendFormat("[VertexDeclaration Stride={0} Elements=[", this.Stride);
			sb.AppendLine();
			
			foreach (var i in _elements) {
				sb.AppendFormat("  {0}", i.ToString());
				sb.AppendLine();
			}
			
			sb.AppendLine("]]");
			
			return sb.ToString();
		}
	}
}
