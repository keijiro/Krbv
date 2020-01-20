void LatticeEdges_float(float3 opos, float3 bcoord, float time, out float alpha)
{
    float3 g = saturate(1 - bcoord / fwidth(bcoord));
    float b = g.x * bcoord.y + g.y * bcoord.z + g.z * bcoord.x;
    //float a = 0.5 + 0.5 * sin(length(opos.xy) * 4 - time * 8);
    float a = g.x * (sin(bcoord.y * 8 + time * 6) < -0.5);
    a += g.y * (sin(bcoord.z * 9 + time * 7) < -0.5);
    a += g.z * (sin(bcoord.x * 10 + time * 8) < -0.5);
    alpha = max(max(g.x, g.y), g.z) * a;
}
