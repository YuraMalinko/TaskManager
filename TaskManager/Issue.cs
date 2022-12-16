﻿using TaskManager.Enums;

namespace TaskManager
{
    public class Issue
    {
        public List<int> BlockedByCurrentIssue { get; set; }

        public List<int> BlockingIssues { get; set; }

        public int NumberIssue { get; set; }

        public string Description { get; set; }

        public string IdUser { get; set; }

        public string Comment { get; set; }

        public IssueStatus Status { get; set; }

        public Issue(int numberIssue, string description)
        {
            BlockedByCurrentIssue = new List<int>();
            BlockingIssues = new List<int>();
            NumberIssue = numberIssue;
            Description = description;
        }

        public override bool Equals(object? obj)
        {
            return obj is Issue issue &&
                   NumberIssue == issue.NumberIssue &&
                   Description == issue.Description &&
                   IdUser == issue.IdUser &&
                   Comment == issue.Comment &&
                   Status == issue.Status;
        }
    }
}
