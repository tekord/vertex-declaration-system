# Vertex Declaration System

...

## Vertex Declaration

Vertex declarations define the vertex inputs used to render the geometry.

## Vertex Element

### usage

This defines the meaning of the element - the GPU will use this to determine what to use this input 
for, and programmable vertex pipelines will use this to identify which semantic to map the input to. 
This can identify the element as positional data, normal data, texture coordinate data, etc.

### format

...

### offset

Tells the declaration how far in bytes the element is offset from the start of each whole vertex in this 
buffer. This will be 0 if this is the only element being sourced from this buffer, but if other elements 
are there then it may be higher. A good way of thinking of this is the size of all vertex elements 
which precede this element in the buffer.

### index

...

## Vertex Declaration Builder

...

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
