﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using StackExchange.Redis;

namespace WebApplication1.Controllers
{
    public class SendController : ApiController
    {

        public string Get(string message)
        {
            return "You input " + message + "@"+DateTime.Now.ToString()+" from "+Request.RequestUri; 
        }
        [HttpPost]
        public ApiResponseMessage PostAll(ApiRequestMessage message)
        {
            ApiResponseMessage responseMessage = new ApiResponseMessage();
            string retMsg = "";
            responseMessage.Success = true;
            try
            {
                if (!String.IsNullOrEmpty(message.Chanel))
                    {
                    ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost:6379");
                    if (conn.IsConnected)
                    {
                        IDatabase redis = conn.GetDatabase();
                        if (redis.StringSet(message.Chanel, message.Message))
                            retMsg += "redis存储成功";
                        redis.Publish(message.Chanel, message.Message);
                    }
                    else
                        throw new Exception("Redis服务器出错");
                }
            }
            catch(Exception ex)
            {
                retMsg+= ex.Message;
                responseMessage.Success = false;
            }
            responseMessage.User = message.User;
            responseMessage.Message = String.Format("↑:{0}   ↓:{1}",message.Message, retMsg);
            responseMessage.ContentType = message.ContentType;
            return responseMessage;
        }

    }    
}