namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class GetChatUsersWithoutFriendsDL
    {
        public OutputModel ChatUsersWithoutFriendsGet(InputModel inputModel)
        {
            OutputModel outputModel;
            ChatRegisterUserModel Frined;

            SqlCommand commad = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatRegisterUsersWithoutFriends_Get");

            commad.AddParameter("@UserID", System.Data.SqlDbType.Int, inputModel.chatRegisterUserModel.UserId.ToString());

            commad.AddCommonInputParams();

            using (IDataReader reader = commad.ExecuteReader())
            {
                outputModel = new OutputModel();
                outputModel.Friends = new List<ChatRegisterUserModel>();
                while (reader.Read())
                {
                    Frined = new ChatRegisterUserModel();

                    Frined.UserId = reader.GetDbValue("UserId", 0);
                    Frined.UserName = reader.GetDbValue("UserName", string.Empty);

                    outputModel.Friends.Add(Frined);
                }
            }

            if (outputModel?.Friends?.Count == 0)
            {
                outputModel.responseModel = new ResponseModel();
                commad.GetCommonOutputParams(outputModel.responseModel);
            }

            commad.Connection.Close();

            return outputModel;

        }
    }
}
