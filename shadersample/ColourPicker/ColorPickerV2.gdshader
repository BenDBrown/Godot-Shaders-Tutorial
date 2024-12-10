shader_type canvas_item;

uniform vec4 color : source_color;
uniform vec4 shades[10] : source_color;
uniform float tolerance = 0.001;

void fragment() {
	vec4 pixelColor = texture(TEXTURE, UV);
	int shadeCount = shades.length();
	for(int i = 0; i < shadeCount; i++)
	{
		if(distance(shades[i], pixelColor) < tolerance)
		{
			float brightness = (pixelColor.r + pixelColor.g + pixelColor.b) / 3.0;
			vec4 grayScale = vec4(brightness, brightness, brightness, pixelColor.a);
			pixelColor = grayScale * color;
			break;
		}
	}
	COLOR = pixelColor;
}