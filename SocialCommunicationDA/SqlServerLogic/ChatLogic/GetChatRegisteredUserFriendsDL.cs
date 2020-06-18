namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class GetChatRegisteredUserFriendsDL
    {
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

                while (reader.Read())
                {
                    ChatUser = new ChatRegisterUserModel()
                    {
                        UserName = reader.GetDbStriing("UserName"),
                        UserId = reader.GetDbInt32("UserId"),
                    };
                    outputModel.Friends.Add(ChatUser);
                }
            }

            if (outputModel.Friends.Count == 0)
            {
                outputModel.responseModel = new ResponseModel();
                command.GetCommonOutputParams(outputModel.responseModel);
            }

            command.Connection.Close();

            return outputModel;
        }
    }
}
