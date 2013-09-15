# Vertex Declaration System

...

## Vertex Declaration

Vertex declarations define the vertex inputs used to render the geometry.

## Vertex Element

Vertex element specifies a single part of a vertex.

### Usage (semantic)

This defines the meaning of the element - the GPU will use this to determine what to use this input 
for, and programmable vertex pipelines will use this to identify which semantic to map the input to. 
This can identify the element as positional data, normal data, texture coordinate data, etc.

Note that usage is just a string. Class `VertexElementUsages` containts most popular semantics like 
`POSITION`, `NORMAL`, `BLEND_WEIGHT`, ect.

### Format

...

### Offset

Tells the declaration how far in bytes the element is offset from the start of each whole vertex in this 
buffer. This will be 0 if this is the only element being sourced from this buffer, but if other elements 
are there then it may be higher. A good way of thinking of this is the size of all vertex elements 
which precede this element in the buffer.

### Index

This parameter is only required when you supply more than one element of the same semantic in one 
vertex declaration. For example, if you supply more than one set of texture coordinates, you would 
set first sets index to 0, and the second set to 1.

## Vertex Declaration Builder

...

If you remove some elements then call `RecalculateOffsets()` method of your VertexDeclarationBuilder 
instance.

## Examples

Let's build declaration for vertex [position, normal, color]:

	var builder = new VertexDeclarationBuilder();
	builder.AddElement(VertexElementUsages.POSITION, VertexElementFormat.Vector3);
	builder.AddElement(VertexElementUsages.NORMAL, VertexElementFormat.Vector3);
	builder.AddElement(VertexElementUsages.COLOR, VertexElementFormat.Vector4);
	
	var declaration = builder.Build();
	
Result declaration:

	[VertexDeclaration Stride=40 Elements=[
	  [VertexElement Usage=POSITION, Format=Vector3, Offset=0, UsageIndex=0]
	  [VertexElement Usage=NORMAL, Format=Vector3, Offset=12, UsageIndex=0]
	  [VertexElement Usage=COLOR, Format=Vector4, Offset=24, UsageIndex=0]
	]]

	
Now let's build declaration for vertex with two texture coordinates [position, texture 1, texture 2]:
	
	var builder = new VertexDeclarationBuilder();
	builder.AddElement(VertexElementUsages.POSITION, VertexElementFormat.Vector3);
	// We use the same semantics with different index
	builder.AddElement(VertexElementUsages.TEXTURE_COORDINATE, VertexElementFormat.Vector2, 0);
	builder.AddElement(VertexElementUsages.TEXTURE_COORDINATE, VertexElementFormat.Vector2, 1);
	
	var declaration = builder.Build();
	
Result declaration:

	[VertexDeclaration Stride=28 Elements=[
	  [VertexElement Usage=POSITION, Format=Vector3, Offset=0, UsageIndex=0]
	  [VertexElement Usage=TEXTURE_COORDINATE, Format=Vector2, Offset=12, UsageIndex=0]
	  [VertexElement Usage=TEXTURE_COORDINATE, Format=Vector2, Offset=20, UsageIndex=1]
	]]
