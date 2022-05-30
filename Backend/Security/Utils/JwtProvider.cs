using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

public static class JwtProvider
{

    public static string GenerateToken(List<Claim> _claims, string PrivateKey, string Issuer, int Time, string Audience)
    {

        var Now = DateTime.UtcNow;
        var identifier = Guid.NewGuid().ToString();
        var issuedAt = new DateTimeOffset(Now).ToUnixTimeSeconds().ToString();
        SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PrivateKey));

        var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Typ, "JWT"),
                new Claim(JwtRegisteredClaimNames.Jti, identifier),
                new Claim(JwtRegisteredClaimNames.Iat, issuedAt, ClaimValueTypes.Integer64),
            };

        claims.AddRange(_claims);

        var SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            // issuer: Issuer,
            // audience: Audience,
            notBefore: Now,
            expires: Now.Add(TimeSpan.FromMinutes(Time)),
            signingCredentials: SigningCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}