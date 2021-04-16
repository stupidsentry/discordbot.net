using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace sentrybot
{
    class Program
    {
        public static void Main(string[] args)

            => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;



        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            var token = "";
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        
    }

}
