using CommonLibary.CommonDb;
using CommonLibary.CommonModels;
using SocialCommunicationModels.ChatInputAndOutputModels;
using SocialCommunicationModels.ChatRegisterModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    /// <summary>
    /// Get Chat Registered Users List (Global Chat users list) DLL.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
    public class GetChatRegisteredUsersDL
    {
        /// <summary>
        /// Get Chat Registered User List Golbal Chat Users List DLL.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers">Chat Common output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisteredUsers"/>
        public OutputModel ChatRegisteredUsersGet(InputModel inputModel)
        {
            OutputModel outputModel = null;
            ChatRegisterUserModel ChatUser;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatRegisterUsers_Get");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.chatRegisterUserModel.UserId.ToString());

            command.AddCommonInputParams();

            using (IDataReader reader = command.ExecuteReader())
            {
                outputModel = new OutputModel();
                outputModel.ChatRegisteredUsers = new List<ChatRegisterUserModel>();
                
                reader.AddCol("UserName");
                reader.AddCol("UserId");

                while (reader.Read())
                {
                    ChatUser = new ChatRegisterUserModel()
                    {
                        UserName = reader.GetDbValue("UserName",string.Empty),
                        UserId = reader.GetDbValue("UserId",-1),
                    };
                    outputModel.ChatRegisteredUsers.Add(ChatUser);
                }
            }

            if (outputModel.ChatRegisteredUsers.Count == 0)
            {
                outputModel.responseModel = new ResponseModel();
                command.GetCommonOutputParams(outputModel.responseModel);
            }

            command.ConnectionDispose();

            return outputModel;
        }
    }
}
