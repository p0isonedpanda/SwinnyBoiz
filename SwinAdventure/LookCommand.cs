using System;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base (new string[] { "look" }) { }

        public override string Execute(Player p, string[] text)
        {
            // Series of checks to make sure command is valid
            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5)
            {
                if (text[3].ToLower() != "in")
                {
                    return "What do you want to look in?";
                }
            }

            string result;

            switch (text.Length)
            {
                // Look in player inventory
                case 3:
                    result = LookAtIn(text[2], p);
                    if (result == "")
                    {
                        return "I cannot find the " + text[2];
                    }
                    else
                    {
                        return result;
                    }
                
                // Look in container in player inventory
                case 5:
                    IHaveInventory c = FetchContainer(p, text[4]);
                    if (c == null)
                    {
                        return "I cannot find the " + text[4];
                    }
                    else
                    {
                        result = LookAtIn(text[2], c);
                        if (result == "")
                        {
                            return "Cannot locate " + text[2] + " in " + text[4];
                        }
                        else
                        {
                            return result;
                        }
                    }

                // Invalid look command
                default:
                    return "I don't know how to look like that";
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var result = container.Locate(thingId);
            if (result != null)
            {
                return result.LongDescription;
            }
            else
            {
                return "";
            }
        }
    }
}