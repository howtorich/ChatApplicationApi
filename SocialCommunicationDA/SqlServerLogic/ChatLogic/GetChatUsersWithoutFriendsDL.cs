namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Get Chat Users Without Frineds of Particular User DLL.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
    public class GetChatUsersWithoutFriendsDL
    {
        /// <summary>
        /// Chat User Without Friends of Particular User DLL Member.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers">Chat Common Output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
        public OutputModel ChatUsersWithoutFriendsGet(InputModel inputModel)
        {
            OutputModel outputModel;
            ChatRegisterUserModel Frined;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatRegisterUsersWithoutFriends_Get");

            command.AddParameter("@UserID", System.Data.SqlDbType.Int, inputModel.chatRegisterUserModel.UserId.ToString());

            command.AddCommonInputParams();

            using (IDataReader reader = command.ExecuteReader())
            {
                outputModel = new OutputModel();
                outputModel.Friends = new List<ChatRegisterUserModel>();

                reader.AddCol("UserId");
                reader.AddCol("UserName");

                while (reader.Read())
                {
                    Frined = new ChatRegisterUserModel();

                    Frined.UserId = reader.GetDbColValue("UserId", 0);
                    Frined.UserName = reader.GetDbColValue("UserName", string.Empty);

                    outputModel.Friends.Add(Frined);
                }
            }

            if (outputModel?.Friends?.Count == 0)
            {
                outputModel.responseModel = new ResponseModel();
                command.GetCommonOutputParams(outputModel.responseModel);
            }

            command.ConnectionDispose();

            return outputModel;

        }
    }
}
