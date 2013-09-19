# Vertex Declaration System

All vertex data passed to the graphics card needs to be described in order for the data it 
contains to be used correctly, and each graphics API has slightly different ways of doing so.

This library allows you to describe your custom vertex structures by creating an array of vertex 
elements that correspond to each of the data elements in your vertex structure. Each element 
in the array contains information such as the data format, the intended usage, the offset into 
structure in bytes, ect.

## Vertex Declaration

**Vertex Declaration** define the vertex inputs used to render the geometry. Declaration is made up of elements.

**Vertex Element** specifies a single part of a vertex. Element provides the following fields:

- **Usage (semantic)** defines the meaning of the element - the GPU will use this to determine what to use this input 
for, and programmable vertex pipelines will use this to identify which semantic to map the input to. 
This can identify the element as positional data, normal data, texture coordinate data, etc.

> Note that usage is just a string. Class `VertexElementUsages` containts most popular semantics like 
`POSITION`, `NORMAL`, `BLEND_WEIGHT`, ect.

- **Format** describes the data format (Vector2, Vector3, ect.).

- **Offset** tells the declaration how far in bytes the element is offset from the start of each whole vertex in this 
buffer. This will be 0 if this is the only element being sourced from this buffer, but if other elements 
are there then it may be higher. A good way of thinking of this is the size of all vertex elements 
which precede this element in the buffer.

- **Usage Index** is only required when you supply more than one element of the same semantic in one 
vertex declaration. For example, if you supply more than one set of texture coordinates, you would 
set first sets index to 0, and the second set to 1.

### Example

First step is to declare your vertex structure and describe elements:

	/// <summary>
	/// Represents a standard vertex format.
	/// </summary>
	[System.Runtime.InteropServices.StructLayout(
		System.Runtime.InteropServices.LayoutKind.Sequential,
		Pack = 1)]
	public struct Vertex_STANDARD : IVertexFormat {
		/// <summary>
		/// Position in 3D-space.
		/// </summary>
		[VertexElementAttribute(VertexElementUsages.POSITION_XYZ, VertexElementFormat.Vector3)]
		public Vector3 Position;
		
		/// <summary>
		/// Normal vector.
		/// </summary>
		[VertexElementAttribute(VertexElementUsages.NORMAL, VertexElementFormat.Vector3)]
		public Vector3 Normal;
		
		/// <summary>
		/// Diffuse color.
		/// </summary>
		[VertexElementAttribute(VertexElementUsages.COLOR, VertexElementFormat.Vector4)]
		public Vector4 Color;
		
		/// <summary>
		/// UV coordinates for 1st texture.
		/// </summary>
		[VertexElementAttribute(VertexElementUsages.TEXTURE_COORDINATE, VertexElementFormat.Vector2, 0)]
		public Vector2 UV1;
		
		/// <summary>
		/// UV coordinates for 2nd texture.
		/// </summary>
		[VertexElementAttribute(VertexElementUsages.TEXTURE_COORDINATE, VertexElementFormat.Vector2, 1)]
		public Vector2 UV2;
		
		/// <summary>
		/// Tangent vector.
		/// </summary>
		[VertexElementAttribute(VertexElementUsages.TANGENT, VertexElementFormat.Vector4)]
		public Vector4 Tangent;
	}

Note that element attributes of `UV1` and `UV2` have third argument: 0 and 1 correspondingly. We describe same usage for 
this elements so we need to identify them by usage index.

Next step is to build vertex declaration for the structure:

	VertexDeclaration.Register<Vertex_STANDARD>();
	
Vertex declaration is built and stores inside of `VertexDeclaration` cache. To get `VertexDeclaration` 
instance of your structure write:

	var declaration = VertexDeclaration.Get<Vertex_STANDARD>();
	
We need values to construct vertices. Let's define 3 vertices (triangle):

	// 3 values per vertex (x, y, z)
	float[] positions = new float[] {
		-0.5f, 0.0f, 0.0f,
		 0.5f, 0.0f, 0.0f,
		 0.0f, 1.0f, 0.0f
	};
	
	// 4 values per vertex (r, g, b, a)
	float[] diffuseColors = new float[] {
		1.0f, 0.0f, 0.0f, 1.0f, // red
		0.0f, 1.0f, 0.0f, 1.0f, // green
		0.0f, 0.0f, 1.0f, 1.0f // blue
	};
	
Now you can create the array of vertices and fill it:

	Vertex_STANDARD[] vertices = new Vertex_STANDARD[3];
	
	// Getting declaration here if you have not already get it
	var declaration = VertexDeclaration.Get<Vertex_STANDARD>();
	
	declaration
		.UpdateData(VertexElementUsages.POSITION, vertices, positions)
		.UpdateData(VertexElementUsages.DIFFUSE_COLOR, vertices, diffuseColors);
		
Done.

## Custom Building

You can build vertex declaration customly through the vertex declaration builder.

	var builder = new VertexDeclarationBuilder();

If you want to extend `VertexDeclaration` class and create instance of it through the builder then pass `customType` parameter to `VertexDeclarationBuilder`'s constructor:

	var builder = new VertexDeclarationBuilder(typeof(MyCustomVertexDeclaration));

Add some elements:

	builder.AddElement(VertexElementUsages.POSITION, VertexElementFormat.Vector3);
	builder.AddElement(VertexElementUsages.TANGENT, VertexElementFormat.Vector4);

Finally call `Build` method:

	VertexDeclaration declaration = builder.Build();

To check the result in console do:

	Console.WriteLine(declaration.DumpElements());

> Don't forget to call `RecalculateOffsets()` method after you remove some element(s) during the building.

### Examples

Let's build declaration for vertex [position, normal, color]:

	var builder = new VertexDeclarationBuilder();
	builder.AddElement(VertexElementUsages.POSITION, VertexElementFormat.Vector3);
	builder.AddElement(VertexElementUsages.NORMAL, VertexElementFormat.Vector3);
	builder.AddElement(VertexElementUsages.COLOR, VertexElementFormat.Vector4);
	
	var declaration = builder.Build();
	
Result:

	[VertexDeclaration Stride=40 Elements=[
	  [VertexElement Usage=POSITION, Format=Vector3, Offset=0, UsageIndex=0]
	  [VertexElement Usage=NORMAL, Format=Vector3, Offset=12, UsageIndex=0]
	  [VertexElement Usage=COLOR, Format=Vector4, Offset=24, UsageIndex=0]
	]]

Now let's build declaration for vertex with two color components [position, diffuse color, specular color]:
	
	var builder = new VertexDeclarationBuilder();

	builder.AddElement(VertexElementUsages.POSITION, VertexElementFormat.Vector3);
	// We use the same semantics with different index
	builder.AddElement(VertexElementUsages.COLOR, VertexElementFormat.Vector4, 0);
	builder.AddElement(VertexElementUsages.COLOR, VertexElementFormat.Vector4, 1);
	
	var declaration = builder.Build();
	
Result:

	[VertexDeclaration Stride=28 Elements=[
	  [VertexElement Usage=POSITION, Format=Vector3, Offset=0, UsageIndex=0]
	  [VertexElement Usage=COLOR, Format=Vector4, Offset=12, UsageIndex=0]
	  [VertexElement Usage=COLOR, Format=Vector4, Offset=28, UsageIndex=1]
	]]