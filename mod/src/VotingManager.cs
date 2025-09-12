// VotingManager.cs
// Manages chat-based voting for major decisions in Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Collections.Generic;

namespace HeelKawnMod
{
    public class VotingManager
    {
        private readonly Dictionary<string, VoteSession> activeVotes = new();

        public string StartVote(string voteId, string topic, List<string> options)
        {
            if (activeVotes.ContainsKey(voteId))
                return $"Vote '{voteId}' is already active.";
            activeVotes[voteId] = new VoteSession { Topic = topic, Options = options, Votes = new Dictionary<string, string>() };
            return $"Vote started: {topic} Options: {string.Join(", ", options)}";
        }

        public string CastVote(string voteId, string voter, string option)
        {
            if (!activeVotes.ContainsKey(voteId))
                return $"No active vote with ID '{voteId}'.";
            if (!activeVotes[voteId].Options.Contains(option))
                return $"Option '{option}' is not valid for this vote.";
            activeVotes[voteId].Votes[voter] = option;
            return $"{voter} voted for '{option}' in '{voteId}'.";
        }

        public string EndVote(string voteId)
        {
            if (!activeVotes.ContainsKey(voteId))
                return $"No active vote with ID '{voteId}'.";
            var session = activeVotes[voteId];
            var results = new Dictionary<string, int>();
            foreach (var opt in session.Options)
                results[opt] = 0;
            foreach (var vote in session.Votes.Values)
                if (results.ContainsKey(vote))
                    results[vote]++;
            activeVotes.Remove(voteId);
            return $"Vote '{voteId}' ended. Results: " + string.Join(", ", results);
        }
    }

    public class VoteSession
    {
        public string Topic { get; set; }
        public List<string> Options { get; set; }
        public Dictionary<string, string> Votes { get; set; }
    }
}
