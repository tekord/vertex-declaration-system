using System;
using System.Collections.Generic;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// Represents the vertex declaration builder.
	/// </summary>
	public class VertexDeclarationBuilder {
		protected List<VertexElement> _elements;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public VertexDeclarationBuilder() {
			_elements = new List<VertexElement>();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="usage"></param>
		/// <param name="format"></param>
		public void AddElement(string usage, VertexElementFormat format, short usageIndex = 0) {
			var existingElement = VertexElement.FindByUsage(_elements, usage, usageIndex);
			
			// TODO: Make separate function to check
			if (existingElement != null)
				throw new ArgumentException("Declaration already contains element with the same usage, format and usageIndex.");
			
			int offset = VertexElement.ComputeStride(_elements);
			
			_elements.Add(new VertexElement(usage, format, (short)offset, usageIndex));
		}
		
		/// <summary>
		/// Removes all elements from the declaration.
		/// </summary>
		public void Clear() {
			_elements.Clear();
		}
		
		/// <summary>
		/// Removes the element with the given semantic and usage index.
		/// </summary>
		/// <param name="usage">Semantic to remove.</param>
		/// <param name="index">Usage index to remove, typically only applies to texture coordinates.</param>
		public void RemoveElement(string usage, int usageIndex = 0) {
			if (usageIndex < 0)
				throw new ArgumentOutOfRangeException("usageIndex");
			
			for (int i = 0; i < _elements.Count; ++i) {
				var element = _elements[i];
				
				if (element.Usage == usage && element.UsageIndex == usageIndex)
					_elements.RemoveAt(i);
			}
		}
		
		/// <summary>
		/// Removes the <see cref="VertexElement"/> at the specified index.
		/// </summary>
		/// <param name="index">Index of the element to remove.</param>
		public void RemoveElementAt(int index) {
			if (index < 0 || index >= _elements.Count)
				throw new ArgumentOutOfRangeException("index");
			
			_elements.RemoveAt(index);
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void RecalculateOffsets() {
			short offset = 0;
			
			foreach (var i in _elements) {
				i.Offset = offset;
				
				offset += (short)i.GetFormatSize();
			}
		}
		
		/// <summary>
		/// Gets the array of vertex elements that make up the vertex declaration.
		/// </summary>
		/// <returns></returns>
		public VertexElement[] GetVertexElements() {
			return _elements.ToArray();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public VertexDeclaration Build() {
			var elements = GetVertexElements();
			VertexDeclaration result = null;
			
			if (elements.Length > 0)
				result = new VertexDeclaration(elements);
			
			this.Clear();
			
			return result;
		}
	}
}
