﻿namespace ExcursionAPI.Contracts.Users
{
    public class GetUserResponse
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
