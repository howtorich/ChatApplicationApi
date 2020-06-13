namespace SocialCommunicationsApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationsBL.BusinessLogic;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("SocialCommunication")]
    public class SocialCommunicationsController : ControllerBase
    {
        [Route("ChatUserRegistration")]
        [HttpPost]
        public async Task<IActionResult> ChatUserRegistration_Main(InputModel InputModel)
        {
            OutputModel outputModel = null;
            try
            {
                if (InputModel == null)
                {
                    outputModel = new OutputModel()
                    {
                        ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.NoContent,
                    };

                    return BadRequest(outputModel);
                }

                ChatActionFlowBl chatActionFlowBl = new ChatActionFlowBl();

                outputModel = await chatActionFlowBl.ChatApiActionFlow(InputModel);
            }
            catch (Exception ex)
            {
                outputModel = new OutputModel()
                {
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.ExecutionError,
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message,
                    StackTrace = ex.StackTrace,
                };
            }

            return Ok(outputModel);
        }
    }
}