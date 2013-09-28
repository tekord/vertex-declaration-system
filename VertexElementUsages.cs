using System;

namespace Tekord.VertexDeclarationSystem {
	/// <summary>
	/// 
	/// </summary>
	public static class VertexElementUsages {
		/// <summary>
		/// Not used element.
		/// </summary>
		public const string NOT_USED = "NOT_USED";
		
		/// <summary>
		/// Generic position.
		/// </summary>
		public const string POSITION = "POSITION";
		
		/// <summary>
		/// Position in 2D-space.
		/// </summary>
		public const string POSITION_XY = "POSITION_XY";
		
		/// <summary>
		/// Position in 3D-space.
		/// </summary>
		public const string POSITION_XYZ = "POSITION_XYZ";
		
		/// <summary>
		/// Vertex normal data. (Normal with UsageIndex = 0) specifies vertex normals for fixed-function vertex processing and the N-patch tessellator. (Normal with UsageIndex = 1) specifies vertex normals for fixed-function vertex processing for skinning.
		/// </summary>
		public const string NORMAL = "NORMAL";
		
		/// <summary>
		/// Vertex data contains diffuse or specular color. (Color with UsageIndex = 0) specifies the diffuse color in the fixed-function vertex shader and in pixel shaders. (Color with UsageIndex = 1) specifies the specular color in the fixed-function vertex shader and in pixel shaders.
		/// </summary>
		public const string COLOR = "COLOR";
		
		/// <summary>
		/// Texture coordinate data. (TextureCoordinate, n) specifies texture coordinates in fixed-function vertex processing and in pixel shaders. These coordinates can be used to pass user-defined data.
		/// </summary>
		public const string TEXTURE_COORDINATE = "TEXTURE_COORDINATE";
		
		/// <summary>
		/// Blending weight data. (BlendWeight with UsageIndex = 0) specifies the blend weights in fixed-function vertex processing.
		/// </summary>
		public const string BLEND_WEIGHT = "BLEND_WEIGHT";
		
		/// <summary>
		/// Blending indices data. (BlendIndices with UsageIndex = 0) specifies matrix indices for fixed-function vertex processing using indexed paletted skinning.
		/// </summary>
		public const string BLEND_INDICES = "BLEND_INDICES";
		
		/// <summary>
		/// Point size data. (PointSize with UsageIndex = 0) specifies the point-size attribute used by the setup engine of the rasterizer to expand a point into a quad for the point-sprite functionality.
		/// </summary>
		public const string POINT_SIZE = "POINT_SIZE";
		
		/// <summary>
		/// Vertex tangent data.
		/// </summary>
		public const string TANGENT = "TANGENT";
		
		/// <summary>
		/// Vertex binormal data.
		/// </summary>
		public const string BINORMAL = "BINORMAL";
		
		/// <summary>
		/// Single, positive floating-point value. (TessellateFactor with UsageIndex = 0) specifies a tessellation factor used in the tessellation unit to control the rate of tessellation.
		/// </summary>
		public const string TESSELLATE_FACTOR = "TESSELATE_FACTOR";
		
		/// <summary>
		/// Vertex data contains fog data. (Fog with UsageIndex = 0) specifies a fog blend value to use after pixel shading is finished.
		/// </summary>
		public const string FOG = "FOG";
		
		/// <summary>
		/// Vertex data contains depth data.
		/// </summary>
		public const string DEPTH = "DEPTH";
		
		/// <summary>
		/// 
		/// </summary>
		public const string TEXTURE_ALPHAS = "TEXTURE_ALPHAS";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_POSITION = "PARTICLE_POSITION";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_VELOCITY = "PARTICLE_VELOCITY";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_LIFE_TIME = "PARTICLE_LIFE_TIME";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_MAX_LIFE_TIME = "PARTICLE_MAX_LIFE_TIME";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_SCALE = "PARTICLE_SCALE";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_ALPHA = "PARTICLE_ALPHA";
		
		/// <summary>
		/// 
		/// </summary>
		public const string PARTICLE_ANGLE = "PARTICLE_ANGLE";
	}
}
