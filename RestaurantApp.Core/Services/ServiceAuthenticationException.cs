﻿using System;

namespace RestaurantApp.Core.Services
{
    public class ServiceAuthenticationException : Exception

    {
        public ServiceAuthenticationException()

        {
        }


        public ServiceAuthenticationException(string content):base(content)

        {
            Content = content;
        }

        public string Content { get; }
    }
}