using API_Kokak.Interface;
using API_Kokak.Model;
using AspStudio.Variable;
using System.Data.SqlClient;
using Dapper;

namespace API_Kokak.Repository
{
    public class ChatMessageRepository: IChatMessageRepository
    {
        private GVar oGvar = new GVar();
        public async Task SaveMessageAsync(ChatMessageModel message)
        {
            var sql = @"INSERT INTO ChatMessages (FromUser, ToUser, Message, ImagePath, SentAt)
                    VALUES (@FromUser, @ToUser, @Message, @ImagePath, @SentAt)";
            using var conn = new SqlConnection(oGvar.kokkak);
            await conn.ExecuteAsync(sql, message);
        }
        public async Task<List<ChatMessageModel>> GetMessagesByReceiverAsync(string fromUser, string toUser)
        {
            var sql = @"SELECT * FROM ChatMessages
            WHERE (FromUser = @User1 AND ToUser = @User2)
               OR (FromUser = @User2 AND ToUser = @User1)
            ORDER BY SentAt ASC";

            using var conn = new SqlConnection(oGvar.kokkak);
            var result = await conn.QueryAsync<ChatMessageModel>(sql, new { User1 = fromUser, User2 = toUser });
            return result.ToList();
        }

    }
}
