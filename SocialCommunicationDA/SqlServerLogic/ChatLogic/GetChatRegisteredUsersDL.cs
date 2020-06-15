using CommonLibary.CommonDb;
using CommonLibary.CommonModels;
using SocialCommunicationModels.ChatInputAndOutputModels;
using SocialCommunicationModels.ChatRegisterModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    public class GetChatRegisteredUsersDL
    {
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

                while (reader.Read())
                {
                    ChatUser = new ChatRegisterUserModel()
                    {
                        UserName = reader.GetDbStriing("UserName"),
                        UserId = reader.GetDbInt32("UserId"),
                    };
                    outputModel.ChatRegisteredUsers.Add(ChatUser);
                }
            }

            if (outputModel.ChatRegisteredUsers.Count == 0)
            {
                outputModel.responseModel = new ResponseModel();
                command.GetCommonOutputParams(outputModel.responseModel);
            }

            command.Connection.Close();

            return outputModel;
        }
    }
}
