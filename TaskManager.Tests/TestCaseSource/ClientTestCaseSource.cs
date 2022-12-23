﻿using System.Collections;

namespace TaskManager.Tests.TestCaseSource
{
    public class ClientTestCaseSource

    {
        public static IEnumerable AttachIssueToClientTestCaseSource()
        {
            // 1. проверка на добавление задания к Админу, при всех выполненных условиях

            Issue issue1 = new Issue(1, "1");
            Issue attachIssue = new Issue(2, "2");
            Board board = new Board(10, 5);
            board.Issues.Add(issue1);
            board.Issues.Add(attachIssue);
            int idAttachIssue = 2;
            Dictionary<int, Board> baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            Client client = new Client(5, "5");
            client.BoardsForUser.Add(10);
            board.IDAdmin.Add(5);
            Dictionary<long, Client> baseClients = new Dictionary<long, Client>
            {
                { 5, client }
            };

            Issue expIssue1 = new Issue(1, "1");
            Issue expAttachIssue = new Issue(2, "2");
            Client expClient = new Client(5, "5");
            Board expBoard = new Board(10, 5);
            expBoard.Issues.Add(expIssue1);
            expBoard.Issues.Add(expAttachIssue);
            expClient.BoardsForUser.Add(10);
            expBoard.IDAdmin.Add(5);
            expAttachIssue.IdUser = expClient.IDUser;
            Dictionary<int, Board> expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            Dictionary<long, Client> expectedClients = new Dictionary<long, Client>
             {
                { 5, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };


            // 2. проверка на добавление задания к Мемберу, при всех выполненных условиях

            Issue issue10 = new Issue(10, "10");
            attachIssue = new Issue(20, "20");
            Client admin = new Client(22, "22");
            board = new Board(22, 22);
            board.Issues.Add(issue10);
            board.Issues.Add(attachIssue);
            idAttachIssue = 20;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            client = new Client(50, "50");

            client.BoardsForUser.Add(22);
            board.IDMembers.Add(50);
            baseClients = new Dictionary<long, Client>
            {
                { 22, admin},
                { 50, client }
            };

            Issue expIssue10 = new Issue(10, "10");
            expAttachIssue = new Issue(20, "20");
            expIssue10.Status = Enums.IssueStatus.Backlog;
            Client expAdmin = new Client(22, "22");
            expBoard = new Board(22, 22);
            expBoard.Issues.Add(issue10);
            expBoard.Issues.Add(attachIssue);
            expClient = new Client(50, "50");
            expClient.BoardsForUser.Add(22);
            expBoard.IDMembers.Add(50);
            expAttachIssue.IdUser = expClient.IDUser;

            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 22, expAdmin},
                { 50, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            // 3. проверка на недобавление задания к Админу, если такого задания нет в доске

            issue1 = new Issue(13, "13");
            board = new Board(103, 53);
            board.Issues.Add(issue1);
            idAttachIssue = 23;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            client = new Client(53, "53");
            client.BoardsForUser.Add(103);
            board.IDAdmin.Add(53);
            baseClients = new Dictionary<long, Client>
            {
                { 53, client }
            };

            expIssue1 = new Issue(13, "13");
            expClient = new Client(53, "53");
            expBoard = new Board(103, 53);
            expBoard.Issues.Add(expIssue1);
            expClient.BoardsForUser.Add(103);
            expBoard.IDAdmin.Add(53);
            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 53, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            // 4. проверка на недобавление задания к Мемберу, если такого задания нет в доске

            issue10 = new Issue(104, "104");
            admin = new Client(224, "224");
            board = new Board(224, 224);
            board.Issues.Add(issue10);
            idAttachIssue = 204;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            client = new Client(504, "504");

            client.BoardsForUser.Add(224);
            board.IDMembers.Add(504);
            baseClients = new Dictionary<long, Client>
            {
                { 224, admin},
                { 504, client }
            };

            expIssue10 = new Issue(104, "104");
            expAdmin = new Client(224, "224");
            expBoard = new Board(224, 224);
            expBoard.Issues.Add(issue10);
            expClient = new Client(504, "504");
            expClient.BoardsForUser.Add(224);
            expBoard.IDMembers.Add(504);

            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 224, expAdmin},
                { 504, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            // 5. проверка на недобавление задания к Админу, если у него уже есть другие задания в InProgress

            issue1 = new Issue(15, "15");
            issue1.Status = Enums.IssueStatus.InProgress;
            client = new Client(55, "55");
            issue1.IdUser = client.IDUser;
            attachIssue = new Issue(25, "25");
            attachIssue.Status = Enums.IssueStatus.InProgress;
            board = new Board(105, 55);
            board.Issues.Add(issue1);
            board.Issues.Add(attachIssue);
            idAttachIssue = 25;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            client.BoardsForUser.Add(105);
            board.IDAdmin.Add(55);
            baseClients = new Dictionary<long, Client>
            {
                { 55, client }
            };

            expIssue1 = new Issue(15, "15");
            expIssue1.Status = Enums.IssueStatus.InProgress;
            expClient = new Client(55, "55");
            expIssue1.IdUser = expClient.IDUser;
            expAttachIssue = new Issue(25, "25");
            expAttachIssue.Status = Enums.IssueStatus.InProgress;
            expBoard = new Board(105, 55);
            expBoard.Issues.Add(expIssue1);
            expBoard.Issues.Add(expAttachIssue);
            expClient.BoardsForUser.Add(105);
            expBoard.IDAdmin.Add(55);
            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 55, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            // 6. проверка на недобавление задания к Мемберу, если у него уже есть другие задания в InProgress

            client = new Client(506, "506");
            issue10 = new Issue(106, "106");
            issue10.Status = Enums.IssueStatus.InProgress;
            issue10.IdUser = client.IDUser;
            attachIssue = new Issue(206, "206");
            attachIssue.Status = Enums.IssueStatus.InProgress;
            admin = new Client(226, "226");
            board = new Board(226, 226);
            board.Issues.Add(issue10);
            board.Issues.Add(attachIssue);
            idAttachIssue = 206;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };

            client.BoardsForUser.Add(226);
            board.IDMembers.Add(506);
            baseClients = new Dictionary<long, Client>
            {
                { 226, admin},
                { 506, client }
            };

            expClient = new Client(506, "506");
            expIssue10 = new Issue(106, "106");
            expIssue10.Status = Enums.IssueStatus.InProgress;
            expAttachIssue = new Issue(206, "206");
            expAttachIssue.Status = Enums.IssueStatus.InProgress;
            expAdmin = new Client(226, "226");
            expBoard = new Board(226, 226);
            expBoard.Issues.Add(issue10);
            expBoard.Issues.Add(expAttachIssue);
            expClient.BoardsForUser.Add(226);
            expBoard.IDMembers.Add(506);

            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 226, expAdmin},
                { 506, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            // 7. проверка на недобавление задания к Админу, если задание находится  в InProgress у другого участника

            client = new Client(557, "557");
            Client otherClient = new Client(1, "1");
            //issue1.IdUser = client.IDUser;
            attachIssue = new Issue(257, "257");
            attachIssue.Status = Enums.IssueStatus.InProgress;
            attachIssue.IdUser = otherClient.IDUser;
            board = new Board(1057, 557);
            board.Issues.Add(attachIssue);
            idAttachIssue = 257;
            baseBoards = new Dictionary<int, Board>
            {
                {board.NumberBoard, board }
            };
            client.BoardsForUser.Add(1057);
            board.IDAdmin.Add(557);
            baseClients = new Dictionary<long, Client>
            {
                { 557, client },
                { 1, otherClient}
            };

            expClient = new Client(557, "557");
            Client expOtherClient = new Client(1, "1");
            expAttachIssue = new Issue(257, "257");
            expAttachIssue.IdUser = expOtherClient.IDUser;
            expAttachIssue.Status = Enums.IssueStatus.InProgress;
            expBoard = new Board(1057, 557);
            expBoard.Issues.Add(expAttachIssue);
            expClient.BoardsForUser.Add(1057);
            expBoard.IDAdmin.Add(557);
            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 557, expClient },
                { 1, expOtherClient}
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            // 8. проверка на недобавление задания к Мемберу, если задание находится  в InProgress у другого участника

            issue10 = new Issue(1048, "1048");
            admin = new Client(2248, "2248");
            issue10.Status = Enums.IssueStatus.InProgress;
            issue10.IdUser = admin.IDUser;
            board = new Board(2248, 2248);
            board.Issues.Add(issue10);
            idAttachIssue = 1048;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            client = new Client(5048, "5048");

            client.BoardsForUser.Add(2248);
            board.IDMembers.Add(5048);
            baseClients = new Dictionary<long, Client>
            {
                { 2248, admin},
                { 5048, client }
            };

            expIssue10 = new Issue(1048, "1048");
            expAdmin = new Client(2248, "2248");
            expClient = new Client(5048, "5048");
            expIssue10.Status = Enums.IssueStatus.InProgress;
            expIssue10.IdUser = expAdmin.IDUser;
            expBoard = new Board(2248, 2248);
            expBoard.Issues.Add(issue10);
            expClient.BoardsForUser.Add(2248);
            expBoard.IDMembers.Add(5048);

            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 2248, expAdmin},
                { 5048, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

            //8. проверка на не добавление задания к человеку, если он не является админом или мембером

            issue1 = new Issue(18, "18");
            attachIssue = new Issue(28, "28");
            board = new Board(108, 58);
            board.Issues.Add(issue1);
            board.Issues.Add(attachIssue);
            idAttachIssue = 28;
            baseBoards = new Dictionary<int, Board>
            {
                { board.NumberBoard, board}
            };
            Client clientNope = new Client(666, "666");
            client = new Client(58, "58");
            client.BoardsForUser.Add(108);
            board.IDAdmin.Add(58);
            baseClients = new Dictionary<long, Client>
            {
                { 58, client }
            };

            expIssue1 = new Issue(18, "18");
            expAttachIssue = new Issue(28, "28");
            expClient = new Client(58, "58");
            expBoard = new Board(108, 58);
            expBoard.Issues.Add(expIssue1);
            expBoard.Issues.Add(expAttachIssue);
            expClient.BoardsForUser.Add(108);
            expBoard.IDAdmin.Add(58);
            expAttachIssue.IdUser = expClient.IDUser;
            expectedBoards = new Dictionary<int, Board>
            {
                { expBoard.NumberBoard, expBoard}
            };
            expectedClients = new Dictionary<long, Client>
             {
                { 58, expClient }
            };

            yield return new object[] { baseBoards, board, baseClients, client, expectedBoards, idAttachIssue, expectedClients };

        }

        public static IEnumerable GetAllBoardsByNumbersOfBoardTestCaseSource()
        {
            //1. Проверка, если запрашиваем доски для Админа

            Client client = new Client(10, "10");
            Board board1 = new Board(1, 10);
            Board board2 = new Board(2, 10);
            List<int> baseBoardsForUser = new List<int>
            {
            board1.NumberBoard,
            board2.NumberBoard
            };
            Dictionary<int, Board> baseBoards = new Dictionary<int, Board>
            {
                {board1.NumberBoard, board1 },
                {board2.NumberBoard, board2 }
            };
            client.BoardsForUser = baseBoardsForUser;

            Client expClient = new Client(10, "10");
            Board expBoard1 = new Board(1, 10);
            Board expBoard2 = new Board(2, 10);
            Dictionary<int, Board> expBaseBoards = new Dictionary<int, Board>
            {
                {expBoard1.NumberBoard, expBoard1 },
                {expBoard2.NumberBoard, expBoard2 }
            };
            List<int> expBoardsForUser = new List<int>
            {
            expBoard1.NumberBoard,
            expBoard2.NumberBoard
            };
            client.BoardsForUser = expBoardsForUser;
            List<Board> expectedBoards = new List<Board> { expBoard1, expBoard2 };

            yield return new Object[] { client, baseBoards, baseBoardsForUser, expectedBoards };

            //2. Проверка, если запрашиваем доски для Мембера

            Client admin = new Client(10, "10");
            client = new Client(100, "100");
            board1 = new Board(10, 10);
            board1.IDMembers.Add(100);
            board2 = new Board(20, 10);
            board2.IDMembers.Add(100);
            baseBoardsForUser = new List<int>
            {
            board1.NumberBoard,
            board2.NumberBoard
            };
            baseBoards = new Dictionary<int, Board>
            {
                {board1.NumberBoard, board1 },
                {board2.NumberBoard, board2 }
            };
            client.BoardsForUser = baseBoardsForUser;

            Client expAdmin = new Client(10, "10");
            expClient = new Client(100, "100");
            expBoard1 = new Board(10, 10);
            expBoard1.IDMembers.Add(100);
            expBoard2 = new Board(20, 10);
            expBoard2.IDMembers.Add(100);
            expBaseBoards = new Dictionary<int, Board>
            {
                {expBoard1.NumberBoard, expBoard1 },
                {expBoard2.NumberBoard, expBoard2 }
            };
            expBoardsForUser = new List<int>
            {
            expBoard1.NumberBoard,
            expBoard2.NumberBoard
            };
            client.BoardsForUser = expBoardsForUser;
            expectedBoards = new List<Board> { expBoard1, expBoard2 };

            yield return new Object[] { client, baseBoards, baseBoardsForUser, expectedBoards };

            //3. Проверка, если запрашиваем доски для Админа, где часть досок на другом участнике

            client = new Client(103, "103");
            board1 = new Board(13, 103);
            board2 = new Board(23, 103);
            Board boardOther = new Board(66, 66);
            baseBoardsForUser = new List<int>
            {
            board1.NumberBoard,
            board2.NumberBoard
            };
            baseBoards = new Dictionary<int, Board>
            {
                {board1.NumberBoard, board1 },
                {board2.NumberBoard, board2 },
                { boardOther.NumberBoard, boardOther}
            };
            client.BoardsForUser = baseBoardsForUser;

            expClient = new Client(103, "103");
            expBoard1 = new Board(13, 103);
            expBoard2 = new Board(23, 103);
            Board expBoardOther = new Board(66, 66);
            expBaseBoards = new Dictionary<int, Board>
            {
                {expBoard1.NumberBoard, expBoard1 },
                {expBoard2.NumberBoard, expBoard2 },
                { expBoardOther.NumberBoard , expBoardOther}
            };
            expBoardsForUser = new List<int>
            {
            expBoard1.NumberBoard,
            expBoard2.NumberBoard
            };
            client.BoardsForUser = expBoardsForUser;
            expectedBoards = new List<Board> { expBoard1, expBoard2 };

            yield return new Object[] { client, baseBoards, baseBoardsForUser, expectedBoards };

            //4. Проверка, если запрашиваем доски для Мембера, где часть досок на другом участнике

            admin = new Client(104, "104");
            client = new Client(1004, "1004");
            board1 = new Board(104, 104);
            board1.IDMembers.Add(1004);
            board2 = new Board(204, 104);
            board2.IDMembers.Add(1004);
            boardOther = new Board(99, 99);
            baseBoardsForUser = new List<int>
            {
            board1.NumberBoard,
            board2.NumberBoard
            };
            baseBoards = new Dictionary<int, Board>
            {
                {board1.NumberBoard, board1 },
                {board2.NumberBoard, board2 },
                { boardOther.NumberBoard, boardOther}
                        };
            client.BoardsForUser = baseBoardsForUser;

            expAdmin = new Client(104, "104");
            expClient = new Client(1004, "1004");
            expBoard1 = new Board(104, 104);
            expBoard1.IDMembers.Add(1004);
            expBoard2 = new Board(204, 104);
            expBoard2.IDMembers.Add(1004);
            Board expboardOther = new Board(99, 99);
            expBaseBoards = new Dictionary<int, Board>
            {
                {expBoard1.NumberBoard, expBoard1 },
                {expBoard2.NumberBoard, expBoard2 },
                { expboardOther.NumberBoard, expboardOther}
            };
            expBoardsForUser = new List<int>
            {
            expBoard1.NumberBoard,
            expBoard2.NumberBoard
            };
            client.BoardsForUser = expBoardsForUser;
            expectedBoards = new List<Board> { expBoard1, expBoard2 };

            yield return new Object[] { client, baseBoards, baseBoardsForUser, expectedBoards };

            //5. Показать все доски у участника, в которых он и Админ, и Мембер

            client = new Client(1045, "1045");
            board1 = new Board(1045, 1045);
            board2 = new Board(2045, 1045);
            boardOther = new Board(995, 995);
            boardOther.IDMembers.Add(1045);
            baseBoardsForUser = new List<int>
            {
            board1.NumberBoard,
            board2.NumberBoard,
            boardOther.NumberBoard
            };
            baseBoards = new Dictionary<int, Board>
            {
                {board1.NumberBoard, board1 },
                {board2.NumberBoard, board2 },
                { boardOther.NumberBoard, boardOther}
                        };
            client.BoardsForUser = baseBoardsForUser;

            expClient = new Client(1045, "1045");
            expBoard1 = new Board(1045, 1045);
            expBoard2 = new Board(2045, 1045);
            expboardOther = new Board(995, 995);
            expboardOther.IDMembers.Add(1045);
            expBaseBoards = new Dictionary<int, Board>
            {
                {expBoard1.NumberBoard, expBoard1 },
                {expBoard2.NumberBoard, expBoard2 },
                { expboardOther.NumberBoard, expboardOther}
            };
            expBoardsForUser = new List<int>
            {
            expBoard1.NumberBoard,
            expBoard2.NumberBoard,
            expboardOther.NumberBoard
            };
            expClient.BoardsForUser = expBoardsForUser;
            expectedBoards = new List<Board> { expBoard1, expBoard2, expboardOther };

            yield return new Object[] { client, baseBoards, baseBoardsForUser, expectedBoards };
        }

        public static IEnumerable ChangeRoleFromMemberToAdminTestCaseSource()
        {
            //1. Проверяем, когда Админ может поменять роль у Мембера

            Board activeBoard = new Board(1, 1);
            Client client = new Client(1, "1");
            Client member = new Client(10, "10");
            Client member2 = new Client(20, "20");
            // activeBoard.IDAdmin.Add(1);
            activeBoard.IDMembers.Add(10);
            activeBoard.IDMembers.Add(20);
            long idMemeber = 10;
            Dictionary<int, Board> baseBoards = new Dictionary<int, Board>
            {
                {activeBoard.NumberBoard, activeBoard }
            };

            Board expActiveBoard = new Board(1, 1);
            Client expClient = new Client(1, "1");
            Client expMember = new Client(10, "10");
            Client expMember2 = new Client(20, "20");
            //expActiveBoard.IDAdmin.Add(1);
            expActiveBoard.IDAdmin.Add(10);
            expActiveBoard.IDMembers.Add(20);
            Dictionary<int, Board> expectedBoards = new Dictionary<int, Board>
            {
                {expActiveBoard.NumberBoard, expActiveBoard }
            };

            yield return new Object[] { baseBoards, client, activeBoard, idMemeber, expectedBoards };

            //2. Проверяем, что Мембер не может поменять роль у Мембера

            activeBoard = new Board(12, 1);
            client = new Client(12, "12");
            member = new Client(102, "102");
            member2 = new Client(202, "202");
            activeBoard.IDMembers.Add(12);
            activeBoard.IDMembers.Add(102);
            activeBoard.IDMembers.Add(202);
            idMemeber = 102;
            baseBoards = new Dictionary<int, Board>
            {
                {activeBoard.NumberBoard, activeBoard }
            };

            expActiveBoard = new Board(12, 1);
            expClient = new Client(12, "12");
            expMember = new Client(102, "102");
            expMember2 = new Client(202, "202");
            expActiveBoard.IDMembers.Add(12);
            expActiveBoard.IDMembers.Add(102);
            expActiveBoard.IDMembers.Add(202);
            expectedBoards = new Dictionary<int, Board>
            {
                {expActiveBoard.NumberBoard, expActiveBoard }
            };

            yield return new Object[] { baseBoards, client, activeBoard, idMemeber, expectedBoards };

            //3. Проверяем, когда Админ пытается поменять роль у Мембера, которого нет в этой доске

            activeBoard = new Board(13, 13);
            Board otherBoard = new Board(50, 50);
            Client otherClient = new Client(49, "49");
            client = new Client(13, "13");
            member = new Client(103, "103");
            member2 = new Client(203, "203");
            activeBoard.IDMembers.Add(103);
            activeBoard.IDMembers.Add(203);
            otherBoard.IDMembers.Add(49);
            idMemeber = 49;
            baseBoards = new Dictionary<int, Board>
            {
                {activeBoard.NumberBoard, activeBoard },
                {otherBoard.NumberBoard, otherBoard }
            };

            expActiveBoard = new Board(13, 13);
            Board expOtherBoard = new Board(50, 50);
            Client expOtherClient = new Client(49, "49");
            expClient = new Client(13, "13");
            expMember = new Client(103, "103");
            expMember2 = new Client(203, "203");
            expActiveBoard.IDMembers.Add(103);
            expActiveBoard.IDMembers.Add(203);
            expOtherBoard.IDMembers.Add(49);
            expectedBoards = new Dictionary<int, Board>
            {
                {expActiveBoard.NumberBoard, expActiveBoard },
                {expOtherBoard.NumberBoard, expOtherBoard }
            };

            yield return new Object[] { baseBoards, client, activeBoard, idMemeber, expectedBoards };

            //4. Проверяем, когда Админ пытается поменять роль у другого Админа (хотя метод рассчитан на изменение статуса Мембера на Админа)

            activeBoard = new Board(134, 134);
            client = new Client(134, "134");
            member = new Client(1034, "1034");
            member2 = new Client(2034, "2034");
            activeBoard.IDMembers.Add(1034);
            activeBoard.IDAdmin.Add(2034);
            activeBoard.IDMembers.Add(494);
            idMemeber = 2034;
            baseBoards = new Dictionary<int, Board>
            {
                {activeBoard.NumberBoard, activeBoard }
            };

            expActiveBoard = new Board(134, 134);
            expClient = new Client(134, "134");
            expMember = new Client(1034, "1034");
            expMember2 = new Client(2034, "2034");
            expActiveBoard.IDMembers.Add(1034);
            expActiveBoard.IDAdmin.Add(2034);
            expActiveBoard.IDMembers.Add(494);
            expectedBoards = new Dictionary<int, Board>
            {
                {expActiveBoard.NumberBoard, expActiveBoard }
            };

            yield return new Object[] { baseBoards, client, activeBoard, idMemeber, expectedBoards };
        }
    }
}

