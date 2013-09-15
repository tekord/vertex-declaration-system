# Vertex Declaration System

...

## Vertex Declaration

...

## Vertex Element

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
