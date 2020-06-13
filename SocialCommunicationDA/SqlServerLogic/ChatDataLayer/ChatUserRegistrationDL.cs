namespace SocialCommunicationDA.SqlServerLogic.ChatDataLayer
{
    using CommonLibary.CommonDb;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using System.Data;
    using System.Data.SqlClient;

    public class ChatUserRegistrationDL
    {
        public OutputModel UserRegistration(InputModel inputModel)
        {
            OutputModel outputModel = null;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatUserRegister_insert_Get");

            command.AddParameter("@UserName", SqlDbType.VarChar, inputModel.chatRegisterUserModel.UserName, 50);
            
            command.AddCommonInputParams();

            using (IDataReader reader = command.ExecuteReader())
            {
                outputModel = new OutputModel();

                if (reader.Read())
                {
                    outputModel.ChatRegisterUserOutput = new ChatRegisterUserModel()
                    {
                        UserId = reader.GetDbInt32("UserId"),
                        UserName = reader.GetDbStriing("UserName")
                    };

                    
                }
            }
            command.GetCommonOutputParams(outputModel.responseModel);

            command.Connection.Close();

            return outputModel;
        }
    }
}
