namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using Newtonsoft.Json;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Add Frineds to Chat User.
    /// </summary>
    /// <seealso cref="InputModel.addFriend"/>
    /// <seealso cref="OutputModel.responseModel"/>
    public class AddFriendDL
    {
        /// <summary>
        /// Add Friend Using with update or insert flag.
        /// </summary>
        /// <param name="inputModel" cref="InputModel.addFriend">Chat Common Input Model.</param>
        /// <param name="InsertOrUpdate">true--> update     |    false--> Insert.   This Can Simplify the Update the frineds list in Db table OR Insert the Initial Frined to Db table.</param>
        /// <returns cref="ResponseModel">Common Response Model.</returns>
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
