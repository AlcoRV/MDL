using MDL.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MDL.Tools
{
    public static class CommonExtentions
    {
        public static string[] DeserializeRecipients(this Mail mail)
        {
            var recipients = JsonConvert.DeserializeObject<string[]>(mail.Recipients);
            return recipients;
        }
    }
}
