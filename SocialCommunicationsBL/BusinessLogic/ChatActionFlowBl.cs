namespace SocialCommunicationsBL.BusinessLogic
{
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationsBL.BusinessLogic.ChatLogic;
    using System.Threading.Tasks;

    public class ChatActionFlowBl
    {
        public async Task<OutputModel> ChatApiActionFlow(InputModel inputModel)
        {
            OutputModel outputModel = null;

            if (inputModel?.ApiAction == null)
            {
                outputModel = new OutputModel()
                {
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.NoContent,
                };
            }

            switch (inputModel.ApiAction)
            {
                case ChatApiActionEnums.ChatApiActions.Registration:
                    // Test Input Json  : {"ApiAction":100,"chatRegisterUserModel":{"UserName":"pavan@somineni99"}}
                    // Test Output Json : {"chatRegisterUserOutput":{"userName":"pavan@somineni99","userId":23},"chatRegisteredUsers":null,"chatRegisteredUserFriends":null,"responseModel":{"executionStatus":1,"errorStatus":0,"errorMessage":""},"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    ChatUserRegistration chatUserRegistration = new ChatUserRegistration();
                    outputModel = chatUserRegistration.UserRegistration(inputModel);

                    break;
                case ChatApiActionEnums.ChatApiActions.GetChatUsersList:
                    // Test Input Json  : {"ApiAction":101,"chatRegisterUserModel":{}}
                    // Test Output Json : {"chatRegisterUserOutput":null,"chatRegisteredUsers":[{"userName":"pavanSomineni","userId":1},{"userName":"Satya","userId":3},{"userName":"Vijay","userId":4},{"userName":"PDV Sai Krish","userId":5},{"userName":"Pdvs","userId":6},{"userName":"Pdvs Krishna","userId":7},{"userName":"pavan Krishna","userId":8},{"userName":"sassss","userId":9},{"userName":"pavanKrishna","userId":10},{"userName":"pavanKrishna2","userId":11},{"userName":"pavanKrishna3","userId":12},{"userName":"pavanKrishna4","userId":16},{"userName":"pavansomineni9","userId":17},{"userName":"pavanKrishna11","userId":20},{"userName":"pavansomineni19","userId":21},{"userName":"pavansomineni99","userId":22},{"userName":"pavan@somineni99","userId":23}],"chatRegisteredUserFriends":null,"responseModel":null,"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    GetChatRegisteredUsers getChatRegisteredUsers = new GetChatRegisteredUsers();

                    outputModel = getChatRegisteredUsers.ChatRegisteredUsersGet(inputModel);

                    break;
                case ChatApiActionEnums.ChatApiActions.GetUserFriendsList:
                    // Test Input Json  : {"ApiAction":102,"chatRegisterUserModel":{"UserId":1}}
                    // Test Output Json : {"chatRegisterUserOutput":null,"chatRegisteredUsers":null,"chatRegisteredUserFriends":[{"userName":"Satya","userId":3},{"userName":"Vijay","userId":4}],"responseModel":null,"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    GetChatRegisteredUserFriends getChatRegisteredUserFriends = new GetChatRegisteredUserFriends();

                    outputModel = getChatRegisteredUserFriends.ChatRegisteredUserFriends(inputModel);

                    break;

                case ChatApiActionEnums.ChatApiActions.GetUsersWithoutFriends:
                    // Test Input Json  : {"ApiAction":102,"chatRegisterUserModel":{"UserId":1}}
                    // Test Output Json : {"chatRegisterUserOutput":null,"chatRegisteredUsers":null,"chatRegisteredUserFriends":[{"userName":"Satya","userId":3},{"userName":"Vijay","userId":4}],"responseModel":null,"errorMessage":null,"innerException":null,"stackTrace":null,"executionalStatus":1003,"executionalStatusMessage":"Success"}

                    GetChatUsersWithoutFriends getChatUsersWithoutFriends = new GetChatUsersWithoutFriends();

                    outputModel = getChatUsersWithoutFriends.ChatUsersWithoutFriendsGet(inputModel);

                    break;
                default:
                    break;
            }

            return await Task.FromResult(outputModel);
        }
    }
}
