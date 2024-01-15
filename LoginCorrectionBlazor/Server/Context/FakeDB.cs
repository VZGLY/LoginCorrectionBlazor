using LoginCorrectionBlazor.Shared.Entities;

namespace LoginCorrectionBlazor.Server.Context
{
    public static class FakeDB
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User
    {
        Id = 1,
        Email = "ChantaleLadsous@Gmail.com",
        Password = "chanchan"
    },
    new User
    {
        Id = 2,
        Email = "JohnDoe@gmail.com",
        Password = "john123"
    },
    new User
    {
        Id = 3,
        Email = "AliceWonderland@yahoo.com",
        Password = "alice@123"
    },
    new User
    {
        Id = 4,
        Email = "BobBuilder@hotmail.com",
        Password = "buildit"
    },
    new User
    {
        Id = 5,
        Email = "EvaGreen@outlook.com",
        Password = "greeneva"
    },
    new User
    {
        Id = 6,
        Email = "MaxPower@gmail.com",
        Password = "powermax"
    },
    new User
    {
        Id = 7,
        Email = "LucySkywalker@gmail.com",
        Password = "lightsaber"
    },
    new User
    {
        Id = 8,
        Email = "TonyStark@starkindustries.com",
        Password = "ironman"
    },
    new User
    {
        Id = 9,
        Email = "LaraCroft@tombraider.com",
        Password = "raider123"
    },
    new User
    {
        Id = 10,
        Email = "SamWise@hobbiton.com",
        Password = "frodo123"
    }
        };
    }
}
