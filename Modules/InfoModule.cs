namespace sentrybot.Modules
{
    using System;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;

    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("Say")]
        [Summary("Echoes a Message.")]
        public Task SayAsync(
            [Remainder] [Summary("The text to echo")] string echo)
        => ReplyAsync(echo);
    }

    [Group("Sample")]
    public class SampleModule : ModuleBase<SocketCommandContext>
    {
        [Command("square")]
        [Summary("Squares a Number")]
        public async Task SquareAsync([Summary("The Number to Square")] int num)
        {
            await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num,2)}");
            
        }

        [Command("userinfo")]
        [Summary("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync([Summary("The (optional) user to get info from")]
        SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }
            [Group("admin")]
            public class AdminModule : ModuleBase<SocketCommandContext>
            {
                [Group("clean")]
                public class CleanModule : ModuleBase<SocketCommandContext>
                {
                    public async Task DefaultCleanAsync()
                    {
                        //...
                    }
                    // ~admin clean messages 15
                    [Command("messages")]
                    public async Task CleanAsync(int count)
                    {
                        // ...
                    }
                }
                // ~admin ban 
                [Command("ban")]
                public Task BanAsync(IGuildUser user) =>
                    Context.Guild.AddBanAsync(user);

                
            }
    }






}