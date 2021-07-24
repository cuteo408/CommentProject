using CommentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentProject.Logics
{
    public class CommentBL
    {
        private List<Comment> list;
        private const string filename = "db.json";

        /// <summary>
        /// Read the list of Comments from file. If empty, init with a sample list.
        /// </summary>
        public CommentBL()
        {
            list = CommentDA.Read<List<Comment>>(filename) ?? new List<Comment>();
            if (list.Count == 0)
            {
                list = InitCommentList() ?? new List<Comment>();
                CommentDA.Write(filename, list);

            }
        }

        /// <summary>
        /// return a list from Comments
        /// </summary>
        /// <returns></returns>
        public List<Comment> GetItems()
        {
            return list;
        }

        /// <summary>
        /// return a specific Comment based on ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Comment GetItem(int ID)
        {
            if (ID == 0)
                return new Comment();
            else
                return list.Find(o => o.ID == ID);
        }

        /// <summary>
        /// Add a new Comment to the list and save to file
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Comment item)
        {
            if (list.Count > 0)
            {
                Comment lastitem = list[list.Count - 1];
                item.ID = lastitem.ID + 1;
                item.RosterKey = item.ID;
            }
            else
                item.ID = list.Count + 1;

            list.Add(item);
            Commit();

        }

        /// <summary>
        /// Update a specific Comment and save to file 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="item"></param>
        public void UpdateItem(int ID, Comment item)
        {
            item.ID = ID;
            int index = list.FindIndex(o => o.ID == ID);
            list[index] = item;
            Commit();

        }

        /// <summary>
        /// Delete a specific Comment and save to file
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteItem(int ID)
        {
            int index = list.FindIndex(o => o.ID == ID);
            list.RemoveAt(index);
            Commit();

        }

        /// <summary>
        /// Write to file
        /// </summary>
        private void Commit() => CommentDA.Write(filename, list ?? new List<Comment>());

        /// <summary>
        /// Init employe list
        /// </summary>
        /// <returns></returns>
        private List<Comment> InitCommentList()
        {
            list.Add(new Comment() { ID = 1, Name = "John Doe", TimeStamp = "1/11/2021 5:42am", CommentData = "You could do better.", RosterKey=1 });
            list.Add(new Comment() { ID = 2, Name = "Ray Kee", TimeStamp = "1/21/2021 7:12am", CommentData = "Make some more adjustment.", RosterKey = 2 });
            list.Add(new Comment() { ID = 3, Name = "Leane Rees", TimeStamp = "2/12/2021 8:41am", CommentData = "This is a test and only a test.", RosterKey = 3 });
            list.Add(new Comment() { ID = 4, Name = "Lex Lane", TimeStamp = "5/21/1945 5:42am", CommentData = "I feel like you can do better.", RosterKey = 4 });
            list.Add(new Comment() { ID = 5, Name = "Justin Johnson", TimeStamp = "5/21/1945 5:42am", CommentData = "This is another test.", RosterKey = 5 });

            return list;

        }
    }
}