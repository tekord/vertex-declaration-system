using System;
using System.Collections.Generic;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// 
	/// </summary>
	public static class VertexDeclarationManager {
		static Dictionary<Type, VertexDeclaration> _store = new Dictionary<Type, VertexDeclaration>();
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static VertexDeclaration Get<T>()
			where T : struct, IVertexFormat
		{
			Type type = typeof(T);
			VertexDeclaration result;
			
			_store.TryGetValue(type, out result);
			
			return result;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public static void Set<T>(VertexDeclaration item)
			where T : struct, IVertexFormat
		{
			_store[typeof(T)] = item;
		}
	}
}
