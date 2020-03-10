using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SmsIrRestfulNetCore;

namespace BakeryApi.Helpers
{
    public class SmsHelper
    {
        private readonly IConfiguration _config;

        public SmsHelper(IConfiguration config)
        {
            _config = config;
        }

        public bool SendSms(string to, string message)
        {
            var token = new Token().GetToken(_config["Sms:UserApiKey"], _config["Sms:SecretKey"]);


            var messageSendObject = new MessageSendObject
            {
                Messages = new List<string> {message}.ToArray(),
                MobileNumbers = new List<string> {to}.ToArray(),
                LineNumber = _config["Sms:SmsNumber"],
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };

            var messageSendResponseObject = new MessageSend().Send(token, messageSendObject);
            return messageSendResponseObject.IsSuccessful;
        }

        public bool SendSecurityCode(string to, string code)
        {
            var token = new Token().GetToken(_config["Sms:UserApiKey"], _config["Sms:SecretKey"]);

            var ultraFastSend = new UltraFastSend()
            {
                Mobile = Convert.ToInt64(to),
                TemplateId = 22311,
                ParameterArray = new List<UltraFastParameters>()
                {
                    new UltraFastParameters()
                    {
                        Parameter = "VerificationCode" , ParameterValue = code
                    },
                    new UltraFastParameters()
                    {
                        Parameter = "WebsiteAddress" , ParameterValue = "نانوایی آنلاین"
                    },
                }.ToArray()

            };
            UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);
            return ultraFastSendRespone.IsSuccessful;
        }


    }
}