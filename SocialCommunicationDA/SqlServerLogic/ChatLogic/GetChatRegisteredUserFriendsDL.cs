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
    /// Get Char Registered User Friends List DLL.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.Friends"/>
    public class GetChatRegisteredUserFriendsDL
    {
        /// <summary>
        /// Chat Registratered User Friends List Get DLL Member.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.Friends">Chat Common Output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.Friends"/>
        /// <remarks>End Point Sample Json: </remarks>
        public OutputModel ChatRegisteredUserFriends(InputModel inputModel)
        {
            OutputModel outputModel = null;
            ChatRegisterUserModel ChatUser;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatUserFriendsList_Get");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.chatRegisterUserModel.UserId.ToString());

            command.AddCommonInputParams();

            using (IDataReader reader = command.ExecuteReader())
            {
                outputModel = new OutputModel();
                outputModel.Friends = new List<ChatRegisterUserModel>();

                reader.AddCol("UserName");
                reader.AddCol("UserId");

                while (reader.Read())
                {
                    ChatUser = new ChatRegisterUserModel()
                    {
                        UserName = reader.GetDbColValue("UserName",string.Empty),
                        UserId = reader.GetDbColValue("UserId", -1),
                    };
                    outputModel.Friends.Add(ChatUser);
                }
            }

            if (outputModel.Friends.Count == 0)
            {
                outputModel.responseModel = new ResponseModel();
                command.GetCommonOutputParams(outputModel.responseModel);
            }

            command.ConnectionDispose();

            return outputModel;
        }
    }

    
}
