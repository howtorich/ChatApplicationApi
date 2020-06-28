namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using Newtonsoft.Json;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System.Data;
    using System.Data.SqlClient;

    public class AddFriendDL
    {
        /// <summary>
        /// Add Friend Using with update or insert flag.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <param name="InsertOrUpdate">true--> update     |    false--> Insert</param>
        /// <returns></returns>
        public ResponseModel AddFriend(InputModel inputModel,bool InsertOrUpdate)
        {
            ResponseModel response;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatAddFriends");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.addFriend.UserId.ToString());

            command.AddParameter("@AddingUserIds", SqlDbType.VarChar, inputModel.addFriend.AddingUserIds.ToString());

            command.AddParameter("@InsertUpdate", SqlDbType.Bit, InsertOrUpdate.ToString());

            command.AddCommonInputParams();

            command.ExecuteNonQuery();

            response = new ResponseModel();
            command.GetCommonOutputParams(response);

            command.Connection.Close();

            return response;
        }
    }
}
