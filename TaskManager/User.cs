﻿using System.Security.Cryptography.X509Certificates;

namespace TaskManager
{
    public class User
    {
        private AbstractUser _user;

        //public void SelectRole(bool isAdmin)
        public bool SelectRole(Board board)
        {
            if (board.IDAdmin.Contains(IDUser))
            {
                _user = new AdminUser();
                return true;
            }
            else if (board.IDMembers.Contains(IDUser))
            {
                _user = new MemberUser();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewIssue(Board board, string description)
        {
            return _user.AddNewIssue(board, description);
        }

        public bool RemoveIssue(Board board, int numberIssue)
        {
            return _user.RemoveIssue(board, numberIssue);
        }

        public void AddBlokingAndBlockedByIssue(Board board, int blockedByCurrentIssue, int blockingCurrentIssue)
        {
            _user.AddBlokingAndBlockedByIssue(board, blockedByCurrentIssue, blockingCurrentIssue);
        }

        public string IDUser { get; private set; }

        public string NameUser { get; private set; }

        public List<int> BoardsForUser { get; private set; }

        public User(string idUser, string nameUser)
        {
            IDUser = idUser;
            NameUser = nameUser;
            BoardsForUser = new List<int>();
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   IDUser == user.IDUser &&
                   NameUser == user.NameUser;
        }
    }
}
