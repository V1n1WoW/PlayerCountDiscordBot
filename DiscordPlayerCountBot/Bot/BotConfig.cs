﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlayerCountBot
{
    public class BotConfig
    {
        [JsonProperty]
        public int UpdateTime { get; set; }

        [JsonProperty]
        public string SteamAPIKey { get; set; }

        [JsonProperty]
        public List<BotInformation> ServerInformation { get; set; } = new();

        public void CreateDefaults()
        {

            ServerInformation.Add(new BotInformation()
            {
                Name = "TestBot",
                Address = "127.0.0.1:27014",
                Token = "DiscordTokenHere",
                Status = 0,
                UseNameAsLabel = false
            });
            UpdateTime = 30;
            SteamAPIKey = "SteamAPIKeyHere";
        }
    }
}
