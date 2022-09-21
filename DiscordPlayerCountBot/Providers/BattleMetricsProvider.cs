﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordPlayerCountBot.Attributes;
using DiscordPlayerCountBot.Data;
using DiscordPlayerCountBot.Providers.Base;
using DiscordPlayerCountBot.Services;
using DiscordPlayerCountBot.ViewModels;
using PlayerCountBot;

namespace DiscordPlayerCountBot.Providers
{
    [Name("BattleMetrics")]
    public class BattleMetricsProvider : ServerInformationProvider
    {
        public BattleMetricsProvider(BotInformation info) : base(info)
        {
        }

        public async override Task<BaseViewModel?> GetServerInformation(BotInformation information, Dictionary<string, string> applicationVariables)
        {
            var service = new BattleMetricsService();

            try
            {
                var addressAndPort = information.GetAddressAndPort();
                var server = await service.GetPlayerInformationAsync(addressAndPort.Item1, applicationVariables["BattleMetricsKey"]);

                if (server == null)
                    throw new ApplicationException("Server cannot be null. Is your server offline?");

                HandleLastException(information);

                return server.GetViewModel();
            }
            catch (Exception e)
            {
                HandleException(e);
                return null;
            }
        }
    }
}
