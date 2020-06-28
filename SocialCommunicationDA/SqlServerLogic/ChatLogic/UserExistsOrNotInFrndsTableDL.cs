namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System.Data;
    using System.Data.SqlClient;

    public class UserExistsOrNotInFrndsTableDL
    {
        public ResponseModel UserExistsOrNotInFrndsTable(InputModel inputModel)
        {
            ResponseModel responseModel;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_UserExistsOrNotInFrndsTable");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.addFriend.UserId.ToString());

            command.AddParameter("@AddingUserId", SqlDbType.Int, inputModel.addFriend.AddingFriendUserId.ToString());

            command.AddParameter("@Exists", SqlDbType.Bit, false.ToString(), ParameterDirection.Output);

            command.AddCommonInputParams();

            command.ExecuteNonQuery();

            responseModel = new ResponseModel();
            responseModel.ResponseData = command.GetOutputParam("@Exists", false);

            command.GetCommonOutputParams(responseModel);

            command.Connection.Close();

            return responseModel;
        }
    }
}
