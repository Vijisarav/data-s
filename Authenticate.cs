﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PateintDetail
{
    public static class Authenticate
    {
        //public string Token { get; set; }

        private static string Secret_Key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6InZpaml3ZXJ0eSIsImlhdCI6MTUxNjIzOTAyMn0.e4OkVAqo8sDl29LNLXFtcPZztsyb5wYXv7wZYh3-UA0";
        public static SymmetricSecurityKey signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret_Key));
        public static string TokenGenerations()
        {
            SigningCredentials signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            JwtHeader header = new JwtHeader(signingCredentials);

            DateTime expiryTime = DateTime.UtcNow.AddMinutes(5);

            int totalSeconds = (int)(expiryTime - new DateTime()).TotalSeconds;

            JwtPayload payload = new JwtPayload()
            {
                {"sub","patient" },
                {"Name","patient" },
                {"email","patient" },
                {"expiry",totalSeconds},
                {"iss","patient" },
                {"aud","patient" }
            };

            JwtSecurityToken jwtSecurityTokenjwtSecurityToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityTokenjwtSecurityToken);
            Console.WriteLine(jsonToken);
            return jsonToken;
        }
    }

}