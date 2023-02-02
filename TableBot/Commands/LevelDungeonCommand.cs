using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TableBot.Commands
{
    internal class LevelDungeonCommand : ICommand
    {




        public string GetCommandName()
        {
            return "";
        }

        public async Task HandleCommand(SocketSlashCommand command)
        {
            var author = new EmbedAuthorBuilder()
                .WithName(((SocketGuildUser)command.Data.Options.First().Value).ToString());
            var dungeon = GetDungeonByIndex((long)command.Data.Options.ToList()[1].Value);
            var embed = new EmbedBuilder
            {

                Title = Dungeons.GetName(dungeon),
                Description = "",
                Author = author,
            };

            for (int i = 1; i <= 10; i++)
            {
                long maxMutation = (long)command.Data.Options.ToList()[i + 1].Value;
                string lvl = "";
                switch (maxMutation)
                {
                    case 2:
                        lvl = ":third_place:";
                        break;
                    case 3:
                        lvl = ":second_place:";
                        break;
                    case 4:
                        lvl = ":first_place:";
                        break;
                    default:
                        lvl = ":x:";
                        break;
                }

                var field = new EmbedFieldBuilder()
                .WithName($"M{i}")
                .WithValue(lvl)
                .WithIsInline(true);
                embed.AddField(field);
            }
            //embed.WithImageUrl("https://d13urrra316e2f.cloudfront.net/original/3X/4/3/431c2e5219bacefbe7616177ce068a3f2a423f96.jpeg");
            embed.WithThumbnailUrl(Dungeons.GetThumbnail(dungeon));
            embed.WithUrl(Dungeons.GetUrl(dungeon));
            await command.RespondAsync(embed: embed.Build());
        }

        private DungeonEnum GetDungeonByIndex(long index) {
            DungeonEnum dungeon = DungeonEnum.DINASTIA;
            switch (index)
            {
                case 1:
                    dungeon = DungeonEnum.DINASTIA;
                    break;
                case 2:
                    dungeon = DungeonEnum.PROFONDITA;
                    break;
                case 3:
                    dungeon = DungeonEnum.LAZZARO;
                    break;
                case 4:
                    dungeon = DungeonEnum.GENESI;
                    break;
                case 5:
                    dungeon = DungeonEnum.ENNEADE;
                    break;
                case 6:
                    dungeon = DungeonEnum.TEMPESTA;
                    break;
                case 7:
                    dungeon = DungeonEnum.CIRRIPEDI;
                    break;
                case 8:
                    dungeon = DungeonEnum.TUMULI;
                    break;

                default:
                    break;
            }
            return dungeon;
        }

        public SlashCommandBuilder SlashCommandBuilder()
        {
            var commandBuilder = new SlashCommandBuilder()
                .WithName("create-table")
                .WithDescription("Crea la tabella del livello gold delle mutazioni")
                .AddOption("nome-pg", ApplicationCommandOptionType.User, "Nome PG", isRequired: true)
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("nome-dungeon")
                    .WithDescription("Nome del dungeon")
                    .WithRequired(true)
                    .AddChoice("Dinastia", 1)
                    .AddChoice("Profondità", 2)
                    .AddChoice("Lazzaro", 3)
                    .AddChoice("Genesi", 4)
                    .AddChoice("Enneade", 5)
                    .AddChoice("Tempesta", 6)
                    .AddChoice("Cirripedi", 7)
                    .AddChoice("Tumuli", 8)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m1")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m2")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m3")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m4")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m5")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m6")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m7")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m8")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m9")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                )
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("m10")
                    .WithDescription("Risultato ottenuto per questo livello")
                    .WithRequired(true)
                    .AddChoice("non fatto", 1)
                    .AddChoice("bronzo", 2)
                    .AddChoice("argento", 3)
                    .AddChoice("oro", 4)
                    .WithType(ApplicationCommandOptionType.Integer)
                );
            return commandBuilder;
        }

    }

    public enum DungeonEnum
    {
        [DungeonAttr("Dinastia", "https://it.nwdb.info/db/zone/20204", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_shipyard.png")] DINASTIA,
        [DungeonAttr("Profondità", "https://it.nwdb.info/db/zone/60238", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_depths.png")] PROFONDITA,
        [DungeonAttr("Lazzaro", "https://it.nwdb.info/db/zone/50146", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_lazarus.png")] LAZZARO,
        [DungeonAttr("Genesi", "https://it.nwdb.info/db/zone/50422", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_genesis.png")] GENESI,
        [DungeonAttr("Enneade", "https://it.nwdb.info/db/zone/20413", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_ennead.png")] ENNEADE,
        [DungeonAttr("Tempesta", "https://it.nwdb.info/db/zone/40428", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_isabella.png")] TEMPESTA,
        [DungeonAttr("Cirripedi", "https://it.nwdb.info/db/zone/30040", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_dungeoncutlasskeys00.png")] CIRRIPEDI,
        [DungeonAttr("Tumuli", "https://it.nwdb.info/db/zone/40168", "https://cdn.nwdb.info/db/images/live/v20/map/icon/pois/expedition_obelisk.png")] TUMULI
    }

    public class DungeonAttr : Attribute
    {
        internal DungeonAttr(string name, string url, string thumbnail) { 
            Name = name;
            URL= url;
            Thumbnail = thumbnail;
        }
        public string Name { get; private set; }
        public string URL { get; private set; }
        public string Thumbnail { get; private set; }

    }

    public static class Dungeons {
        public static string GetName(this DungeonEnum dungeon) {
            DungeonAttr attr = GetAttr(dungeon);
            return attr.Name;
        }

        public static string GetUrl(this DungeonEnum dungeon)
        {
            DungeonAttr attr = GetAttr(dungeon);
            return attr.URL;
        }

        public static string GetThumbnail(this DungeonEnum dungeon)
        {
            DungeonAttr attr = GetAttr(dungeon);
            return attr.Thumbnail;
        }

        private static DungeonAttr GetAttr(DungeonEnum dungeon) {
            return (DungeonAttr)Attribute.GetCustomAttribute(ForValue(dungeon), typeof(DungeonAttr));
        }

        private static MemberInfo ForValue(DungeonEnum dungeon)
        {
            return typeof(DungeonEnum).GetField(Enum.GetName(typeof(DungeonEnum), dungeon));
        }
    }
}
