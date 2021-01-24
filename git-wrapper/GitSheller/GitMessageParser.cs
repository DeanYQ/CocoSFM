using System;
using System.Collections.Generic;

namespace GitSheller
{
    public class GitMessageParser
    {
        public static List<GitHistoryItem> FormatHistory(string history)
        {
            var histories = new List<GitHistoryItem>();
            if (string.IsNullOrWhiteSpace(history))
                return histories;

            var lines = history.Split(new string[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.None);
            var item = new GitHistoryItem();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("commit"))
                {
                    item.Message = item.Message.Trim();
                    item = new GitHistoryItem();
                    histories.Add(item);
                    item.CommitId = line.Substring("commit".Length).Trim();
                }
                else if(line.StartsWith("Author:"))
                {
                    item.Author = line.Substring("Author:".Length).Trim();
                }
                else if (line.StartsWith("Date:"))
                {
                    item.Date = line.Substring("Date:".Length).Trim();
                }
                else
                {
                    item.Message += line + Environment.NewLine;
                }
            }
            item.Message = item.Message.Trim();
            return histories;
        }

        public static bool ParseStatus(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return true;

            var lines = message.Split(new string[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                if (line.Contains("nothing to commit"))
                    return true;
            }
            return false;
        }
    }
}
